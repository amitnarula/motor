﻿using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.logic
{
    class UserManagement : IDB<User>
    {
        motorEntities dc;

        public UserManagement()
        {
            dc = new motorEntities();
        }

        public bool Add(User obj)
        {
            dc.Users.Add(obj);
            return dc.SaveChanges() > 0;
        }

        public bool Delete(User obj)
        {
            dc.Users.Remove(obj);
            return dc.SaveChanges() > 0;
        }

        public User GetById(long id)
        {
            return dc.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetList()
        {
            return dc.Users.ToList();
        }

        public bool Update(User obj)
        {
            dc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return dc.SaveChanges() > 0;
        }

        public User Get(string phoneNumber)
        {
            return dc.Users.Where(x => x.Phone.Equals(phoneNumber, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }
        
        public User Get(string phone, string password) {
            return dc.Users.SingleOrDefault(x => x.Phone.Equals(phone, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password));
        }
    }
}
