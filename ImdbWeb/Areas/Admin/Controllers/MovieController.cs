using ImdbWeb.Areas.Admin.Models.MovieModels;
using ImdbWeb.Controllers;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
	public class MovieController : ImdbControllerBase
	{
		public async Task<ActionResult> Index()
		{
			ViewData.Model = await Db.Movies.Select(m => new MovieIndexModel
			{
				Id = m.MovieId,
				Title = m.Title,
				RunningLength = m.RunningLength
			}).ToListAsync();

			return View();
		}
		public async Task<ActionResult> Create()
		{
			ViewBag.Genres = new SelectList(await Db.Genres.ToListAsync(), "GenreId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(MovieCreateModel model)
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
					Genre = await Db.Genres.FindAsync(model.GenreId)
				};
				Db.Movies.Add(movie);
				await Db.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return await Create();
		}

		public static ValidationResult CheckIdLocal(string movieId)
		{
			var db = new ImdbContext();
			if (db.Movies.Any(m => m.MovieId == movieId))
			{
				return new ValidationResult("Filmen er allerede registrert");
			}

			return ValidationResult.Success;
		}

		public async Task<ActionResult> Delete(string id)
		{
			var movie = await Db.Movies.FindAsync(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = new MovieDeleteModel
			{
				MovieId = movie.MovieId,
				Title = movie.Title,
				OriginalTitle = movie.OriginalTitle,
				ProductionYear = movie.ProductionYear
			};
			return View();
		}

		[HttpDelete]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<ActionResult> DeleteConfirmed(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null)
			{
				return HttpNotFound();
			}

			Db.Movies.Remove(movie);
			await Db.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}