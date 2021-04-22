using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Zhaoke.Mvc.CodeDemo
{
    /// <summary>
    /// 全局异常拦截器
    /// </summary>
    public class CuExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result=new JsonResult(
                    
                    new
                    {
                        code=500,
                        mes="程序异常!"
                    });
            }
        }
    }
}
