using VideoApi.Models;

namespace VideoApi.Services.Dto
{
    /// <summary>
    /// 搜索
    /// </summary>
    public class SearchVideo:PageModel
    {
        /// <summary>
        /// 电影名
        /// </summary>
        public string Title { get; set; }
    }
}
