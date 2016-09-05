using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Refactoring.Data;
using Refactoring.Models;

namespace Refactoring.App_Start
{
    public class AutofacConfig
    {
        internal static void RegisterDepenencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ItemsRepository>().As<IItemsRepository>().InstancePerRequest();
            builder.RegisterType<ShopDbContext>().As<IShopContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}