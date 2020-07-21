using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Models
{
    public class ItemStockModel
    {
        #region Properties
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        public double Quantity { get; set; }
   
        #endregion
    }
}
