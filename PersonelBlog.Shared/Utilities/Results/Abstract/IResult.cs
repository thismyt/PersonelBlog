using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Shared.Utilities.Result.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; set; }
        public string Messages { get; set; }
        public Exception Exception { get; set; }
    }
}
