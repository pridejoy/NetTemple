using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zhaoke.Mvc.CodeDemo.Controllers
{
    public class FirstController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns>传值方式案例</returns>
        public IActionResult Index()
        {
            base.TempData["u1"] = "this is tempdata[u1]";
            base.ViewBag.u2 = "this is viewbag.u2";
            base.ViewData["u3"] = "this is ViewData[u3]";
            string data = "this is string data";
            // 1. 引用 using Microsoft.AspNetCore.Http;
            // 2. 传值  base.HttpContext.Session.SetString("u4", "this is a session");
            // 3. 注册中间件          services.AddSession();              app.UseSession();
            // 4. mvc 页面引用
            base.HttpContext.Session.SetString("u4", "this is a session");
            return View("Index", data);
        }
    }
}
