using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbWeb.Models.PersonModels
{
	public class PersonIndexModel
	{
		public string Title { get; set; }
		public IEnumerable<Person> Persons { get; set; }
	}
}
