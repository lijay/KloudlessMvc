using KloudlessMvc.Kloudless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KloudlessMvc.Controllers
{
    public class HomeController : Controller
    {
        private static Account _account;

        public ActionResult Index()
        {
            if (_account == null)
            {
                // This initial code is to obtain input from the user so that
                // we can determine an app to use and service to authenticate.
                String appId = Util.GetAppId();
                string callbackUrl = Url.Action("CallBack", "Home", null, Request.Url.Scheme);
                string authUrl = Util.GetOAuthUrl(appId, callbackUrl, "any.storage");
                return Redirect(authUrl);
            }
            else
            {
                ViewBag.Files = _account.RetrieveContents();
                return View();
            }
        }

        [HttpGet]
        public ActionResult CallBack(string code)
        {
            string callbackUrl = Url.Action("CallBack", "Home", null, Request.Url.Scheme);
            var acnt = new Account(code, callbackUrl);

            if (acnt.ObtainAccessToken())
            {
                _account = acnt;
                return RedirectToAction("Index");
            }
            else
            {
                return new JsonResult()
                {
                    Data = new { success = false },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}