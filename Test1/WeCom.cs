using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class WeCom
    {
        public static string weComCId = "ww2b6ab28532bb0bf8";//企业Id①
        public static string weComSecret = "EbKnQqG2y1qAVNL42bz7qEYY3jNP3Ys3A17Jnha6lAE"; //应用secret②
        public static string weComAId = "1000002"; //应用ID③
        public static string weComTouId = "@all"; 
     

        /// <summary>
        /// 发送微信通知
        /// </summary>
        /// <param name="text">消息</param>
        /// <returns></returns>
        public string SendToWeCom(string text)
        {
            // 获取Token
            string getTokenUrl = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={weComCId}&corpsecret={weComSecret}";
            string token = JsonConvert.DeserializeObject<dynamic>(new RestClient(getTokenUrl)
            .Get(new RestRequest()).Content).access_token;
            System.Console.WriteLine(token);
            if (!String.IsNullOrWhiteSpace(token))
            {
                var request = new RestRequest();
                var client = new RestClient($"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={token}");
                var data = new
                {
                    touser = weComTouId,
                    agentid = weComAId,
                    msgtype = "text",
                    text = new
                    {
                        content = text
                    },
                    duplicate_check_interval = 600
                };
                string serJson = JsonConvert.SerializeObject(data);
                System.Console.WriteLine(serJson);
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.Parameters.Clear();
                request.AddParameter("application/json", serJson, ParameterType.RequestBody);
                return client.Execute(request).Content;
            }
            return "-1";
        }
    }
}
