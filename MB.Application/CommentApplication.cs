using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _repository;

        public CommentApplication(ICommentRepository repository)
        {
            _repository = repository;
        }

        public void Create(AddCommentModel command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _repository.Create(comment);
        }

        public void Confirm(long id)
        {
            var comment = _repository.GetById(id);
            comment.Confirm();
            _repository.SaveChanges();
        }

        public void Cancel(long id)
        {
            var comment= _repository.GetById(id);
            comment.Cancel();
            _repository.SaveChanges();
            
        }

        public List<ViewCommentModel> GetComments()
        {
            return _repository.GetComments().Select(x => new ViewCommentModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                Article = x.Article.Title,
                Email = x.Email,
                Status = x.Status,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();
        }
    }
}
