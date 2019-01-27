using System.Web.Http;

namespace WebApi.App_Start
{
    /// <summary>
    /// Binding
    /// </summary>
    /// <seealso cref="Ninject.Modules.NinjectModule" />
    public static class Boostrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
