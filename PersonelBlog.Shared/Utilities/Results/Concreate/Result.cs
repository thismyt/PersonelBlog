using PersonelBlog.Shared.Utilities.Result.Abstract;
using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Shared.Utilities.Results.Concreate
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resultStatus, string messages)
        {
            ResultStatus = resultStatus;
            Messages = messages;           
        }
        public Result(ResultStatus resultStatus, string messages, Exception exception)
        {
            ResultStatus = resultStatus;
            Messages = messages;
            Exception = exception;
        }

        public ResultStatus ResultStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Exception Exception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
