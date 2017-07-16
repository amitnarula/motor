using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.logic
{
    class DriverDocumentManagement : IDB<DriverDocument>
    {
        motorEntities dc;
        public DriverDocumentManagement()
        {
            dc = new motorEntities();
        }

        public bool Add(DriverDocument obj)
        {
            dc.DriverDocuments.Add(obj);
            return dc.SaveChanges() > 0;
        }

        public bool Delete(DriverDocument obj)
        {
            throw new NotImplementedException();
        }

        public DriverDocument GetById(long id)
        {
            return dc.DriverDocuments.Where(x => x.Id == id).SingleOrDefault();
        }

        public IEnumerable<DriverDocument> GetList()
        {
            return dc.DriverDocuments.ToList();
        }

        public bool Update(DriverDocument obj)
        {
            dc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return dc.SaveChanges() > 0;
        }

        public DriverDocument GetByUserId(long userId)
        {
            return dc.DriverDocuments.Where(x => x.UserId == userId).SingleOrDefault();
        }
    }
}
