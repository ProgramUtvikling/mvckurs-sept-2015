using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Movie")]
    public class MovieController : Controller
    {
		private ImdbContext _db = new ImdbContext();

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		public ViewResult Index()
		{
			ViewData.Model = _db.Movies;
			return View();
		}
		public ViewResult Details(string id)
		{
			var movie = _db.Movies.Find(id);

			ViewData.Model = movie;
			return View();
		}
		public ViewResult Genres()
		{
			ViewData.Model = _db.Genres;
			return View();
		}
		[Route("Genre/{genrename:alpha}")]
		public ViewResult MoviesByGenre(string genrename)
		{
			ViewData.Model = _db.Movies.Where(m => m.Genre.Name == genrename);
			
			ViewBag.Genre = genrename;
			//ViewData["Genre"] = genrename;

			return View("Index");
		}
	}
}