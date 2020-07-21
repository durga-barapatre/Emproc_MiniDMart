using MiniDMartApp.Data.Contexts;
using MiniDMartApp.Domain.Base;
using MiniDMartApp.Domain.InterfaceRepositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MiniDMartApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;
        public Repository(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }
        public IQueryable<T> Entities
        {
            get
            {
                return this.Table;
            }
        }
        public DbSet<T> Table
        {
            get
            {
              return   _applicationContext.Set<T>();
            }
        }
        public virtual void Add(T entity)
        {
            Table.Add(entity);
            _applicationContext.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        
        public void Update(T entity)
        {
           this.Table.AddOrUpdate(entity);
            _applicationContext.SaveChanges();
        }
    }
}
