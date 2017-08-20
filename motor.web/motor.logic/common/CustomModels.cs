using motor.logic.common;
using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace motor.logic.common
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

    public class DriverDocumentInfoRequest
    {
        public string SSN { set; get; }
        public string LicenseNumber { get; set; }
        public string VehicleNumber { get; set; }

    }

    public class DriverDocumentDataRequest
    {
        public DocumentType DocType { get; set; }
        public byte[] DocData { get; set; }
    }

    public class SaveProfileRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
    }

    public class SaveProfilePictureRequest
    {
        public byte[] ProfilePicture { get; set; }
    }

    public class ProfileResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }

    public class DriverDocumentResponse
    {
        public string SSN { get; set; }
        public string LicenseNumber { get; set; }
        public byte[] LicenseImage { get; set; }
        public byte[] VehicleImage1 { get; set; }
        public byte[] VehicleImage2 { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class PaymentCardRequest
    {
        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public string Name { get; set; }

        public string CVV { get; set; }
    }

    public class PaymentCardResponseData
    {
        public long Id { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
    }

    public class PaymentCardResponse : IBaseResponse
    {
        
        public List<PaymentCardResponseData> PaymentCards
        {
            get;
            set;
        }
        
    }
    public class RemovePaymentCardRequest
    {
        public long CardId { get; set; }
    }
}