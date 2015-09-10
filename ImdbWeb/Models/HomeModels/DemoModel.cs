using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ImdbWeb.Models.DemoModels
{
	public class DemoModel
	{
		public string Overskrift { get; set; }

		[AllowHtml]
		[DataType(DataType.MultilineText)]
		public string Kommentar { get; set; }
	}
}