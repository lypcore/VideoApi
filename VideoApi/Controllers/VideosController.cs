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
        /// <param name="pageCurrent"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("~/api/GetVideo")]
        public async Task<List<VideoListDto>> GetVideo(int pageCurrent,int pageSize)
        {
            var videos = await _videoService.GetVideo(pageCurrent,pageSize);
            return videos;
        }

        /// <summary>
        /// 获取视频播放地址
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("~/api/GetOnUrl")]
        public async Task<VideoDto> GetOnUrl(int value)
        {
            var video = await _videoService.GetVideoById(value);
            return video;
        }

        /// <summary>
        /// 通过电影名搜索视频
        /// </summary>
        /// <param name="input">电影名字</param>
        /// <returns></returns>
        [HttpGet("~/api/Search")]
        public async Task<List<VideoListDto>> Search(string input)
        {
            var videos = await _videoService.Search(input);
            return videos;
        }
    }
}
