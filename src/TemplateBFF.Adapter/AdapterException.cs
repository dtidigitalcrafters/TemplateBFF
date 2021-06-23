using System;
using System.Runtime.Serialization;

namespace TemplateBFF.Adapter
{
    [Serializable]
    public class AdapterException : Exception
    {
        public AdapterException()
        {
        }

        public AdapterException(string message) : base(message)
        {
        }

        public AdapterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdapterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}




