using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public void Create(CreateArticleModel model)
        {
            var article = new Article(model.Title, model.Content, model.ShortDescription, model.Image,
                model.CategoryId);
            _articleRepository.Create(article);
        }

        public void Edit(EditArticleModel model)
        {
            var article = _articleRepository.GetById(model.Id);
            article.Edit(model.Title,model.Content,model.ShortDescription,model.Image,model.CategoryId);
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
    }


}
