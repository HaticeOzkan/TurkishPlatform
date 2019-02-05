using System.Web.Mvc;

namespace TurkishPlatform.Areas.Areas
{
    public class AreasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Areas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Areas_default",
                "Areas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}