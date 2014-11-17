using System;

namespace SupperSlonicWebSite.DomainLogic
{
    public class ApiException : Exception
    {
        public ApiException(string message)
            : base(message)
        { }
    }
}