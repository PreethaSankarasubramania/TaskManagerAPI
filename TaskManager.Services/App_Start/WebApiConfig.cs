using TaskManager.Services.MessageHandlers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TaskManager.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new RequestResponseMessageHandler());
        }
    }
}
