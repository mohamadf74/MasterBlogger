using System.Collections.Generic;
using System.Linq;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleManagement
{
    public class ArticleEditModel : PageModel
    {
        [BindProperty] public EditArticleModel Article { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<SelectListItem> ArticleCategories { get; set; }

        public ArticleEditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
           Article= _articleApplication.GetById(id);
           ArticleCategories = _articleCategoryApplication.GetAll()
               .Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();

        }

        public IActionResult OnPost()
        {
            _articleApplication.Edit(Article);

            return RedirectToPage("./ArticleList");
        }

    }
}
