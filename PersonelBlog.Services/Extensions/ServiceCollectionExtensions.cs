using Microsoft.Extensions.DependencyInjection;
using PersonelBlog.Data.Abstract;
using PersonelBlog.Data.Concreate.EntityFramework;
using PersonelBlog.Data.Concreate.EntityFramework.Contexts;
using PersonelBlog.Services.Abstract;
using PersonelBlog.Services.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<PersonelBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }

    }
}
