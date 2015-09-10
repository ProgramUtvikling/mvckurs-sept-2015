using ImdbWeb.Areas.Admin.Models.MovieModels;
using ImdbWeb.Controllers;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
	public class MovieController : ImdbControllerBase
	{
		public ActionResult Index()
		{
			ViewData.Model = Db.Movies.Select(m => new MovieIndexModel
			{
				Id = m.MovieId,
				Title = m.Title,
				RunningLength = m.RunningLength
			});

			return View();
		}
		public ActionResult Create()
		{
			ViewBag.Genres = new SelectList(Db.Genres, "GenreId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(MovieCreateModel model)
		{
			if (ModelState.IsValid)
			{
				var movie = new Movie
				{
					MovieId = model.MovieId,
					Title = model.Title,
					OriginalTitle = model.OriginalTitle,
					Description = model.Description,
					ProductionYear = model.ProductionYear,
					RunningLength = model.RunningLengthHours * 60 + model.RunningLengthMinutes,
					Genre = Db.Genres.Find(model.GenreId)
				};
				Db.Movies.Add(movie);
				Db.SaveChanges();

				return RedirectToAction("Index");
			}

			return Create();
		}

		public static ValidationResult CheckIdLocal(string movieId)
		{
			var db = new ImdbContext();
			if(db.Movies.Any(m => m.MovieId == movieId))
			{
				return new ValidationResult("Filmen er allerede registrert");
			}

			return ValidationResult.Success;
		}
	}
}