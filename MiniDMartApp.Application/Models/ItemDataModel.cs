using System.ComponentModel.DataAnnotations;

namespace MiniDMartApp.Application.Models
{
    public class ItemDataModel : BaseModel
    {  
        #region Properties
        [Display(Name = "Item Code")]
        public int ItemCode { get; set; }
        
        [Display(Name = "ITEM NAME")]
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double? Rate { get; set; }
        #endregion
    }

  
}
