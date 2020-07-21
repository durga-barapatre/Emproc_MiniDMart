using MiniDMartApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Domain.InterfaceRepositories
{
    public interface IStockRepositoy : IRepository<StockData>
    {
        //double IncreaseStock(int IteamCode, double Quantity);
        //double DecreaseStock(int IteamCode, double Quantity);
       
    }
}
