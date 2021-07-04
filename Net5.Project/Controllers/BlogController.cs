using Microsoft.AspNetCore.Mvc;
using Net5.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogDashboard.Extensions;
using Microsoft.Extensions.Logging;
using Net5.Extensions.AOP;
using Net5.IServices;


namespace Net5.Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ExecutedFilter]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> logger; // <-添加此行
        
        private readonly IAdvertisementServices _advertisementServices = null;
        public BlogController(IAdvertisementServices advertisementServices,ILogger<BlogController> logger)
        {
            _advertisementServices = advertisementServices;
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //IAdvertisementServices advertisementServices = new AdvertisementServices();
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<List<BlogArticle>> GetBlogs()
        {
            var a = new List<BlogArticle>();
            var b = new BlogArticle();
            b.IsDeleted = true;
            b.bCreateTime=DateTime.Now;
            b.bID = 1;
            b.bRemark = "qew";
            a.Add(b);
            logger.LogInformation("测试1"); // <-添加此行
            logger.LogInformation(a.ToJsonString()); // <-添加此行
            return a;

        }

        [HttpGet("{id}", Name = "Sum")]
        public int Sum(int i, int j)
        {
            return _advertisementServices.Sum(i, j);
        }

        [HttpPost]
        public int Add()
        {
            var a = new Advertisement();
            a.ImgUrl = "123";
            a.Title = "12312";
            a.Url = "123";
            a.Remark = "123";

            return _advertisementServices.Add(a);
        }

    }
}
