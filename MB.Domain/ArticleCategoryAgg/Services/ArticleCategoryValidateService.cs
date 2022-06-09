using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidateService:IArticleCategoryValidateService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidateService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.IsExist(title))
            {
                throw new DuplicatedRecordException("this record already is exist");
            }

            
        }
    }
}
