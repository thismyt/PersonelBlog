using Microsoft.EntityFrameworkCore;
using PersonelBlog.Data.Abstract;
using PersonelBlog.Entities.Concreate;
using PersonelBlog.Shared.Data.Concreate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Data.Concreate.EntityFramework.Contexts
{
    public class EFUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EFUserRepository(DbContext context) : base(context)
        {

        }
    }
}
