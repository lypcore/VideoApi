using System.Collections.Generic;
using System.Threading.Tasks;
using VideoApi.Models;
using VideoApi.Services.Dto;

namespace VideoApi.Services
{
    public interface IVideoService
    {
        /// <summary>
        /// 获取所有视频
        /// </summary>
        /// <returns></returns>
        Task<List<VideoListDto>> GetAll();

        /// <summary>
        /// 通过分页获取视频
        /// </summary>
        /// <param name="page">分页信息</param>
        /// <returns></returns>
        Task<List<VideoListDto>> GetVideo(PageModel page);

        /// <summary>
        /// 通过Id获取视频
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<VideoDto> GetVideoById(VideoIdDto dto);

        /// <summary>
        /// 搜索视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<VideoListDto>> Search(VideoSearchInput input);

    }
}
