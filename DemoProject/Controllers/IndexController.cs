using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Service;
using DAL.Service.Model;
using DemoProject.Core.Controllers;

namespace DemoProject.Controllers
{
    public class IndexController : BaseController
    {
        IUserDataRepository _IUserData = BFactory.CreateUserData(string.Empty);
        // GET: Index
        public ActionResult Index(LoginInfoModel model)
        {
            if (model.UserType == UserType.Custom) {
                return RedirectToAction("Index", "Index", new { Area = "Custom" });
            }
            else if (model.UserType == UserType.Employee) {
                return RedirectToAction("Index", "Index", new { Area = "Employee" });
            }
            return View("_Index");
        }
    }
}