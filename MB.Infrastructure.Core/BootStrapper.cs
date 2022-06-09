using System;
using MB.Application;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication,ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository,ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidateService, ArticleCategoryValidateService>();
            services.AddDbContext<MasterBloggerContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
