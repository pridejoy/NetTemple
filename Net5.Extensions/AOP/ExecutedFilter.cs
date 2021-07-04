using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Extensions.AOP
{
    public class ExecutedFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 业务程序处理完成之后
        /// </summary>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //var User = Wathet.Operation.User.Login.CurrentUser();
            ////执行到此处说明,控制器的Action已经执行完成,有可能有报错 Code:500. 但是一定会走这个方法
            //SavePV(
            //    context,
            //    User != null ? User.id : 0,
            //    User != null ? User.codeNo : string.Empty,
            //    User != null ? User.loginName : string.Empty,
               
            //);
            Console.WriteLine(context.Canceled);

            if (context.Exception != null)
            {
                var ex = context.Exception;
                context.Exception = null; //隐藏异常内容
                context.ExceptionDispatchInfo = null;
                context.ExceptionHandled = true;  //修改程序为已经处理
            }
        }
    }
}
