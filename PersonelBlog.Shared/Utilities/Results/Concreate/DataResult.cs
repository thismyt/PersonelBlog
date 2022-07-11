using PersonelBlog.Shared.Utilities.Result.Abstract.ComplexTypes;
using PersonelBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlog.Shared.Utilities.Results.Concreate
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultStatus resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string messages, T data)
        {
            ResultStatus = resultStatus;
            Messages = messages;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string messages, T data, Exception exception)
        {
            ResultStatus = resultStatus;
            Messages = messages;
            Data = data;
            Exception = exception;
        }


        public ResultStatus ResultStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Messages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Exception Exception { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public T Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
