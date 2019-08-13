using System.Web.Mvc;

namespace PTransito.Areas.AreaConfiguracion
{
    public class AreaConfiguracionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaConfiguracion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaConfiguracion_default",
                "AreaConfiguracion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}