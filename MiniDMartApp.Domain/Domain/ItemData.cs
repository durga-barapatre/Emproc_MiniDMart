using MiniDMartApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Domain.Domain
{
    public class ItemData:BaseEntity
    {
        #region Properties
        public int ItemCode{ get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        #endregion
    }
}
