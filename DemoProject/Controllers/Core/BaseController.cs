using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProject.Models;
using System.Web.Security;
using DAL.Service;

namespace DemoProject.Core.Controllers
{
    public class BaseController : Controller {
        ILoginRepository _ILogin = BFactory.CreateLogin();
        LoginInfoModel _LoginInfo;

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (User.Identity.IsAuthenticated == false) {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            base.OnActionExecuting(filterContext);
        }

        public LoginInfoModel LoginInfo {
            get {
                if(_LoginInfo == null) {
                    Guid LoginPK = Guid.Parse(User.Identity.Name);
                    var tmpUser = _ILogin.LoginInfo(LoginPK);
                    _LoginInfo = new LoginInfoModel {
                        PK = tmpUser.PK,
                        UserPK = tmpUser.UserPK,
                        Account = tmpUser.Account,
                        Password = tmpUser.Password,
                        UserType = (UserType)tmpUser.UserType
                    };
                }
                return _LoginInfo;
            }
        }
    }
}