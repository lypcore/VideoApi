using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApi.Models
{
    /// <summary>
    /// 视频
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 视频编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 视频名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 视频链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 播放次数
        /// </summary>
        public int PlayCount { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public int IsRecommend { get; set; }
    }
}
