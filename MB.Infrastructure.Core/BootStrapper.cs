using System;
using MB.Application;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repositories;
using MB.Infrastructure.Query;
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
            services.AddTransient<IArticleApplication,ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleValidateService, ArticleValidateService>();
            services.AddTransient<IArticleQuery,ArticleQuery>();
            services.AddDbContext<MasterBloggerContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
