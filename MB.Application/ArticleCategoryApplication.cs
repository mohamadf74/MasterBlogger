using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidateService _articleCategoryValidateService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidateService articleCategoryValidateService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidateService = articleCategoryValidateService;
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return articleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(),
                IsDeleted = x.IsDeleted
            }).OrderBy(x => x.Id).ToList();

        }

        public void Create(CreateArticleCategoryModel model)
        {
            var articleCategory = new ArticleCategory(model.Name,_articleCategoryValidateService);
            _articleCategoryRepository.Create(articleCategory);
        }

        public void Active(int id)
        {
            var articleCategory=_articleCategoryRepository.GetById(id);
            articleCategory.Active();
            _articleCategoryRepository.SaveChanges();
        }

        public void DeActive(int id)
        {
            var articleCategory=_articleCategoryRepository.GetById(id);
            articleCategory.DeActive();
            _articleCategoryRepository.SaveChanges();
        }

        public void Edit(EditArticleCategoryModel model)
        {
            var articleCategory = _articleCategoryRepository.GetById(model.Id);
            articleCategory.Edit(model.Name);
            _articleCategoryRepository.SaveChanges();
        }

        public EditArticleCategoryModel GetById(int id)
        {
            var category = _articleCategoryRepository.GetById(id);
            return new EditArticleCategoryModel()
            {
                Id = category.Id,
                Name = category.Title,

            };
        }
    }
}
