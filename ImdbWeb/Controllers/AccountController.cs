using ImdbWeb.Models.AccountModels;
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
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public ActionResult Logon(LogonModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (model.Username == "arjan" && model.Password == "pass")
				{
					FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

					if(!string.IsNullOrWhiteSpace(returnUrl))
					{
						return Redirect(returnUrl);
					}
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("", "Ukjent brukernavn og/eller feil passord");
			}
			return View();
		}

		public ActionResult LoggedOn()
		{
			return View("LoggedOn");
		}

		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		[ChildActionOnly]
		public ActionResult LoginStatus()
		{
			if (Request.IsAuthenticated)
			{
				ViewData.Model = User.Identity.Name;
				return PartialView("_LoggedIn");
			}

			return PartialView("_NotLoggedIn");
		}
	}
}