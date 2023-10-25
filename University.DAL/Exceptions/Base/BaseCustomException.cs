using System;

namespace University.DAL.Exceptions.Base;

[Serializable]
abstract class BaseCustomException : Exception
{
    public BaseCustomException() { }

    public BaseCustomException(string message) 
        : base(message) { }

    public  BaseCustomException(string message, Exception innerException) 
        : base(message, innerException) { }
}
