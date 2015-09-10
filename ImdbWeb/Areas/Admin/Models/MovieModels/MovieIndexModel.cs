using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieIndexModel
	{
		public string Id { get; set; }

		[Display(Name ="Tittel")]
		public string Title { get; set; }

		[Display(Name ="Varighet")]
		[UIHint("Duration")]
		public int RunningLength { get; set; }
	}
}
