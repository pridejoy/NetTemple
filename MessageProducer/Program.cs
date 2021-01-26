using RabbitMQ.Client;
using System;
using System.Text;

namespace MessageProducer
{
    class Program
    {
        /// <summary>
        /// 消息生产者（消费用户）
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
            //声明一个队列
            Console.WriteLine($"声明一个队列;Wathet.Park.PV");
            channel.QueueDeclare("Wathet.Park.PV", false, false, false, null);

            Console.WriteLine("\nRabbitMQ连接成功，请输入消息，输入exit退出！");
            string msg;
            for (int i = 0; i < 1000000000000000; i++)
            {
                var sendbytes = Encoding.UTF8.GetBytes(i.ToString());
                Console.WriteLine($"发送消息:{i}");
                channel.BasicPublish("", "Wathet.Park.PV", null, sendbytes);
            }
            do
            {
                msg = Console.ReadLine();
                var sendbytes = Encoding.UTF8.GetBytes(msg);

                channel.BasicPublish("", "Wathet.Park.PV", null, sendbytes);
            } while (!msg.Trim().ToLower().Equals("exit"));
            channel.Close();
            connection.Close();
            Console.WriteLine("End Msg");
        }
    }
}
