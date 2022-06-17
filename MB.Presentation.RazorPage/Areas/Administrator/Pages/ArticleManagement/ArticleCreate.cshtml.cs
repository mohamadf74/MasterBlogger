using System.Collections.Generic;
using System.Linq;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleManagement
{
    public class ArticleCreateModel : PageModel
    {


        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;

        public ArticleCreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<SelectListItem> ArticleCategoriesItem { get; set; }
        public void OnGet()
        {
            ArticleCategoriesItem = _articleCategoryApplication.GetAll()
                .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }

        public IActionResult OnPost(CreateArticleModel model)
        {
            _articleApplication.Create(model);
            return RedirectToPage("./ArticleList");
        }
    }
}
