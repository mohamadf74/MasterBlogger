﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<Article> GetAll()
        {
            return _context.Articles.ToList();
        }
    }
}
