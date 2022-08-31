using System;

namespace CiberNiteco.Core
{
    public class CiberNitecoException : Exception
    {
        public CiberNitecoException(string message = null, string code = null) : base(message)
        {
            Code = code;
        }

        public string Code { get; }
    }
}