using System;
using PMMS.Enum;

namespace PMMS.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(LoginFailType userLoginFailType)
        {
            LoginFailType = userLoginFailType;
        }

        public LoginFailType LoginFailType { get; set; }
    }
}