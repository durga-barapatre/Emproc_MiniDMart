using MiniDMartApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Domain.Domain
{
    public class StockData:BaseEntity
    {
        #region Properties
        public double Quantity { get; set; }
        #endregion
        #region virtual Properties
        public virtual int ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual ItemData ItemCodes { get; set; }
        #endregion
    }
}
