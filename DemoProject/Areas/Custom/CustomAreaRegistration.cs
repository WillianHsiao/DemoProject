using System.Web.Mvc;

namespace DemoProject.Areas.Custom
{
    public class CustomAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Custom";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Custom_SignOut",
                "Custom/Login/{action}",
                new {
                    controller = "Login",
                    action = "SignOut"
                }
                , namespaces: new string[] { "DemoProject.Controllers" }
            );

            context.MapRoute(
                "Custom_default",
                "Custom/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] {"DemoProject.Areas.Custom.Controllers" }
            );
        }
    }
}