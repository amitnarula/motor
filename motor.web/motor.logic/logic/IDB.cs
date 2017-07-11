using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motor.logic.logic
{
    interface IDB<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        T GetById(long id);
        IEnumerable<T> GetList();
    }
}
