using System;
using System.Collections.Generic;
using System.Text;

namespace Student3rdPart
{
    public class ExceedLimit : Exception
    {
        public ExceedLimit(String message)
            : base(message)
        {

        }
    }
    public class StudentException : Exception
    {
        public StudentException(String message)
            : base(message)
        {

        }
    }
    public class NotRegistered : Exception
    {
        public NotRegistered(String message)
            : base(message)
        {

        }
    }
    public class AlreadyRegistered: Exception
    {
        public AlreadyRegistered(String message)
            : base(message)
        {

        }
    }
    public class NoSeatsAvailableException : Exception
    {
        public NoSeatsAvailableException(String message)
            : base(message)
        {

        }
    }
    public class AlreadyEnrolled : Exception
    {
        public AlreadyEnrolled(String message)
            : base(message)
        {

        }
    }
}
