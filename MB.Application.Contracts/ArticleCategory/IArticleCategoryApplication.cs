using System;
using System.Collections.Generic;



namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> GetAll();
        void Create(CreateArticleCategoryModel model);
        void Active(int id);

        void DeActive(int id);

        void Edit(EditArticleCategoryModel model);

        EditArticleCategoryModel GetById(int id);
    }


}
