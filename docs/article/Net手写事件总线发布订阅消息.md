## Net 手写 事件总线 发布订阅消息

### 前言

今晚打老虎

事件总线是对发布-订阅模式的一种实现。它是一种集中式事件处理机制，允许不同的组件之间进行彼此通信而又不需要相互依赖，达到一种`解耦`的目的。(项目的解耦很重要)

参考链接：https://blog.csdn.net/ZhaoHuaQiao_FL/article/details/118733737

#### 第一步: 定义一个事件总线扩展类 EventBusExtensions

`AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).ToList()`
首先定义一个事件总线扩展类 EventBusExtensions
通常获取获取 AppDomain 中所有的程序集

```csharp
 /// <summary>
    /// 轻量级事件总线服务拓展
    /// </summary>
    public static class EventBusExtensions
    {
        public static IServiceCollection AddSimpleEventBus(this IServiceCollection services)
        {

            // 查找所有贴了 [SubscribeMessage] 特性的方法，并且含有两个参数，第一个参数为 string messageId，第二个参数为 object payload
            var typeMethods = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).ToList()
                // 查询符合条件的订阅类
                .Where(m => m.IsClass && !m.IsAbstract && !m.IsInterface && typeof(ISubscribeHandler).IsAssignableFrom(m))
                // 查询符合条件的订阅方法
                .SelectMany(n => n.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.IsDefined(typeof(SubscribeMessageAttribute), false)
                                                    && x.GetParameters().Length == 2
                                                    && x.GetParameters()[0].ParameterType == typeof(string)
                                                    && x.GetParameters()[1].ParameterType == typeof(object))
                //根据类分组
                .GroupBy(m => m.DeclaringType));

            if (!typeMethods.Any()) return services;

            // 遍历所有订阅类型
            foreach (var item in typeMethods)
            {
                if (!item.Any()) continue;

                //创建订阅类对象
                var typeInstance = Activator.CreateInstance(item.Key);

                foreach (var method in item)
                {
                    // 判断是否是异步方法
                    var isAsyncMethod = false;

                    //创建委托类型,（将实例化类，类中的方法，定义方法参数弄成委托）
                    var action = Delegate.CreateDelegate(isAsyncMethod ? typeof(Func<string, object, Task>) : typeof(Action<string, object>), typeInstance, method.Name);

                    // 获取单个方法的所有消息特性
                    var subscribeMessageAttributes = method.GetCustomAttributes<SubscribeMessageAttribute>();

                    //注册订阅
                    foreach (var attr in subscribeMessageAttributes)
                    {
                        if (string.IsNullOrWhiteSpace(attr.MessageId)) continue;

                        if (isAsyncMethod)
                        {
                            InternalMessageCenter.Instance.Subscribe(item.Key, attr.MessageId, (Func<string, object, Task>)action);
                        }
                        else
                        {
                            InternalMessageCenter.Instance.Subscribe(item.Key, attr.MessageId, (Action<string, object>)action);
                        }
                    }
                }
            }
            return services;
        }
    }
```

#### 第二步 ：定义发布接口与订阅接口的中间类 InternalMessageCenter

然后在写一个定义发布接口与订阅接口的中间类 `InternalMessageCenter`

```csharp
/// <summary>
    /// 轻量级消息中心（进程内）
    /// </summary>
    internal sealed class InternalMessageCenter
    {
        /// <summary>
        /// 消息注册队列
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, object, Task>[]> MessageHandlerQueues = new ConcurrentDictionary<string, Func<string, object, Task>[]>();

        /// <summary>
        /// 类型消息 Id 注册表
        /// </summary>
        private readonly ConcurrentBag<string> TypeMessageIdsRegisterTable = new ConcurrentBag<string>();

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private InternalMessageCenter()
        {
        }

        private static readonly Lazy<InternalMessageCenter> lazy = new Lazy<InternalMessageCenter>(() => new InternalMessageCenter());

        /// <summary>
        /// 采用延迟加载设计模式处理单例 (为了避免每次运行都创建该对象，在第一次使用该对象时再对其进行初始化)
        /// </summary>
        private static readonly Lazy<InternalMessageCenter> InstanceLock = lazy;

        /// <summary>
        /// 获取消息中心对象
        /// </summary>
        internal static InternalMessageCenter Instance => InstanceLock.Value;

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe<T>(string messageId, params Action<string, object>[] messageHandlers)
        {
            Subscribe(typeof(T), messageId, messageHandlers);
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe<T>(string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            Subscribe(typeof(T), messageId, messageHandlers);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="messageId"></param>
        internal void Unsubscribe(string messageId)
        {
            _ = MessageHandlerQueues.TryRemove(messageId, out _);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="payload"></param>
        /// <param name="isSync">是否同步执行</param>
        internal void Send(string messageId, object payload = null, bool isSync = false)
        {
            if (MessageHandlerQueues.TryGetValue(messageId, out var messageHandlers))
            {
                foreach (var eventHandler in messageHandlers)
                {
                    if (isSync)
                    {

                        eventHandler(messageId, payload).GetAwaiter().GetResult();
                    }
                    else
                    {
                        //后期采用后台任务定时执行
                        eventHandler(messageId, payload);
                    }
                }
            }
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe(Type t, string messageId, params Action<string, object>[] messageHandlers)
        {
            if (messageHandlers == null || messageHandlers.Length == 0) return;

            var handlers = messageHandlers.Select(u =>
            {
                Func<string, object, Task> handler = async (m, o) =>
                {
                    u(m, o);
                    await Task.CompletedTask;
                };
                return handler;
            });

            Subscribe(t, messageId, handlers.ToArray());
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe(Type t, string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            if (messageHandlers == null || messageHandlers.Length == 0) return;

            // 判断当前类型是否已经注册过
            var uniqueMessageId = $"{t.FullName}_{messageId}";
            if (!TypeMessageIdsRegisterTable.Contains(uniqueMessageId))
            {
                TypeMessageIdsRegisterTable.Add(uniqueMessageId);
            }

            // 如果没有包含事件Id，则添加
            var isAdded = MessageHandlerQueues.TryAdd(messageId, messageHandlers);
            if (!isAdded)
            {
                MessageHandlerQueues[messageId] = MessageHandlerQueues[messageId].Concat(messageHandlers).ToArray();
            }
        }
    }
```

