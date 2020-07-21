using MiniDMartApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Domain.Domain
{
    public class StateData:BaseEntity
    {
        #region Properties
        public int StateCode { get; set; }
        public string StateName { get; set; }
        #endregion
    }
}
