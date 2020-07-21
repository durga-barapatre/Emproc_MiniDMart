using MiniDMartApp.Application.Interfaces;
using MiniDMartApp.Domain.Domain;
using MiniDMartApp.Domain.InterfaceRepositories;
using System.Collections.Generic;
using MiniDMartApp.Application.Models;
using MiniDMartApp.Application.Mapper;
using System;
using System.Linq;

namespace MiniDMartApp.Application.Services
{
    public class ItemDataService : IItemDataService
    {
        private readonly IRepository<ItemData> _itemDataRepo;
        public ItemDataService(IRepository<ItemData> itemDataRepo)
        {
            this._itemDataRepo = itemDataRepo;
        }
        public void Add(ItemDataModel entity)
        {
            ItemData itemEntity = entity.MapToItemData();
            _itemDataRepo.Add(itemEntity);
        }

        public IEnumerable<ItemDataModel> GetAll()
        {
            var Items = _itemDataRepo.GetAll();
            List<ItemDataModel> model = new List<ItemDataModel>();
            foreach (var item in Items)
            {
                model.Add(item.MapToItemDataModel());
            }
            return model;
        }

        public IEnumerable<ItemDataModel> GetItemByRate(string rate)
        {            
            var dataList = this.GetAll();
            List<ItemDataModel> dataListNew = null;
            if (rate != null && rate != "")
            {
                double rateNew = Convert.ToDouble(rate);
                switch (rateNew)
                {
                    case 100:
                        dataListNew = dataList.Where(x => x.Rate <= 100).ToList();
                        break;
                    case 101:
                        dataListNew = dataList.Where(x => x.Rate > rateNew && x.Rate <= rateNew * 10).ToList();
                        break;
                    case 1001:
                        dataListNew = dataList.Where(x => x.Rate >= rateNew).ToList();
                        break;
                    default:
                        dataListNew = dataList.ToList();
                        break;
                }
            }
            else
            {
                dataListNew = dataList.ToList();
            }
            return dataListNew;
        }

    }
}
