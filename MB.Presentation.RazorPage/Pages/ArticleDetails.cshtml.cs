
using MB.Application.Contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Pages

{
    public class ArticleDetailsModel : PageModel
    {
        
        private readonly IArticleQuery _query;
        private readonly ICommentApplication _commentApplication;
        public ArticleQueryView Article { get; set; }
        public ArticleDetailsModel(IArticleQuery query, ICommentApplication commentApplication)
        {
            _query = query;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Article = _query.Get(id);
        }

        public IActionResult OnPost(AddCommentModel command)
        {
            _commentApplication.Create(command);
            return RedirectToPage("./ArticleDetails",command.ArticleId);
        }

    }
}