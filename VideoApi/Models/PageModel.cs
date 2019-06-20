using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApi.Models
{
    /// <summary>
    /// 分页公共参数
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 第几页 默认1
        /// </summary>
        /// <returns></returns>
        [Required]
        public int Page { get; set; }
        /// <summary>
        /// 每页显示多少条
        /// </summary>
        /// <returns></returns>
        [Required]
        public int ShowCount { get; set; }
    }
    /// <summary>
    ///     通用返回结果
    /// </summary>
    public class CommonResult
    {
        /// <summary>
        ///     状态码
        /// </summary>
        public string scode { get; set; }

        /// <summary>
        ///     备注信息
        /// </summary>
        public string remark { get; set; }
    }

    /// <summary>
    ///     包含单条结果的结果对象
    /// </summary>
    public class CommonResult<T> : CommonResult
    {
        /// <summary>
        ///     单条结果
        /// </summary>
        /// <returns></returns>
        public T result { get; set; }
    }

    /// <summary>
    ///     包含多条结果的结果对象
    /// </summary>
    public class CommonResults<T> : CommonResult
    {
        private T[] _results;
        /// <summary>
        ///     多条结果
        /// </summary>
        /// <returns></returns>
        public T[] results
        {
            get
            {
                if (_results == null)
                {
                    return new T[] { };
                }
                else
                {
                    return _results;
                }
            }
            set
            {
                _results = value;
            }
        }

    }

    /// <summary>
    ///     包含多条结果的结果对象 增加最后一页参数
    /// </summary>
    public class PageCommonResults<T> : CommonResult
    {
        private T[] _results;
        /// <summary>
        ///     多条结果
        /// </summary>
        /// <returns></returns>
        public T[] results
        {
            get
            {
                if (_results == null)
                {
                    return new T[] { };
                }
                else
                {
                    return _results;
                }
            }
            set
            {
                _results = value;
            }
        }
        /// <summary>
        ///   1 代表最后一页数据 0 还有数据加载
        /// </summary>
        public int lastpage { get; set; }
    }

    /// <summary>
    ///     包含多条结果的结果对象 增加最后一页参数
    /// </summary>
    public class PcCommonResults<T> : CommonResult
    {
        private T[] _results;
        /// <summary>
        ///     多条结果
        /// </summary>
        /// <returns></returns>
        public T[] results
        {
            get
            {
                if (_results == null)
                {
                    return new T[] { };
                }
                else
                {
                    return _results;
                }
            }
            set
            {
                _results = value;
            }
        }
        /// <summary>
        ///   总条数
        /// </summary>
        public long Count { get; set; }
    }
    /// <summary>
    ///     通用请求结构
    /// </summary>
    public class CommonRequest
    {
        /// <summary>
        ///     第几页
        /// </summary>
        public int Page;

        /// <summary>
        ///     每页条数
        /// </summary>
        public int PageSize;

        /// <summary>
        ///     查找的关键字
        /// </summary>
        public string Search;
    }
}