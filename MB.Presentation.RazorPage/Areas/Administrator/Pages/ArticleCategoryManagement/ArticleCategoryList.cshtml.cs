using System.Collections.Generic;
using System.Linq;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ArticleCategoryListModel : PageModel
    {

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public ArticleCategoryListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.GetAll().ToList();
        }

        public IActionResult OnPostActivate(int id)
        {
            _articleCategoryApplication.Active(id);
            return RedirectToPage("./ArticleCategoryList");
        }
        
        public IActionResult OnPostDeActive(int id)
        {
            _articleCategoryApplication.DeActive(id);
            return RedirectToPage("./ArticleCategoryList");
        }
    }
}
