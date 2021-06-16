using System;
using System.Runtime.Serialization;

namespace TemplateBFF.DtiRoundAdapter
{
    [Serializable]
    public class AdapterExceptions : Exception
    {
        public AdapterExceptions()
        {
        }

        public AdapterExceptions(string message) : base(message)
        {
        }

        public AdapterExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdapterExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}




