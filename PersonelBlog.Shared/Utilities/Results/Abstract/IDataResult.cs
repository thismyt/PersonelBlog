using PersonelBlog.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; } 
    }
}
