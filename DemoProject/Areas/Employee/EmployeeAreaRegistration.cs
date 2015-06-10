using System.Web.Mvc;

namespace DemoProject.Areas.Employee
{
    public class EmployeeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Employee";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {
            context.MapRoute(
                "Employee_SignOut",
                "Employee/Login/{action}",
                new {
                    controller = "Login",
                    action = "SignOut"
                }
                , namespaces: new string[] { "DemoProject.Controllers" }
            );

            context.MapRoute(
                "Employee_default",
                "Employee/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DemoProject.Areas.Employee.Controllers" }
            );
        }
    }
}