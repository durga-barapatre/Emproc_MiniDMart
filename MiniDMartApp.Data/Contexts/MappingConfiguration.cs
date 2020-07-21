using MiniDMartApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Data.Mapping
{
    public abstract class MappingConfiguration<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public MappingConfiguration()
        {
            this.HasKey(x => x.Id);
        }
    }
}
