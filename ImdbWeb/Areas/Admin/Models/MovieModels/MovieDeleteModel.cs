using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieDeleteModel
	{
		public string MovieId { get; set; }

		[Display(Name="Tittel")]
		public string Title { get; set; }

		[Display(Name = "Originaltittel")]
		public string OriginalTitle { get; set; }

		[Display(Name="Produksjonsår")]
		public string ProductionYear { get; set; }
	}
}
