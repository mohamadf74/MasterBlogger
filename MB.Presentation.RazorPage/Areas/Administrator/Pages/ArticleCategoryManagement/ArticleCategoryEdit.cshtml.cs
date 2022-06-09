using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ArticleCategoryEditModel : PageModel
    {
        [BindProperty] public EditArticleCategoryModel ArticleCategory { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ArticleCategoryEditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
           ArticleCategory= _articleCategoryApplication.GetById(id);
        }

        public IActionResult OnPost()
        {
            _articleCategoryApplication.Edit(ArticleCategory);
            return RedirectToPage("./ArticleCategoryList");
        }
    }
}
