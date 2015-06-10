using DAL;
using DAL.Service;
using DemoProject.Areas.Custom.Models;
using DemoProject.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Areas.Custom.Controllers
{
    public class UserDataController : BaseController
    {
        IUserDataRepository _IUserData = BFactory.CreateUserData(string.Empty);
        // GET: Custom/UserData
        public ActionResult Index() {
            UserDataModel model = new UserDataModel();
                var user = _IUserData.UserData(this.LoginInfo.UserPK);
                model.PK = user.PK;
                model.Name = user.Name;
                model.H_TEL = user.H_TEL;
                model.M_TEL = user.M_TEL;
                model.EMAIL = user.EMAIL;
                model.ADDR = user.ADDR;
            return PartialView("_UserDataManage", model);
        }

        public ActionResult UpdateUserData(FormCollection collection) {
            UserDataModel model = new UserDataModel();
            var bResult = false;
            try {
                if (TryUpdateModel(model) && ModelState.IsValid) {
                    UserData user = new UserData {
                        PK = model.PK,
                        Name = model.Name,
                        H_TEL = model.H_TEL,
                        M_TEL = model.M_TEL,
                        ADDR = model.ADDR,
                        EMAIL = model.EMAIL
                    };
                    bResult = _IUserData.UpdateUserData(user);
                }
            }
            catch {
                bResult = false;
            }
            ViewBag.Success = bResult;
            return PartialView("_UserDataManage", model);
        }
    }
}