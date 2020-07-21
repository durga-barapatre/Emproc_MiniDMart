using MiniDMartApp.Application.CrudFunctions;
using MiniDMartApp.Application.Models;
using System.Collections.Generic;

namespace MiniDMartApp.Application.Interfaces
{
    public interface IItemDataService: CRUDFunction<ItemDataModel>
    {
         IEnumerable<ItemDataModel> GetItemByRate(string rate);
    }
}
