using PersonelBlog.Entities.Concreate;
using PersonelBlog.Shared.Entities.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
        

    }
}
