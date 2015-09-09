using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImdbWeb.Controllers
{
    public class AccountController : Controller
    {
		[AllowAnonymous]
		public ActionResult Logon()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Logon(string username, string password)
		{
			if(username=="arjan" && password == "pass")
			{
				FormsAuthentication.SetAuthCookie(username, false);

				return View("LoggedOn");
			}

			return View();
		}

		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}