#### 第三步：定义消息订阅特性

定义一个消息订阅特性`SubscribeMessageAttribute `，用于指定此方法已经订阅，上面的扩展类中拿到此特性进行处理了的

```csharp
/// <summary>
    /// 订阅消息特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SubscribeMessageAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="messageId"></param>
        public SubscribeMessageAttribute(string messageId)
        {
            MessageId = messageId;
        }

        /// <summary>
        /// 消息Id
        /// </summary>
        public string MessageId { get; set; }
    }
```

#### 第五步：定义一个 handler 接口

最后在定义一个 handler 接口，里面什么都不用写，用于标注此类是被订阅的类

```csharp
    public interface ISubscribeHandler
    {

    }
```

#### 第六步：定义消息发布

目前是静态的，不太喜欢注入的方式

```csharp
 public static class MessageCenter
    {
        //
        // 摘要:
        //     订阅消息
        //
        // 参数:
        //   messageId:
        //
        //   messageHandlers:
        public static void Subscribe<T>(string messageId, params Action<string, object>[] messageHandlers)
        {
            InternalMessageCenter.Instance.Subscribe<T>(messageId, messageHandlers);
        }

        //
        // 摘要:
        //     订阅消息
        //
        // 参数:
        //   messageId:
        //
        //   messageHandlers:
        public static void Subscribe<T>(string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            InternalMessageCenter.Instance.Subscribe<T>(messageId, messageHandlers);
        }

        //
        // 摘要:
        //     发送消息
        //
        // 参数:
        //   messageId:
        //
        //   payload:
        //
        //   isSync:
        //     是否同步执行
        public static void Send(string messageId, object payload = null, bool isSync = false)
        {
            InternalMessageCenter.Instance.Send(messageId, payload, isSync);
        }

        //
        // 摘要:
        //     取消订阅
        //
        // 参数:
        //   messageId:
        public static void Unsubscribe(string messageId)
        {
            InternalMessageCenter.Instance.Unsubscribe(messageId);
        }
    }
```

#### 订阅消息

```csharp
public class LogSubscribeHandler : ISubscribeHandler
    {
        [SubscribeMessage("update:logininfo")]
        public void UpdateUserLoginInfo(string eventId, object payload)
        {
        }

        /// <summary>
        ///访问日志
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="payload"></param>
        [SubscribeMessage("create:oplog")]
        public void CreateOpLog(string eventId, object payload)
        {
            Console.WriteLine(payload.ToString());
        }

        [SubscribeMessage("create:exlog")]
        public void CreateExLog(string eventId, object payload)
        {
            // 这里解析服务
            //SysLogEx log = (SysLogEx)payload;
            //Scoped.Create((_, scope) =>
            //{
            //    var services = scope.ServiceProvider;

            //    var _db = App.GetService<ISqlSugarClient>(services);   // services 传递进去
            //    _db.Insertable(log).ExecuteCommand();
            //});
        }


    }
```

#### 最后注册服务

```csharp
public void ConfigureServices(IServiceCollection services)
        {
            services.AddSimpleEventBus();
        }
```

### 测试

![在这里插入图片描述](https://img-blog.csdnimg.cn/6f12b7c5ac3c4985bf076bc67861f9a2.png)
![在这里插入图片描述](https://img-blog.csdnimg.cn/9b38d25572024d8bb2cad8a87fab7275.png)

```csharp

MessageCenter.Send("create:oplog","hello word!");
```

![我的公众号](https://img-blog.csdnimg.cn/20210517111144223.png)
