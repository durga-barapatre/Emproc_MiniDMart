using MiniDMartApp.Data.Mapping;
using MiniDMartApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace MiniDMartApp.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=DMartConnection")
        {
            
                Database.SetInitializer<ApplicationContext>(new DBInitializer());
        }
        public virtual DbSet<ItemData> ItemData { get; set; }
        public virtual DbSet<StockData> StockData { get; set; }
        public virtual DbSet<StateData> StateData { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Get All the mapping configuration classes
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                    type.BaseType.GetGenericTypeDefinition() == typeof(MappingConfiguration<>));
        
            modelBuilder.Entity<ItemData>().ToTable("ItemData", "master");
            modelBuilder.Entity<StockData>().ToTable("StockData", "master");
            modelBuilder.Entity<StateData>().ToTable("StateData", "master");
            modelBuilder.Entity<ItemData>()
            .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertItemData", "master"))
                                            .Update(u => u.HasName("UpdateItemData", "master"))
                                            .Delete(u => u.HasName("DeleteItemData", "master")));
            base.OnModelCreating(modelBuilder);
        }
        public  class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
        {
            
            protected override void Seed(ApplicationContext context)
            {
                IList<StockData> stocks = new List<StockData>();
                stocks.Add(new StockData()
                {
                    Id = 1,
                    Quantity = 20,
                    ItemCode = 01,
                    ItemCodes = new ItemData()
                    {
                        Id = 1,
                        ItemName = "Himalaya Baby Soap",
                        Description = "Himalaya Baby Soap",
                        ItemCode = 01,
                        Rate = 65
                    }
                });
                stocks.Add(new StockData()
                {
                    Id = 2,
                    Quantity = 15,
                    ItemCode = 02,
                    ItemCodes = new ItemData()
                    {
                        Id = 2,
                        ItemName = "Keyboard",
                        Description = "TCL Keyboard",
                        ItemCode = 02,
                        Rate = 1350
                    }
                });
                stocks.Add(new StockData()
                {
                    Id = 3,
                    Quantity = 10,
                    ItemCode = 03,
                    ItemCodes = new ItemData()
                    {
                        Id = 3,
                        ItemName = "Mouse",
                        Description = "Logitech Mouse",
                        ItemCode = 03,
                        Rate = 670
                    }
                });
                foreach (StockData stock in stocks)
                    context.StockData.Add(stock);
                context.SaveChanges();
                IList<StateData> states = new List<StateData>();
                states.Add(new StateData()
                {
                    Id = 1,
                    StateName = "Maharashtra",
                    StateCode = 27
                });
                states.Add(new StateData()
                {
                    Id = 2,
                    StateName = "Gujrat",
                    StateCode = 29
                });
                foreach (StateData state in states)
                    context.StateData.Add(state);
                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}