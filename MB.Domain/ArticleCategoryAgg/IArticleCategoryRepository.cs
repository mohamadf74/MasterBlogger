using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();


        void Create(ArticleCategory articleCategory);

      //  void Active(int id);
     //   void DeActive(int id);
    //    void Edit(long id,string Name);

        ArticleCategory GetById(long id);

        bool IsExist(string title);
        void SaveChanges();

    }
}
