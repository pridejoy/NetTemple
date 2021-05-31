using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Net5.Extensions.Helper;

namespace Net5.Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string get()
        {
            return "张三";
        }

        /// <summary>
        /// SystemOrAdmin 可以获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "SystemOrAdmin")]
        public ActionResult<IEnumerable<string>> GetSystemOrAdmin()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// System 可以获取
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Client")]
        public ActionResult<IEnumerable<string>> GetClient()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet]
        [Authorize(Policy = "Admin")]
        public ActionResult<IEnumerable<string>> GetAdmin()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public async Task<object> GetJwtStr(string name, string pass)
        {
            // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
            TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = "Admin" };
            var jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
            var suc = true;
            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }


        
    }

    //public class TokenModelJwt
    //{
    //    public int Uid { get; set; }
    //    public string Role { get; set; }
    //}
}
