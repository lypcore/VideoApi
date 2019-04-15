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
        /// <param name="pageCurrent">分页信息</param>
         /// <param name="pageSize">分页信息</param>
        /// <returns></returns>
        Task<List<VideoListDto>> GetVideo(int pageCurrent,int pageSize);

        /// <summary>
        /// 通过Id获取视频
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<VideoDto> GetVideoById(int Id);

        /// <summary>
        /// 搜索视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<VideoListDto>> Search(string input);

    }
}
