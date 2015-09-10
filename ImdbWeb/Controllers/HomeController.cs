using ImdbWeb.Models.DemoModels;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class HomeController : Controller
    {
		public ViewResult Index()
		{
			return View();
		}

		public ViewResult Demo()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ViewResult Demo(DemoModel model)
		{
			model.Kommentar = Sanitizer.GetSafeHtmlFragment(model.Kommentar);


			ViewData.Model = model;
			return View("DemoResult");
		}
	}
}