using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Net5.Model.Models
{
    //BlogArticle 的实体类
    public class BlogArticle
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// 这里之所以没用RootEntity，是想保持和之前的数据库一致，主键是bID，不是Id
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int bID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string bsubmitter { get; set; }

        /// <summary>
        /// 标题blog
        /// </summary>
        [SugarColumn(Length = 256, IsNullable = true)]
        public string btitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string bcategory { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDataType = "text")]
        public string bcontent { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int btraffic { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int bcommentNum { get; set; }

        /// <summary> 
        /// 修改时间
        /// </summary>
        public DateTime bUpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime bCreateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string bRemark { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }

    }
}
