using System;
using System.Collections.Generic;
using System.Linq;

namespace VY.MenuActions.XCutting.Contracts
{
    public class OperationResult
    {
        public List<ErrorObject> Errors { get; set; } = new List<ErrorObject>();

        public void AddError(int code, string message, Exception ex = null)
        {
            Errors.Add(new ErrorObject { Code = code, Message = message, Exception = ex });
        }
        public void AddError(ErrorObject error) => Errors.Add(error);
        public void AddError(Exception ex) => Errors.Add(new ErrorObject { Message = ex.Message, Exception = ex });
        public List<Exception> GetExceptions => Errors.Where(e => e.Exception != null).Select(e => e.Exception).ToList();
        public bool HasErrors => Errors.Count > 0;
        public bool HasExceptions => Errors.Any(e => e.Exception != null);
    }

    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }

        public void SetResult(T result) => Result = result;
    }
}
