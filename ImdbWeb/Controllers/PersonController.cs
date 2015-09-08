using ImdbWeb.Models.PersonModels;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Person")]
    public class PersonController : Controller
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

		public ViewResult Actors()
		{
			var persons = from person in _db.Persons
						  where person.ActedMovies.Any()
						  select person;

			ViewData.Model = new PersonIndexModel { Title = "skuespillere", Persons = persons };
			return View("Index");
		}
		public ViewResult Producers()
		{
			var persons = from person in _db.Persons
						  where person.ProducedMovies.Any()
						  select person;

			ViewData.Model = new PersonIndexModel { Title = "produsenter", Persons = persons };
			return View("Index");
		}
		public ViewResult Directors()
		{
			var persons = from person in _db.Persons
						  where person.DirectedMovies.Any()
						  select person;

			ViewData.Model = new PersonIndexModel { Title = "regisører", Persons = persons };
			return View("Index");
		}

		[Route("{id:int}")]
		public ActionResult Details(int id)
		{
			var person = _db.Persons.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}

			ViewData.Model = person;
			return View();
		}
	}
}