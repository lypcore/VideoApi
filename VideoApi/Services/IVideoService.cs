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
        Task<CommonResults<VideoListDto>> GetAll();

        /// <summary>
        /// 通过分页获取视频
        /// </summary>
        /// <param name="page">分页</param>
        /// <returns></returns>
        Task<PcCommonResults<VideoListDto>> GetVideo(PageModel page);

        /// <summary>
        /// 通过Id获取视频Url
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<CommonResult<VideoDto>> GetOnPalyUrl(ById value);

        /// <summary>
        /// 搜索视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PcCommonResults<VideoListDto>> Search(SearchVideo input);

    }
}
