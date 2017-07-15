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
        public UserService()
        {
            usrMgmt = new UserManagement();
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
    }
}
