using motor.logic.common;
using motor.logic.logic;
using motor.logic.model;
using motor.logic.services;
using motor.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;


namespace motor.service.Controllers
{
    public class UsersController : ApiController
    {
        UserService svc;
        private string GenerateAuthenticationToken(long userId)
        {
            return CommonUtils.Encrypt(userId.ToString());
        }

        public UsersController()
        {
            svc = new UserService();
        }
        
        public LoginResult Login(LoginRequest loginObj)
        {
            var result = svc.Login(loginObj.PhoneNumber, loginObj.Password);

            if (result != null)
            {
                //Generate Authentication token
                string authenticationToken = GenerateAuthenticationToken(result.Id); //generate token from user id

                //Update/insert authentication token
                svc.AddUpdateAuthenticationToken(new AuthenticationToken() {
                    Token = authenticationToken,
                    Expires = DateTime.UtcNow.AddDays(30), // valid for 30 days
                    UserId = result.Id
                });

                //return authentication token
                return new LoginResult()
                {
                    AuthenticationToken = authenticationToken,
                    Message ="Authentication Successful"
                };
            }
            else
                return new LoginResult()
                {
                    AuthenticationToken = string.Empty,
                    Message = "Authentication Failed"
                };
        }

        public bool RegisterUser(RegisterUserRequest request)
        {
            string hostBaseAddress = ConfigurationManager.AppSettings["motorHostBaseAddress"];

            User userObj = new User();
            userObj.Firstname = request.Firstname;
            userObj.Lastname = request.Lastname;
            userObj.Middlename = request.Middlename;
            userObj.Password = request.Password;
            userObj.Phone = request.Phone;
            userObj.City = request.City;
            userObj.CreatedOn = DateTime.UtcNow;
            userObj.Email = request.Email;
            userObj.UserType = request.UserType;
            userObj.Source = request.Source;

            string activationUrl = hostBaseAddress + "activate.aspx?activationCode=" + CommonUtils.EncryptParameter(userObj.Email) + "&pad=" + CommonUtils.EncryptParameter(userObj.Phone);
            
            return svc.RegisterUser(userObj, activationUrl);
        }
        
    }
}
