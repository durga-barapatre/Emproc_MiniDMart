using MiniDMartApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Data.Mapping
{
    public class ItemDataMap:MappingConfiguration<ItemData>
    {
        public ItemDataMap()
        {
            this.ToTable("ItemData", "master");
            this.Property(x => x.ItemName).HasMaxLength(100);
            this.Property(x => x.Description).HasMaxLength(255);
            this.Property(x => x.Rate);
        }
    }
}
