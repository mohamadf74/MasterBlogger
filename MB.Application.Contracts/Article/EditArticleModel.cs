using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Article
{
    public class EditArticleModel : CreateArticleModel
    {
        public long Id { get; set; }
    }
}
