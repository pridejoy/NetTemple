自从学习.NET 以来，优雅的编程风格，极度简单的可扩展性，足够强大开发工具，极小的学习曲线，让我对这个平台产生了浓厚的兴趣，在工作和学习中也积累了一些开源的组件，就目前想到的先整理于此，如果再想到，就继续补充这篇日志，日积月累，就能形成一个自己的组件经验库。

## 分布式缓存框架：

Microsoft Velocity：微软自家分布式缓存服务框架。

Memcahed：一套分布式的高速缓存系统，目前被许多网站使用以提升网站的访问速度。

Redis：是一个高性能的 KV 数据库。 它的出现很大程度补偿了 Memcached 在某些方面的不足。

EnyimMemcached：访问 Memcached 最优秀的.NET 客户端，集成不错的分布式均衡算法。

## 开源的.NET 系统推荐：

OXITE：微软 ASP.NET MVC 案例演示框架。

PetShop：微软 ASP.NET 宠物商店。

Orchard：国外一个 MVC 开源的博客系统。

SSCLI：微软在 NET Framework 2.0 时代的开源代码。

DasBlog：国外一个基于 ASP.NET 的博客系统。

BlogEngine.NET：国外一款免费开源的博客系统。

Dotnetnuke.NET：一套非常优秀的基于 ASP.NET 的开源门户网站程序。

Discuz.NET：国内开源的论坛社区系统。

nopCommerce 和 Aspxcommerce：国外一套高质量的开源 B2C 网站系统。

JumboTCMS 和 DTCMS：国内两款开源的网站管理系统：

## 日志记录异常处理：

Log4Net.dll：轻量级的免费开源.NET 日志记录框架。

Enterprise Library Log Application Black：微软企业库日志记录。

Elmah：实现最流行的 ASP.NET 应用异常日志记录框架。

NLog：是一个简单灵活的日志记录类库，性能比 Log4Net 高，使用和维护难度低。

## 关于 NoSQL 数据库：

Mongodb：分布式文件存储数据库。

Membase：家族的一个新的重量级的成员。

## 自动任务调度框架

Quartz.NET：开源的作业调度和自动任务框架。

Topshelf：另一种创建 Windows 服务的开源框架

## 依赖注入 IOC 容器框架：

Unity：微软 patterns&practicest 团队开发的 IOC 依赖注入框架，支持 AOP 横切关注点。

MEF（Managed Extensibility Framework）：是一个用来扩展.NET 应用程序的框架，可开发插件系统。

Spring.NET：依赖注入、面向方面编程(AOP)、数据访问抽象,、以及 ASP.NET 集成。

Autofac：最流行的依赖注入和 IOC 框架，轻量且高性能，对项目代码几乎无任何侵入性。

PostSharp：实现静态 AOP 横切关注点，使用简单，功能强大，对目标拦截的方法无需任何改动。

Ninject：基于.NET 轻量级开源的依赖注入 IOC 框架

## 常用的几个 ORM 框架：

EF（ADO.NET Entity Framework）：微软基于 ADO.NET 开发的 ORM 框架。

Nhibernate：面向.NET 环境的轻量级的 ORM 框架。

SqlMapper.cs：用于小项目的通用的 C#数据库访问类。

AutoMapper：流行的对象映射框架，可减少大量硬编码，很小巧灵活，性能表现也可接受。

SubSonic：优秀的开源的 ORM 映射框架，同时提供符合自身需要的代码生成器。

FluentData：开源的基于 Fluent API 的链式查询 ORM 轻量级框架。

Dapper：轻量级高性能基于 EMIT 生成的 ORM 框架。

EmitMapper：性能较高的 ORM 框架，运行时通过 EMIT 动态生成 IL 代码，并非采用反射机制。

## 格式和数据类型转换

Newtonsoft.Json：目前.NET 开发中最流行的 JSON 序列化库，为新版的 WebApi 库提供基础。

System.JSON.dll：微软自己开发的 JSON 序列化组件（需要单独下载）

DataContractJsonSerializer 和 DataContractXmlSerializer：微软在 WCF 中使用的序列化器。

JavaScriptSerializer：微软默认针对 WEB 开发者提供的 JSON 格式化器。

iTextSharp、PDFsharp 和 PDF.NET：通过.NET 处理和生成 PDF 文档的组件。

SharpZipLib.dll：免费开源的 ZIP 和 GZIP 文件解压缩组件。

Math.NET：强大的数学运算、微积分、解方程和科学运算。

DocX：不需要安装 word 软件，通过 C#操作 word 文件。

SharpSerializer：开源 XML 和、二进制、JSON、压缩和优化框架。

## 反射和动态语言

Clay dynamic：开源的动态语言 dynamic 框架让您形如 javascript 的方式创建对象。

ExposedObject：在类的外部通过动态语言 dynamic 的方式访问私有成员。

PrivateObject：微软单元测试框架中便捷在外部调用类内部私有成员的一个类。

## 跨平台和运行时解决方案

MONO.NET：跨平台的.NET 运行环境，让.NET 跨平台运行成为可能。

DotGnu Portable.NET：类似于 MONO.NET 的跨平台运行时。

