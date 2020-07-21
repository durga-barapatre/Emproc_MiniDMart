using MiniDMartApp.Application.CrudFunctions;
using MiniDMartApp.Application.Models;
using MiniDMartApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Services
{
    public interface IStockDataService:CRUDFunction<StockDataModel>
    {
        //IEnumerable<StockData> GetAll();
        string UpdateQuantity(int itemCode, double Quantity);
        double IncreaseStock(int ItemCode, double Quantity);
        double DecreaseStock(int ItemCode, double Quantity);
        IEnumerable<ItemStockModel> GetAllItemStock();
    }
}
