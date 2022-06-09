using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ArticleCategoryCreateModel : PageModel
    {
        

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ArticleCategoryCreateModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(CreateArticleCategoryModel model)
        {
            _articleCategoryApplication.Create(model);
            return RedirectToPage("./ArticleCategoryList");
        }
    }
}
