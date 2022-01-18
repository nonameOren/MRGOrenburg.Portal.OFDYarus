using System;

namespace MRG.OFDYarus.Api.Exceptions
{
    public class OfdException : Exception
    {
        public virtual string Code { get; set; }

        public OfdException(int code, string message) : base(message)
        {
            Code = code.ToString();
        }
        public OfdException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
