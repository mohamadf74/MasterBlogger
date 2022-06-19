using System;
using System.Collections.Generic;
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
    }
}
