using MiniDMartApp.Application.Interfaces;
using MiniDMartApp.Application.Services;
using MiniDMartApp.Data.DomainDependency;
using Unity;
using Unity.Lifetime;

namespace MiniDMartApp.Application.ServiceDependency
{
    public static class ServiceDependencyRegister
    {
        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container = DomainDependencyRegister.RegisterTypes(container);
            container.RegisterType<IItemDataService, ItemDataService>(new PerThreadLifetimeManager());
            container.RegisterType<IStockDataService, StockDataService>(new PerThreadLifetimeManager());
            container.RegisterType<IStateDataService, StateDataService>(new PerThreadLifetimeManager());
            return container;
        }
    }
}
