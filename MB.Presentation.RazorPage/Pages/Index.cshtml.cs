using System.Collections.Generic;
using System.Linq;
using MB.Application.Contracts.Article;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> Articles { get; set; }
        private readonly IArticleQuery _query;

        public IndexModel(IArticleQuery query)
        {
            _query = query;
        }

        public void OnGet()
        {
            Articles = _query.GetArticles();
        }
    }
}