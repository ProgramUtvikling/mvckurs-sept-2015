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
		[Display(Name="Brukernavn" )]
		[Required]
		public string Username { get; set; }

		[StringLength(10, MinimumLength = 3)]
		[Required]
		[Display(Name = "Passord")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name="Husk meg på denne maskinen")]
		public bool RememberMe { get; set; }

	}
}
