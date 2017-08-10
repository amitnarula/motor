using motor.logic.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.logic
{
    class PaymentCardManagement : IDB<PaymentCard>
    {
        motorEntities dc = new motorEntities();
        public bool Add(PaymentCard obj)
        {
            dc.PaymentCards.Add(obj);
            return dc.SaveChanges()>0;
        }

        public bool Delete(PaymentCard obj)
        {
            dc.PaymentCards.Remove(obj);
            return dc.SaveChanges() > 0;
        }

        public PaymentCard GetById(long id)
        {
            return dc.PaymentCards.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<PaymentCard> GetList()
        {
            return dc.PaymentCards.ToList();
        }

        public bool Update(PaymentCard obj)
        {
            dc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return dc.SaveChanges() > 0;
        }

        public List<PaymentCard> GetByUserId(long userId)
        {
            return dc.PaymentCards.Where(x => x.UserId == userId).ToList();
        }
    }
}
