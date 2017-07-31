using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.logic
{
    public class AuthTokenManagement:IDB<AuthenticationToken>
    {
        motorEntities dc = new motorEntities();
        public bool Add(AuthenticationToken obj)
        {
            dc.AuthenticationTokens.Add(obj);
            return dc.SaveChanges() > 0;
        }

        public bool Update(AuthenticationToken obj)
        {
            dc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return dc.SaveChanges() > 0;
        }

        public AuthenticationToken GetByToken(string token)
        {
            return dc.AuthenticationTokens.Where(x => x.Token == token).SingleOrDefault();
        }

        public bool Delete(AuthenticationToken obj)
        {
            throw new NotImplementedException();
        }

        public AuthenticationToken GetById(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthenticationToken> GetList()
        {
            throw new NotImplementedException();
        }
        
    }
}
