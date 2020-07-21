using MiniDMartApp.Data.Contexts;
using MiniDMartApp.Data.Repositories;
using MiniDMartApp.Domain.InterfaceRepositories;
using System.Data.Entity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace MiniDMartApp.Data.DomainDependency
{
    public static class DomainDependencyRegister
    {
        [System.Obsolete]
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext>(new PerThreadLifetimeManager(), new InjectionFactory(x => new ApplicationContext()));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new PerThreadLifetimeManager() );
            container.RegisterType<IStockRepositoy, StockRepository>(new PerThreadLifetimeManager());
            return container;
        }
    }
}
