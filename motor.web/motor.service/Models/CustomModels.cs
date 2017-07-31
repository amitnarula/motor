using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace motor.service.Models
{
    public class LoginRequest
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public string AuthenticationToken { get; set; }
        public string Message { get; set; }

    }

    public class RegisterUserRequest
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Source { get; set; }
        public short UserType { get; set; }
    }
}