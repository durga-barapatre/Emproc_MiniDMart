using MiniDMartApp.Application.CrudFunctions;
using MiniDMartApp.Application.Mapper;
using MiniDMartApp.Application.Models;
using MiniDMartApp.Domain.Domain;
using MiniDMartApp.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Services
{
    public class StockDataService : IStockDataService
    {
        private readonly IStockRepositoy _stockRepository;
        private readonly IRepository<ItemData> _itemDataRepos;
        public StockDataService(IStockRepositoy stockRepository, IRepository<ItemData> itemDataRepos)
        {
            this._stockRepository = stockRepository;
            this._itemDataRepos = itemDataRepos;
        }
        public void Add(StockDataModel model)
        {
            StockData entity = model.MapToStockData();
            _stockRepository.Add(entity);
        }

        public IEnumerable<StockDataModel> GetAll()
        {
            var Stocks = _stockRepository.GetAll();
          
            List<StockDataModel> model = new List<StockDataModel>();
            foreach (var stock in Stocks)
            {
                model.Add(stock.MapToStockDataModel());
            }
            return model;
        }
       
        public IEnumerable<ItemStockModel> GetAllItemStock()
        {
            var list = _itemDataRepos.GetAll();
            var stocks = this.GetAll();
            var lstItemStock = (from it in list
                                join st in stocks on
                                 it.ItemCode equals st.ItemCode
                                select new
                                {
                                    ItemName = it.ItemName,
                                    Description = it.Description,
                                    ItemCode = st.ItemCode,
                                    Quantity = st.Quantity
                                    
                                }).ToList();
            List<ItemStockModel> lstModel = new List<ItemStockModel>();
            foreach(var item in lstItemStock)
            {
                ItemStockModel itStModel = new ItemStockModel();
                itStModel.ItemName = item.ItemName;
                itStModel.Description = item.Description;
                itStModel.ItemCode = item.ItemCode;
                itStModel.Quantity = item.Quantity;
                lstModel.Add(itStModel);
            }
            return lstModel;
        }
        public double IncreaseStock(int itemCode, double quantity)
        {
            var upVal = _stockRepository.GetAll().Where(x => x.ItemCode == itemCode).FirstOrDefault();
            upVal.Quantity = upVal.Quantity + quantity;
            _stockRepository.Update(upVal);
            string QuantityVal = Convert.ToString(upVal.Quantity);
            return upVal.Quantity;
        }
        public double DecreaseStock(int itemCode, double quantity)
        {
            var upVal = _stockRepository.GetAll().Where(x => x.ItemCode == itemCode).FirstOrDefault();
            upVal.Quantity = upVal.Quantity- quantity;
            _stockRepository.Update(upVal);
            
            string QuantityVal = Convert.ToString(upVal.Quantity);
            return upVal.Quantity;
        }
        public string UpdateQuantity(int itemCode, double quantity)
        {
            var upVal = _stockRepository.GetAll().Where(x => x.ItemCode == itemCode).FirstOrDefault();
            upVal.Quantity = upVal.Quantity + quantity;
            _stockRepository.Update(upVal);
            string QuantityVal = Convert.ToString(upVal.Quantity);
            return QuantityVal;
        }
    }
}
