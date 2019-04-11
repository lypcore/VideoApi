using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApi.Services.Dto
{
    public class VideoListDto
    {
        /// <summary>
        /// 视频编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 视频名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 视频图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 视频链接
        /// </summary>
        public string Url { get; set; }
    }
}
