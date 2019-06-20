
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
        public async Task<CommonResults<VideoListDto>> GetAll()
        {
            var result = new CommonResults<VideoListDto>();
            try
            {
                var videos = await _context.Videos.Select(v => new VideoListDto
                {
                    Id = v.Id,
                    Name = v.Title,
                    Image = v.Img
                }).ToArrayAsync();

                result.scode = "200";
                result.remark = "查询数据成功";
                result.results = videos;
                return result;

            }
            catch (Exception ex)
            {
                result.scode = "500";
                result.remark = "服务器端错误:" + ex.Message;
                return result;
            }
        }

        /// <summary>
        /// 通过分页获取视频
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<PcCommonResults<VideoListDto>> GetVideo(PageModel page)
        {         
            var result = new PcCommonResults<VideoListDto>();
            try
            {
                var videoList = await _context.Videos.OrderByDescending(o => o.CreateTime).ToArrayAsync();
                if (page.ShowCount <= 0)
                    page.ShowCount = 30;

                if (page.Page <= 0)
                    page.Page = 1;

                // //每页尺寸
                int pagSize = page.ShowCount;
                // //当前页
                int pageCurrent = page.Page - 1;
                //总条数
                result.Count = videoList.Count();

                if (result.Count == 0)
                {
                    result.scode = "200";
                    result.remark = "查询数据成功";
                    result.results = null;
                    return result;
                }

                var videos = videoList.Select(v => new VideoListDto
                {
                    Id = v.Id,
                    Name = v.Title,
                    Image = v.Img
                }).Skip(pageCurrent * pagSize).Take(pagSize).ToArray();

                result.scode = "200";
                result.remark = "查询数据成功";
                result.results = videos;
            }
            catch (Exception ex)
            {
                result.scode = "500";
                result.remark = "服务器端错误:" + ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 通过Id获取视频Url
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<CommonResult<VideoDto>> GetOnPalyUrl(ById value)
        {           
            var result = new CommonResult<VideoDto>();
            try
            {
                var video = await _context.Videos.Where(x => x.Id == value.Id).FirstAsync();

                if (string.IsNullOrEmpty(video.Url))
                {
                    result.scode = "200";
                    result.remark = "查询数据成功";
                    result.result = null;

                    return result;
                }

                var analysisUrls = await _context.AnalysisUrls.ToArrayAsync();
                var analysisUrl = analysisUrls.OrderBy(x => Guid.NewGuid()).First();

                analysisUrl.PlayCount += 1;
                video.PlayCount += 1;

                _context.SaveChanges();

                VideoDto videoUrl = new VideoDto
                {
                    Url = analysisUrl.Url+video.Url
                };

                result.scode = "200";
                result.remark = "查询数据成功";
                result.result = videoUrl;
            }
            catch (Exception ex)
            {
                result.scode = "500";
                result.remark = "服务器端错误:" + ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 通过电影名搜索视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PcCommonResults<VideoListDto>> Search(SearchVideo input)
        {          
            var result = new PcCommonResults<VideoListDto>();
            try
            {
                var videoList = await _context.Videos.Where(x => x.Title.Contains(input.Title)).OrderByDescending(o => o.CreateTime).ToListAsync();

                if (input.ShowCount <= 0)
                    input.ShowCount = 30;

                if (input.Page <= 0)
                    input.Page = 1;

                // //每页尺寸
                int pagSize = input.ShowCount;
                // //当前页
                int pageCurrent = input.Page - 1;
  
                //总条数
                result.Count = videoList.Count;

                if (result.Count == 0)
                {
                    result.scode = "200";
                    result.remark = "查询数据成功";
                    result.results = null;
                    return result;
                }

                var videos = videoList.Select(v => new VideoListDto
                {
                        Id = v.Id,
                        Name = v.Title,
                        Image = v.Img
                });

                result.scode = "200";
                result.remark = "查询数据成功";
                result.results = videos.Skip(pageCurrent * pagSize).Take(pagSize).ToArray();

            }
            catch (Exception ex)
            {
                result.scode = "500";
                result.remark = "服务器端错误:" + ex.Message;
            }
            return result;
        }
    }
}
