using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public ArticleCategory(string title,IArticleCategoryValidateService Services)
        {
            Services.CheckThatThisRecordAlreadyExists(title);
            GuardAgainstEmptyTitle(title);
            Title = title;
            IsDeleted = false;
            CreationDate=DateTime.Now;
            Articles = new List<Article>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<Article> Articles { get; set; }

        public void Edit(string Name)
        {
            GuardAgainstEmptyTitle(Name);
            Title = Name;
        }

        public void Active()
        {
            IsDeleted = false;
        }

        public void DeActive()
        {
            IsDeleted = true;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception();
            }
        }
    }


}
