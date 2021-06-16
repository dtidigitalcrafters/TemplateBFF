namespace TemplateBFF.Domain
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Domain Exception.
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="businessMessage">Message.</param>
        public DomainException(string businessMessage)
            : base(businessMessage)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}