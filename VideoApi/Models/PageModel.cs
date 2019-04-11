using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApi.Models
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PagSize { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageCurrent { get; set; }
    }
}
