using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetAll();
        void Create(CreateArticleModel model);
        void Edit(EditArticleModel model);

        EditArticleModel GetById(long id);

        void Remove(long id);
        void Restore(long id);
    }
}
