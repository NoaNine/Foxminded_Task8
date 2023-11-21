using System;

namespace University.WPF.Exceptions.Base
{
    [Serializable]
    abstract class BaseCustomException : Exception //TODO Need to add custom exceptions and integrate them into the code
    {
        public BaseCustomException() { }

        public BaseCustomException(string message)
            : base(message) { }

        public BaseCustomException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
