using Autofac;
using Autofac.Integration.WebApi;
using Coffee.Service;
using Coffee.Service.Interface;
using Entity.Model;
using Entity.UnitOfWork;
using System.Reflection;
using System.Web.Http;

namespace WebApi.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            builder.RegisterType<CoffeeContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<ServiceCoffee>().As<IServiceCoffee>().InstancePerRequest();

            Container = builder.Build();

            return Container;
        }
    }
}