using MiniDMartApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Domain.InterfaceRepositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        void Add(T entity);
   void Update(T entity);
      
        IEnumerable<T> GetAll();
    }
}
