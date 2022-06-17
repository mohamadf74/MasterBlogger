 using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.ArticleManagement
{
    public class ArticleListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        private readonly IArticleApplication _articleApplication;

        public ArticleListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetAll();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
           return RedirectToPage("./ArticleList");

        }

        public RedirectToPageResult OnPostRestore(long id)
        {
            _articleApplication.Restore(id);
            return RedirectToPage("./ArticleList");
        }
    }
}
