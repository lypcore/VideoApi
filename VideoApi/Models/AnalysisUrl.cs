using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApi.Models
{
    /// <summary>
    /// 解析视频地址
    /// </summary>
    public class AnalysisUrl
    {
        /// <summary>
        /// 解析Url编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 解析地址链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 链接使用次数
        /// </summary>
        public int PlayCount { get; set; }
    }
}
