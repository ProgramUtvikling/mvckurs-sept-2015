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
		public string Title { get; set; }

		public int RunningLength { get; set; }
	}
}
