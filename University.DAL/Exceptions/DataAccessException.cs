using University.DAL.Exceptions.Base;

namespace University.DAL.Exceptions
{
    class DataAccessException : BaseCustomException
    {
        public DataAccessException() { }

        public DataAccessException(string message)
            : base(message) { }

        public DataAccessException(string message, Exception inner)
            : base(message, inner) { }
    }
}
