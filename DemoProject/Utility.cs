using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoProject
{
    public static class Utility
    {
        public static void CreateFormsAuthenticationTicket(this Controller _controller, string UserID)
        {
            //如果是已登入的狀態，就先登出。
            if (_controller.User.Identity.IsAuthenticated)
                FormsAuthentication.SignOut();

            // 登入時清空所有 Session 資料
            _controller.Session.RemoveAll();

            // 登入的密碼（以 SHA1 加密）
            //string strPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(pw.Text.Trim(), "SHA1");

            //是否為持續性的票證(將管理者登入的 Cookie 設定成 Session Cookie)
            bool isPersistent = false;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                UserID,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                isPersistent,
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            _controller.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //GetRedirectUrl 方法會使用 ReturnURL 變數名稱，傳回查詢字串中指定的 URL。
            //例如，在 URL http://www.contoso.com/login.aspx?ReturnUrl=caller.aspx 中，
            //GetRedirectUrl 方法會將傳回 URL caller.aspx 傳回。如果 ReturnURL 變數不存在，
            //GetRedirectUrl 方法會傳回 DefaultUrl 屬性中的 URL。

            //_controller.Response.Redirect(FormsAuthentication.GetRedirectUrl(UserID, isPersistent));

            //法一
            //Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            //Response.Redirect(FormsAuthentication.DefaultUrl);

            //法二
            //System.Web.Security.FormsAuthentication.SetAuthCookie(id.Text.Trim(), false);
            //Response.Redirect(FormsAuthentication.DefaultUrl);

            //法三
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(id.Text.Trim(), false);
        }
    }
}