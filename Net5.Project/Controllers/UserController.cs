using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Nito.AsyncEx;

namespace Net5.Project.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]/[action]")]
    public class UserController
    {

        private readonly AsyncLock _mutex = new AsyncLock();

        #region wx.login登陆成功之后发送的请求

        /// <summary>
        /// wx.login登陆成功之后发送的请求
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> OnLogin([FromBody] FMWxPost entity)
        {
            var jm = new WebApiCallBack();

            using (await _mutex.LockAsync())
            {
                //var jsonResult = await SnsApi.JsCode2JsonAsync(WxOpenAppId, WxOpenAppSecret, entity.code);
                //if (jsonResult.errcode == ReturnCode.请求成功)
                //{
                //    var sessionBag = await SessionContainer.UpdateSessionAsync(null, jsonResult.openid, jsonResult.session_key, jsonResult.unionid);
                //    var userInfo = await _userWeChatInfoServices.QueryByClauseAsync(p => p.openid == jsonResult.openid);
                //    if (userInfo == null)
                //    {
                //        userInfo = new CoreCmsUserWeChatInfo();
                //        userInfo.openid = jsonResult.openid;
                //        userInfo.type = (int)GlobalEnumVars.UserAccountTypes.微信小程序;
                //        userInfo.sessionKey = sessionBag.SessionKey;
                //        userInfo.gender = 1;
                //        userInfo.createTime = DateTime.Now;

                //        var id = await _userWeChatInfoServices.InsertAsync(userInfo);
                //    }

                //    if (userInfo is { userId: > 0 })
                //    {
                //        var user = await _userServices.QueryByClauseAsync(p => p.id == userInfo.userId);
                //        if (user != null)
                //        {
                //            var claims = new List<Claim> {
                //                new Claim(ClaimTypes.Name, user.nickName),
                //                new Claim(JwtRegisteredClaimNames.Jti, user.id.ToString()),
                //                new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString()) };

                //            //用户标识
                //            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                //            identity.AddClaims(claims);
                //            jm.status = true;
                //            jm.data = new
                //            {
                //                auth = JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement),
                //                user
                //            };
                //            jm.otherData = sessionBag.Key;
                //            //jm.methodDescription = JsonConvert.SerializeObject(sessionBag);

                //            //录入登录日志
                //            var log = new CoreCmsUserLog();
                //            log.userId = user.id;
                //            log.state = (int)GlobalEnumVars.UserLogTypes.登录;
                //            log.ip = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress != null ? _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString() : "127.0.0.1";
                //            log.createTime = DateTime.Now;
                //            log.parameters = GlobalEnumVars.UserLogTypes.登录.ToString();
                //            await _userLogServices.InsertAsync(log);

                //            return new JsonResult(jm);
                //        }
                //    }

                //    //注意：生产环境下SessionKey属于敏感信息，不能进行传输！
                //    //return Json(new { success = true, msg = "OK", sessionAuthId = sessionBag.Key, sessionKey = sessionBag.SessionKey, data = jsonResult, sessionBag = sessionBag });
                //    jm.status = true;
                //    jm.data = sessionBag.Key;
                //    jm.otherData = sessionBag.Key;
                //    //jm.methodDescription = JsonConvert.SerializeObject(sessionBag);
                //    jm.msg = "OK";
                //}
                //else
                //{
                //    jm.msg = jsonResult.errmsg;
                //}
            }


            return new JsonResult(jm);
        }
        #endregion
    }
    public class FMWxPost
    {
        /// <summary>
        ///     页面编码
        /// </summary>
        public string code { get; set; }
    }


    /// <summary>
    ///     微信接口回调Json实体
    /// </summary>
    public class WebApiCallBack
    {
        /// <summary>
        ///     请求接口返回说明
        /// </summary>
        public string methodDescription { get; set; }


        /// <summary>
        ///     提交数据
        /// </summary>
        public object otherData { get; set; } = null;

        /// <summary>
        ///     状态码
        /// </summary>
        public bool status { get; set; } = false;

        /// <summary>
        ///     信息说明。
        /// </summary>
        public string msg { get; set; } = "接口响应成功";

        /// <summary>
        ///     返回数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        ///     返回编码
        /// </summary>
        public int code { get; set; } = 0;
    }
}
