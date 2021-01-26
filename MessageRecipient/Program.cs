using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MessageRecipient
{
    class Program
    {
        /// <summary>
        /// 消息消费者（后台处理方法）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Start Send Msg");
            //创建连接工厂
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "wathet",
                Password = "wathet2018",
                HostName = "106.14.150.184"
            };
            //创建连接
            var connection = factory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();

            //接收到的消息处理事件
            EventingBasicConsumer Recipient = new EventingBasicConsumer(channel);
            Recipient.Received += (ch, ea) =>
            {
                var RecipientMsg = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($"后台处理方法收到消息：{RecipientMsg}");
                //确认该消息已被处理
                channel.BasicAck(ea.DeliveryTag, false);
                Console.WriteLine($"消息已经处理【{ea.DeliveryTag}】");
            };
            //channel.BasicConsume("QT.UAT.Wathet.ExternalAPI.Visit", false, Recipient);
            channel.BasicConsume("Wathet.Park.PV", false, Recipient);
            Console.WriteLine("后台处理方法已启动");
            Console.ReadKey();
            channel.Dispose();
            connection.Close();


        }
    }
}
