using System;

namespace MRG.OFDYarus.Api.Exceptions
{
    public class AppException : Exception
    {
        public virtual string Code { get; }

        public AppException(string message) : base(message)
        {
            Code = "error";
        }
    }
}
