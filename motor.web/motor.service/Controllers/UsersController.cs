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

        private string FetchAuthenticationTokenFromRequest()
        {
            string authenticationToken = Request.Headers.GetValues("authToken").SingleOrDefault();

            if (authenticationToken == null)
                throw new Exception("Invalid authentication token.");

            return authenticationToken;
        }

        private User GetUserByToken(string authTotken)
        {
            var authToken = svc.GetAuthenticationToken(authTotken);
            if (authToken != null)
                return authToken.User;

            return null;
        }

        private bool SaveDocumentInfo(string authenticationToken,string ssn,string licenseNumber)
        {
            //make sure the user token is for the driver type user
            var user = GetUserByToken(authenticationToken);
            if (user == null)
                throw new ArgumentException("user");

            if (user.UserType != (short)UserType.Driver)
                throw new Exception("The requested user is not a driver.");

            DriverDocument doc = svc.GetDocumentByUserId(user.Id);
            if (doc == null)
            {
                doc = new DriverDocument();
                doc.UserId = user.Id;
                doc.LicenseNumber = licenseNumber;
                doc.SSN = ssn;
                doc.Status = (short)DocumentStatus.Pending;
                svc.InsertDocumentInfo(doc);
            }
            else
            {
                doc.LicenseNumber = licenseNumber;
                doc.SSN = ssn;
                svc.UpdateDocumentInfo(doc);
            }
            return true;
        }

        private bool SaveDocument(string authenticationToken, byte[] documentData, DocumentType docType)
        {
            var user = GetUserByToken(authenticationToken);
            if (user == null)
                throw new Exception("No user found with the token provided");

            if (user.UserType != (short)UserType.Driver)
                throw new Exception("The requested user is not a driver.");

            DriverDocument doc = svc.GetDocumentByUserId(user.Id);
            if (doc == null)
                throw new Exception("No basic document info was found for the user");

            return svc.SaveDocumentImage(doc.Id, documentData, docType);

        }

        private bool SaveUserProfile(string authenticationToken, string firstName,string middleName, string lastName, string city)
        {
            var user = GetUserByToken(authenticationToken);
            if (user == null)
                throw new ArgumentException("user");

            user.Firstname = firstName;
            user.Lastname = lastName;
            user.City = city;
            user.Middlename = middleName;

            return svc.UpdateUser(user);
        }

        private bool ChangePassword(string authenticationToken,string oldPassword, string newPassword)
        {
            var user = GetUserByToken(authenticationToken);
            oldPassword = CommonUtils.Encrypt(oldPassword);
            if (oldPassword == user.Password)
            {
                user.Password = CommonUtils.Encrypt(newPassword);
                if (svc.UpdateUser(user))
                    return true;
                return false;
            }
            else
                return false;
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

        [AuthenticateActionFilter]
        public bool ChangePassword(ChangePasswordRequest request)
        {
            string authenticationToken = FetchAuthenticationTokenFromRequest();
            return ChangePassword(authenticationToken, request.OldPassword, request.NewPassword);
        }

        [AuthenticateActionFilter]
        public bool SaveDriverDocumentInfo(DriverDocumentInfoRequest request)
        {
            string authenticationToken = FetchAuthenticationTokenFromRequest();
            return SaveDocumentInfo(authenticationToken, request.SSN, request.LicenseNumber);

        }

        [AuthenticateActionFilter]
        public bool SaveDriverDocument(DriverDocumentDataRequest request)
        {
            string authenticationToken = FetchAuthenticationTokenFromRequest();
            return SaveDocument(authenticationToken, request.DocData, request.DocType);
        }

        [AuthenticateActionFilter]
        public bool SaveProfile(SaveProfileRequest request)
        {
            string authenticationToken = FetchAuthenticationTokenFromRequest();
            return SaveUserProfile(authenticationToken,
                request.FirstName, request.MiddleName, request.LastName, request.City);
        }

        [AuthenticateActionFilter]
        public ProfileResponse GetUserProfile(string authenticationToken)
        {
            var user = GetUserByToken(authenticationToken);
            if (user != null)
            {
                return new ProfileResponse()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    MiddleName = user.Middlename,
                    City = user.City,
                    Email = user.Email,
                    Phone = user.Phone
                };
            }
            return null;

        }

        [AuthenticateActionFilter]
        public DriverDocumentResponse GetDriverDocument(string authenticationToken)
        {
            var user = GetUserByToken(authenticationToken);
            if (user == null)
                throw new Exception("user not found for authentication token provided");

            if (user.UserType != (short)UserType.Driver)
                throw new Exception("user found is not a driver.");

            DriverDocument doc = user.DriverDocuments.SingleOrDefault();

            if (doc != null)
            {
                return new DriverDocumentResponse()
                {
                    SSN = doc.SSN,
                    LicenseImage = doc.LicensePicture,
                    LicenseNumber = doc.LicenseNumber,
                    VehicleImage1 = doc.VehiclePicture1,
                    VehicleImage2 = doc.VehiclePicture2
                };
            }
            return null;



        }
    }
}
