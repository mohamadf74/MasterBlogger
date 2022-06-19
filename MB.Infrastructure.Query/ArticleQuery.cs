using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x=>x.Comments)
                .Include(x=>x.ArticleCategory)
                .Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CommentCount = x.Comments.Count(z=>z.Status==Statuses.Confirmed)

            }).ToList();
        }

        public ArticleQueryView Get(long id)
        {
            return _context.Articles.Include(x=>x.Comments).Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Content = x.Content,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Title =x.Title,
                CommentCount = x.Comments.Count(y=>y.Status==Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(z=>z.Status==Statuses.Confirmed))
                
            }).FirstOrDefault(x => x.Id == id);

        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(x => new CommentQueryView
            {
                Name = x.Name,
                Message = x.Message,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
            }).ToList();

        }
    }
}