using DemoProject.Controllers;
using DemoProject.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Areas.Employee.Controllers
{
    public class IndexController : BaseController
    {
        // GET: Employee/Index
        public ActionResult Index()
        {
            return View("_Index");
        }
    }
}