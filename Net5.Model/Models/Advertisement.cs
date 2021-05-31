using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Net5.Model.Models
{
    public class Advertisement
    {

        /// <summary>
        /// 广告图片
        /// </summary>
        [SugarColumn(Length = 512, IsNullable = true, ColumnDataType = "nvarchar")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 广告标题
        /// </summary>
        [SugarColumn(Length = 64, IsNullable = true, ColumnDataType = "nvarchar")]
        public string Title { get; set; }

        /// <summary>
        /// 广告链接
        /// </summary>
        [SugarColumn(Length = 256, IsNullable = true, ColumnDataType = "nvarchar")]
        public string Url { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = 2000, IsNullable = true, ColumnDataType = "nvarchar")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createdate { get; set; } = DateTime.Now;
    }
}
