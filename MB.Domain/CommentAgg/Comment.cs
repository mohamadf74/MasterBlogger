using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }
        public int Status { get; set; }//new = 0, confirmed=1 , canceled=2
        public Comment(string name, string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate=DateTime.Now;
            Status = Statuses.New;

        }

        protected Comment()
        {
            
        }

        public void Confirm()
        {
            Status = Statuses.Confirmed;
        }

        public void Cancel()
        {
            Status = Statuses.Canceled;
        }
    }
}
