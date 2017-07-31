using motor.logic.common;
using motor.logic.logic;
using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.services
{
    public class UserService
    {
        UserManagement usrMgmt = null;
        DriverDocumentManagement docMgmt = null;
        AuthTokenManagement authMgmt = null;

        public UserService()
        {
            usrMgmt = new UserManagement();
            docMgmt = new DriverDocumentManagement();
            authMgmt = new AuthTokenManagement();
        }
        public User Login(string phone, string password)
        {
            string encryptedPassword = CommonUtils.Encrypt(password);
            return usrMgmt.Get(phone, encryptedPassword);
        }

        public bool IsPhoneNumberAlreadyExists(string phoneNumber)
        {
            return usrMgmt.Get(phoneNumber) != null;
        }

        public bool RegisterUser(User obj,string activationUrl)
        {
            bool isUserAdded = usrMgmt.Add(obj);
            if (isUserAdded)
            {
                //TODO:CommonUtils.SendActivationEmail(obj.Firstname,obj.Lastname,obj.Email, activationUrl);
            }
            return isUserAdded;
        }

        public bool UpdateUser(User obj)
        {
            return usrMgmt.Update(obj);
        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return usrMgmt.Get(phoneNumber);
        }

        public User Get(long id)
        {
            return usrMgmt.GetById(id);
        }

        public DriverDocument GetByUserId(long userId)
        {
            return docMgmt.GetByUserId(userId);
        }

        public bool InsertDocumentInfo(DriverDocument obj)
        {
            return docMgmt.Add(obj);
        }

        public bool UpdateDocumentInfo(DriverDocument obj)
        {
            bool isSaved;

            isSaved = docMgmt.Update(obj);

            return isSaved;
        }

        public IEnumerable<DriverDocument> GetAllDocuments()
        {
           return docMgmt.GetList();
        }

        public bool SaveDocumentImage(long id,byte[] imageData, DocumentType docType)
        {
            DriverDocument doc = docMgmt.GetById(id);
            switch (docType)
            {
                case DocumentType.VehicleImage1:
                    doc.VehiclePicture1 = imageData;
                    break;
                case DocumentType.VehicleImage2:
                    doc.VehiclePicture2 = imageData;
                    break;
                case DocumentType.LicenseImage:
                    doc.LicensePicture = imageData;
                    break;
                default:
                    break;
            }
            return docMgmt.Update(doc);
        }

        public byte[] GetDocumentImage(DocumentType type, long documentId)
        {
            DriverDocument doc = docMgmt.GetById(documentId);
            byte[] bytes = null;
            switch (type)
            {
                case DocumentType.VehicleImage1:
                    bytes = doc.VehiclePicture1;
                    break;
                case DocumentType.VehicleImage2:
                    bytes = doc.VehiclePicture2;
                    break;
                case DocumentType.LicenseImage:
                    bytes = doc.LicensePicture;
                    break;
                default:
                    break;
            }
            return bytes;
        }

        public bool AddUpdateAuthenticationToken(AuthenticationToken token)
        {
            var authenticationToken = authMgmt.GetByToken(token.Token);
            bool isSaved;

            if (authenticationToken == null)
            {
                isSaved = authMgmt.Add(token);
            }
            else
            {
                authenticationToken.Token = token.Token;
                authenticationToken.Expires = token.Expires;
                isSaved = authMgmt.Update(authenticationToken);

            }
            
            return isSaved;
        }

        public AuthenticationToken GetAuthenticationToken(string token)
        {
            return authMgmt.GetByToken(token);
        }
        
    }
}
