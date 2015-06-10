using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProject.Models;
using DAL.Service;
using DemoProject.Core.Controllers;
using System.Web.Security;
using System.Web.Routing;

namespace DemoProject.Controllers
{
    public class LoginController : Controller
    {
        ILoginRepository _ILogin = BFactory.CreateLogin();

        // GET: Login
        public ActionResult Index()
        {
            LoginInfoModel model = new LoginInfoModel();
            return View("_Index", model);
        }

        [HttpPost]
        public ActionResult UserLogin(LoginInfoModel model) {
            var bResult = _ILogin.LoginInfo(model.Account, model.Password);
            if (bResult != null) {
                Utility.CreateFormsAuthenticationTicket(this, bResult.PK.ToString());
                var action = RedirectToAction("Index", "Index", bResult);
                action.RouteValues.Add("Area", "");
                return action;
            }
            return View("_Index", model);
        }

        public ActionResult SignOut() {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return RedirectToAction("Index", "Login");
        }
    }
}