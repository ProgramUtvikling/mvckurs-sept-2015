using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class MovieController : Controller
    {
		public ViewResult Index()
		{
			var db = new ImdbContext();

			var movies = db.Movies;
			ViewData.Model = movies;

			return View();
		}
		public string Details(string id)
		{
			return $"MovieController.Details({id})";
		}
		public string Genres()
		{
			return "MovieController.Genres()";
		}
		public string MoviesByGenre(string genrename)
		{
			return $"MovieController.MovieByGenre({genrename})";
		}
	}
}