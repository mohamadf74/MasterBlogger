using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        void Create(AddCommentModel command);
        void Confirm(long id);
        void Cancel(long id);
        List<ViewCommentModel> GetComments();

        
    }
}
