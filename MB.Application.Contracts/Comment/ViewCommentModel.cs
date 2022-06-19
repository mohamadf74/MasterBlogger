using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Comment
{
    public class ViewCommentModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public string CreationDate { get; set; }
        public string Article { get; set; }
    }
}
