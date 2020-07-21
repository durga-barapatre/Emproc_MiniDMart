using MiniDMartApp.Domain.Domain;
using MiniDMartApp.Application.Models;

namespace MiniDMartApp.Application.Mapper
{
    public static class EntityMapper
    {
        public static ItemData MapToItemData(this ItemDataModel itemModelObj)
        {
            return new ItemData()
            {
                Id = itemModelObj.Id,
                ItemCode = itemModelObj.ItemCode,
                ItemName = itemModelObj.ItemName,
                Description = itemModelObj.Description,
                Rate = itemModelObj.Rate
            };
        }
        public static ItemDataModel MapToItemDataModel(this ItemData itemDataObj)
        {
            return new ItemDataModel()
            {
                Id = itemDataObj.Id,
                ItemCode = itemDataObj.ItemCode,
                ItemName = itemDataObj.ItemName,
                Description = itemDataObj.Description,
                Rate = itemDataObj.Rate
            };
        }
        public static StockData MapToStockData(this StockDataModel model)
        {
            return new StockData()
            {
                Quantity = model.Quantity,
                ItemCode = model.ItemCode,

            };
        }
        public static StockDataModel MapToStockDataModel(this StockData entity)
        {
            return new StockDataModel()
            {
                Quantity = entity.Quantity,
                ItemCode = entity.ItemCode
            };
        }
        public static StateData MapToStateData(this StateDataModel model)
        {
            return new StateData()
            {
                Id = model.Id,
                StateCode = model.StateCode,
                StateName = model.StateName
            };
        }
        public static StateDataModel MapToStateData(this StateData entity)
        {
            return new StateDataModel()
            {
                Id = entity.Id,
                StateCode = entity.StateCode,
                StateName = entity.StateName
            };
        }
    }
}
