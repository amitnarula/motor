using motor.logic.logic;
using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace motor.service.Controllers
{
    public class UsersController : ApiController
    {
        UserManagement umgmt;

        public UsersController()
        {
            umgmt = new UserManagement();
        }

        // GET: api/Users
        public IEnumerable<User> Get()
        {
            return umgmt.GetList();
        }

        // GET: api/Users/5
        public User Get(long id)
        {
            return umgmt.GetById(id);
        }

        // POST: api/Users
        public void Post([FromBody]User usr)
        {
            umgmt.Add(usr);
        }

        // PUT: api/Users/5
        public void Put([FromBody]User usr)
        {
            umgmt.Update(usr);
        }

        // DELETE: api/Users/5
        public void Delete(long id)
        {
            var user = umgmt.GetById(id);
            umgmt.Delete(user);
        }
    }
}