Phalanger：将 PHP 编译成.NET，可实现 PHP 与.NET 互操作。

VMDotNet：中国移动飞信所使用过的.NET 运行时。

Unity3D：微软大力支持的机遇 C#和 JavaScript 的跨平台游戏开发框架。

Cassini、IIS Express 和 Cassinidev：开源的 ASP.NET 执行环境。

Katana：微软基于 OWIN 规范实现的非 IIS 寄宿 ASP.NET 和 MVC 等。

IKVM.NET：基于.NET 的 JAVA 虚拟机，让 JAVA 运行在.NET 之上。

## WEB 开发和设计

Jumony Core：基于.NET 开发的 HTML 引擎。

Microsoft.mshtml.dll、Winista.HtmlParser.dll 和 HtmlAgilityPack.dll：解析处理 HTML 文档的框架。

JavaScript.NET 和 ClearScript（微软出品）：基于.NET 开发的 JavaScript 引擎。

NCrawler：其 HTML 处理引擎 htmlagilitypack 的的开源网络爬虫软件。

AntiXSS：微软官方预防跨站 XSS 脚本入侵攻击的开源类库，它通过白名单机制进行内容编码。

YUICompressor.NET、Microsoft Ajax Minifier 和 Google Closure Compiler：JavaScrip 和 CSS 压缩器。

NancyFx：是一个不错的轻量级开源.NET WEB 框架。如果想快速做个简单的 WEB 应用。

AspNetPager：国内知名的 ASP.NET 分页控件，支持多种分页方式。

NOPI.dll：导出 Excel 报表的插件（基于微软 OpenXml 实现）（nopi.css.dl 通过 css 设置样式）

Enterprise Library：微软针对企业级应用开发的最佳实践组件。

PowerCollections：国外一个牛人写的高级开源集合。

## 移动互联网和云计算

PushSharp：通过.NET 向各种移动平台推送消息。

mono for android：用.NET 语言开发安卓应用：

MonoTouch：用.NET 语言开发 IOS 应用。

PhoneGap 和 AppCan：跨平台基于 HTML5 的移动开发平台。

Cordova：PhoneGap 贡献给 Apache 后的开源项目，是驱动 PhoneGap 的核心引擎。

## 网络通信和网络协议

SuperSocket：基于.NET 轻量级的可扩展的 Socket 开发框架。

SuperWebSocket：通过.NET 实现 TML5 WebSocket 框架。

XProxy：支持插件的基础代{过}{滤}理程序集，内置 NAT、加解密、反向、直接和间接代{过}{滤}理。

## 图形和图像处理框架

Paint.NET：基于.NET 小巧灵活强大的图形处理开源项目。

Imagemagick.NET：用 C#对开源图像处理组件 Imagemagick 的封装。

Skimpt：基于.NET 开源的屏幕截图软件。

ImageGlue.NET：商业的图像处理组件，支持的格式列了一大堆。

Sprite and Image Optimization Framework：微软 CSS 精灵，多图合成一张大图和 CSS 样式。

## 桌面应用程序框架

DevExpress：一个全球知名的桌面应用程序 UI 控件库。

Prism：微软开发的针对 WPF 和 Silverlight 的 MVVM 框架，通过功能模块化的思想，来讲复杂的业务功能和 UI 耦合性进行分离。

WPFToolkit 和 Fluent Ribbon Control Suite：开发类似于 Office 风格的 Ribbon 菜单。

## 测试和性能评估方面

Faker.Net：方便生成大批量测试数据的框架。

Nunit：一个轻量级的单元测试框架。

Moq：非常流行的 Mock 框架，支持 LINQ，灵活且高性能。

xUnit：比 NUnit 更好的单元测试框架，升级改进版的 Nunit 框架。

MiniProfiler 和 Glimpse：基于 MVC 的两款性能事件监控框架。

## 事务和分布式事务支持

KtmIntegration：一个支持 NTFS 文件系统的事务开源类。

NET Transactional File Manager：对文件系统操作（复制、移动和删除）加入事务支持。

## 分词、全文检索和搜索引擎

Lucene.net：流行高性能的全文索引库，可用于为各类信息提供强大的搜索功能。

Lucene.Net.Analysis.PanGu：支持 Lucene.Net 最新版的盘古中文分词扩展库。

## 数据验证组件整理

FluentValidation for .NET：基于 LINQ 表达式方法链 Fluent 接口验证组件。

Microsoft.Practices.EnterpriseLibrary.Validation.dll：微软企业库验证程序块。

CuttingEdge.Conditions：基于 Fluent 接口方法练接口的契约编程组件。

DotNetOpenAuth：让网站具备支持 OpenID、OAuth、InfoCard 等身份验证的能力。

## 开源图表统计控件：

Visifire：一套效果非常好的 WPF 图表控件，支持 3D 绘制、曲线、折线、扇形、环形和梯形。
SparrowToolkit：一套 WPF 图表控件集，支持绘制动态曲线，可绘制示波器、CPU 使用率和波形。
DynamicDataDisplay：微软开源的 WPF 动态曲线图，线图、气泡图和热力图。

更多内容：https://hunji.xyz/
