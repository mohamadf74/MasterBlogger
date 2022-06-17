﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Content { get;private set; }
        public string Title { get;private set; }
        public string ShortDescription { get;private set; }
        public DateTime CreationDate { get;private set; }
        public string Image { get;private set; }
        public bool IsDeleted { get;private set; }

        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }

        public Article(string title,string content, string shortDescription, string image,long articleCategoryId)
        {
            Title = title;
            CreationDate=DateTime.Now;
            Content = content;
            ShortDescription = shortDescription;
            Image = image;
            IsDeleted = false;
            ArticleCategoryId= articleCategoryId;
        }

        public void Edit(string title, string content, string shortDescription, string image, long articleCategoryId)
        {
            Title= title;
            Content= content;
            ShortDescription= shortDescription;
            Image= image;
            ArticleCategoryId=articleCategoryId;
        }

        protected Article()
        {
            
        }
    }
}
