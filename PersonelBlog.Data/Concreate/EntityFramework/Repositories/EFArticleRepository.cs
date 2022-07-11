using Microsoft.EntityFrameworkCore;
using PersonelBlog.Data.Abstract;
using PersonelBlog.Entities.Concreate;
using PersonelBlog.Shared.Data.Concreate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Data.Concreate.EntityFramework.Contexts
{
    public class EFArticleRepository : EfEntityRepositoryBase<Article>, IArticleRepository
    {
        public  EFArticleRepository(DbContext context) : base(context)
        {

        }
    }
}
