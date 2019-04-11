using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApi.Models;

namespace VideoApi
{
    public class VideoContext : DbContext
    {
        public VideoContext(DbContextOptions<VideoContext> options)
            : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<AnalysisUrl> AnalysisUrls { get; set; }
    }
}
