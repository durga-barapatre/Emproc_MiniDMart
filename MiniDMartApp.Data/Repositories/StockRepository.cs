using MiniDMartApp.Data.Contexts;
using MiniDMartApp.Domain.Domain;
using MiniDMartApp.Domain.InterfaceRepositories;

namespace MiniDMartApp.Data.Repositories
{
    public class StockRepository : Repository<StockData>, IStockRepositoy
    {
        private readonly ApplicationContext _applicationContext;
             
        public StockRepository(ApplicationContext applicationContext) :base(applicationContext)
        {
            this._applicationContext = applicationContext;         
        }

      

    }
}
