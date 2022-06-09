using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore
{
    public class MasterBloggerContext:DbContext
    {

        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options):base(options)
        {
            
        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
