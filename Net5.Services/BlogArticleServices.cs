using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net5.IServices;
using Net5.Model.Models;
using Net5.Repository.Base;

namespace Net5.Services
{
    public class BlogArticleServices : BaseServices<BlogArticle>, IBlogArticleServices
    {
        IBaseRepository<BlogArticle> dal;
        public BlogArticleServices(IBaseRepository<BlogArticle>  dal)
        {
            this.dal = dal;
            //base.baseDal = dal;
        }

        public async Task<List<BlogArticle>> getBlogs()
        {
            //var bloglist = await dal.Query(a => a.bID > 0, a => a.bID);
            var bloglist = new List<BlogArticle>();
            return bloglist;
        }
    }
}
