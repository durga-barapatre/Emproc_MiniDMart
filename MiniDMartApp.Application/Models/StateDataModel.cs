using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Models
{
    public class StateDataModel:BaseModel
    {
        #region Properties
        public int StateCode { get; set; }
        public string StateName { get; set; }
        #endregion
    }
}
