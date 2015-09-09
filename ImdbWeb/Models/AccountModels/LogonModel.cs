using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbWeb.Models.AccountModels
{
	public class LogonModel
	{
		[Display(Name="Brukernavn")]
		public string Username { get; set; }

		[Display(Name = "Passord")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name="Husk meg på denne maskinen")]
		public bool RememberMe { get; set; }
	}
}
