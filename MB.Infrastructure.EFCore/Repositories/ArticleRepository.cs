using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles.Include(x=>x.ArticleCategory).Select(x=>new ArticleViewModel
            {
                Title = x.Title,
                Id = x.Id,
                ArticleCategory = x.ArticleCategory.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(),
            }).ToList();
        }

        public void Create(Article model)
        {
            _context.Articles.Add(model);
            SaveChanges();
            

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
