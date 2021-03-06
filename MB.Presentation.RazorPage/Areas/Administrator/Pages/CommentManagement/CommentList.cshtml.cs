using System.Collections.Generic;
using MB.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.RazorPage.Areas.Administrator.Pages.CommentManagement
{
    public class CommentListModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;
        public List<ViewCommentModel> Comments { get; set; }

        public CommentListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.GetComments();
        }

        public IActionResult OnPostConfirm(long id)
        {
            _commentApplication.Confirm(id);
            return RedirectToPage("./CommentList");
        }

        public IActionResult OnPostCancel(long id)
        {
            _commentApplication.Cancel(id);
            return RedirectToPage("./CommentList");
        }
    }
}
