using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    internal class ArticleCategoryMapping:IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);
        }
    }
}
