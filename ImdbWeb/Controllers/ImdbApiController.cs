using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ImdbWeb.Controllers
{
    public class ImdbApiController : ImdbControllerBase
    {
		//public ActionResult Movies(string fmt = "xml")
		//{
		//	switch (fmt.ToLower())
		//	{
		//		case "xml": return MoviesAsXml();
		//		case "json": return MoviesAsJson();

		//		default:
		//			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
		//	}
		//}

		//private ActionResult MoviesAsXml()
        public ActionResult Movies(string fmt = "xml")
		{
			var doc = new XElement("movies", from movie in Db.Movies.ToList()
											 select new XElement("movie",
												new XAttribute("id", movie.MovieId),
												movie.Title));

			return Content(doc.ToString());
		}

		private ActionResult MoviesAsJson()
		{
			var doc = from movie in Db.Movies
					  select new { id= movie.MovieId, title= movie.Title};
			return Json(doc, JsonRequestBehavior.AllowGet);
		}

		[Route("Movie/Details/{id}.xml")]
		public ActionResult MoviesDetails(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			var doc = new XElement("movie",
				new XAttribute("id", movie.MovieId),
				new XAttribute("title", movie.Title),
				new XAttribute("origTitle", movie.OriginalTitle),
				new XAttribute("prodYear", movie.ProductionYear),
				new XAttribute("runLength", movie.RunningLength),
				from p in movie.Actors select new XElement("actor", p.Name),
				from p in movie.Producers select new XElement("producer", p.Name),
				from p in movie.Directors select new XElement("director", p.Name),
				new XCData(movie.Description)
				);

			return Content(doc.ToString());
		}
	}
}