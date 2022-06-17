using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidateService:IArticleValidateService
    {

        private readonly IArticleRepository _articleRepository;

        public ArticleValidateService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleRepository.IsExist(title))
            {
                throw new Exception();
            }   
        }
    }
}
