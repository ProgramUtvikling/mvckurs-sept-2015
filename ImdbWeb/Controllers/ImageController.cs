using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class ImageController : Controller
    {
		[Route("Image/{format}/{id}.jpg")]
		public ActionResult CreateImage(string format, string id)
		{
			var relName = $"~/App_Data/covers/{id}.jpg";
			var absName = Server.MapPath(relName);

			if (!System.IO.File.Exists(absName))
			{
				return HttpNotFound();
			}

			var img = new WebImage(absName);

			switch (format.ToLower())
			{
				case "thumb":
					img.Resize(100, 1000).Write();
					break;

				case "medium":
					img.Resize(300, 3000)
						.AddTextWatermark("Ingars Movie Database")
						.AddTextWatermark("Ingars Movie Database", "White", padding: 7)
						.Write();
					break;

				default:
					return HttpNotFound();
			}

			return new EmptyResult();
		}

	}
}