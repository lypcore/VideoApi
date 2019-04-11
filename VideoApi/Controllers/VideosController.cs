using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VideoApi.Models;
using VideoApi.Services;
using VideoApi.Services.Dto;

namespace VideoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly VideoService _videoService;

        public VideosController(VideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// 获取全部视频
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/api/GetAll")]
        public async Task<List<VideoListDto>> GetAll()
        {
            var videos = await _videoService.GetAll();
            return videos;
        }

        /// <summary>
        /// 通过分页获取视频
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost("~/api/GetVideo")]
        public async Task<List<VideoListDto>> GetVideo([FromBody] PageModel page)
        {
            var videos = await _videoService.GetVideo(page);
            return videos;
        }

        /// <summary>
        /// 获取视频播放地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("~/api/GetOnUrl")]
        public async Task<VideoDto> GetOnUrl([FromBody] VideoIdDto value)
        {
            var video = await _videoService.GetVideoById(value);
            return video;
        }

        /// <summary>
        /// 通过电影名搜索视频
        /// </summary>
        /// <param name="input">电影名字</param>
        /// <returns></returns>
        [HttpPost("~/api/Search")]
        public async Task<List<VideoListDto>> Search([FromBody] VideoSearchInput input)
        {
            var videos = await _videoService.Search(input);
            return videos;
        }
    }
}
