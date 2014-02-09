using System.Web.Http;

namespace WeListen.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Remove xml
            /*config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            //Ignore
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            
            
            //Preserve
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = ReferenceLoopHandling.Serialize;

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
                = PreserveReferencesHandling.Objects;*/
            
            

            /*GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = false;
            config.Formatters.Remove(config.Formatters.JsonFormatter);*/



            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}