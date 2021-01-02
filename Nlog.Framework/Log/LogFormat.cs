using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework.Log
{
    /// <summary>
    /// 格式化输出样式
    /// </summary>
    public class LogFormat
    {
        public static string ErrorFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("1. 操作时间: " + logMessage.OperationTime + " \r\n");
            strInfo.Append("2. 操作人: " + logMessage.OperationName + " \r\n");
            strInfo.Append("3. Ip  : " + logMessage.IpAddress + "\r\n");
            strInfo.Append("4. 错误内容: " + logMessage.LogInfo + "\r\n");
            strInfo.Append("5. 跟踪: " + logMessage.StackTrace + "\r\n");
            strInfo.Append("---------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}
