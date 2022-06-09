using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {

        private readonly MasterBloggerContext _context;

        

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.ToList();
        }

        public void Create(ArticleCategory model)
        {
            _context.ArticleCategories.Add(model);
            SaveChanges();
        }

        //public void Active(int id)
        //{
        //    var articleCategory=_context.ArticleCategories.FirstOrDefault(c => c.Id == id);
        //    articleCategory.Active();
        //    SaveChanges();
        //}

        //public void DeActive(int id)
        //{
        //    var articleCategory = _context.ArticleCategories.FirstOrDefault(c => c.Id == id);
        //    articleCategory.DeActive();
        //    SaveChanges();
        //}

        //public void Edit(long id,string name)
        //{
        //    var articleCategory = _context.ArticleCategories.FirstOrDefault(x => x.Id == id);   
        //    articleCategory.Edit(name);
        //    _context.SaveChanges();
        //}

        public ArticleCategory GetById(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public bool IsExist(string title)
        {
          return  _context.ArticleCategories.Any(x => x.Title == title);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
