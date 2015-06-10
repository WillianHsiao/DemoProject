using DemoProject.Controllers;
using DemoProject.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Areas.Custom.Controllers
{
    public class IndexController : BaseController
    {
        //
        // GET: /Custom/Index/
        public ActionResult Index()
        {
            return View("_Index");
        }
	}
}