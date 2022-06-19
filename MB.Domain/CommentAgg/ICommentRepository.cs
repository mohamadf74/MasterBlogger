﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);

        List<Comment> GetComments();

        void SaveChanges();
    }
}
