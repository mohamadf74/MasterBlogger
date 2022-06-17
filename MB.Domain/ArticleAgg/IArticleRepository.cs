using System.Collections.Generic;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetAll();
        void Create (Article model);
        void SaveChanges();

        Article GetById (long id);

        bool IsExist(string title);
    }
}
