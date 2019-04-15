
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApi.Models;
using VideoApi.Services.Dto;


namespace VideoApi.Services
{
    public class VideoService : IVideoService
    {
        private readonly VideoContext _context;

        public VideoService(VideoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取所有视频
        /// </summary>
        /// <returns></returns>
        public async Task<List<VideoListDto>> GetAll()
        {

            var videos = await _context.Videos.Select(v => new VideoListDto
            {
                Id = v.Id,
                Name = v.Title,
                Image = v.Img
            }).ToListAsync();
            return videos;
        }

        /// <summary>
        /// 通过分页获取视频
        /// </summary>
        /// <param name="pageCurrent">pageCurrent</param>
        /// <param name="pageSize">pagSize</param>
        /// <returns></returns>
        public async Task<List<VideoListDto>> GetVideo(int pageCurrent,int pageSize)
        {
            
            if (pageCurrent <= 0)
                pageCurrent = 1;

            if (pageSize <= 0)
                pageSize = 30;

            // //每页尺寸
            // int pagSize = page.PagSize;
            int size=pageSize;
            // //当前页
            // int pageCurrent = page.PageCurrent-1;
            int page=pageCurrent-1;
            //总条数
            int count = _context.Videos.Count();

            var videos = await _context.Videos.Select(v => new VideoListDto
            {
                Id = v.Id,
                Name = v.Title,
                Image = v.Img,
                Url=v.Url
            }).Skip(page* size).Take(size).ToListAsync();

            return videos;
        }

        /// <summary>
        /// 通过Id获取视频
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<VideoDto> GetVideoById(int Id)
        {
            var video = await _context.Videos.Where(x=>x.Id==Id).Select(v => new VideoDto
            {
                Url = v.Url
            }).FirstAsync();
            return video;
        }

        /// <summary>
        /// 通过电影名搜索视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<VideoListDto>> Search(string input)
        {
            var videos = await _context.Videos.Where(x=>x.Title.Contains(input)).OrderByDescending(o=>o.CreateTime).Select(v => new VideoListDto
            {
                Id = v.Id,
                Name = v.Title,
                Image = v.Img,
                Url = v.Url
            }).ToListAsync();

            return videos;
        }
    }
}
