
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Pages

{
    public class ArticleDetailsModel : PageModel
    {
        
        private readonly IArticleQuery _query;

        public ArticleQueryView Article { get; set; }
        public ArticleDetailsModel(IArticleQuery query)
        {
            _query = query;
        }

        public void OnGet(long id)
        {
            Article = _query.Get(id);
        }


    }
}