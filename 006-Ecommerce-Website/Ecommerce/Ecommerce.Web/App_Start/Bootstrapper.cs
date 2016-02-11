using System.Web.Http;

namespace Ecommerce.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //AutoMapperConfiguration.Configure();
        }
    }
}