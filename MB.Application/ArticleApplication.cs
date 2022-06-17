using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidateService _articleValidateService;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidateService articleValidateService)
        {
            _articleRepository = articleRepository;
            _articleValidateService = articleValidateService;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticleModel model)
        {
            var article = new Article(model.Title, model.Content, model.ShortDescription, model.Image,
                model.CategoryId,_articleValidateService);
            _articleRepository.Create(article);
        }

        public void Edit(EditArticleModel model)
        {
            var article = _articleRepository.GetById(model.Id);
            article.Edit(model.Title,model.Content,model.ShortDescription,model.Image,model.CategoryId,_articleValidateService);
            _articleRepository.SaveChanges();

        }

        public EditArticleModel GetById(long id)
        {
           var article= _articleRepository.GetById(id);
           return new EditArticleModel
           {
               Id = article.Id,
               Title = article.Title,
               Content = article.Content,
               ShortDescription = article.ShortDescription,
               Image = article.Image,
               CategoryId = article.ArticleCategoryId
           };
        }

        public void Remove(long id)
        {
            var article=_articleRepository.GetById(id);
            article.Remove();
            _articleRepository.SaveChanges();
            
        }

        public void Restore(long id)
        {
            var article= _articleRepository.GetById(id);
            article.Restore();
            _articleRepository.SaveChanges();
        }
    }


}
