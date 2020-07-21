using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.CrudFunctions
{
    public interface CRUDFunction<T>
    {
        void Add(T entity);

        IEnumerable<T> GetAll();
    }
}
