using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ImdbWeb.Helpers
{
	public static class MyHtmlHelpers
	{
		public static IHtmlString PrettyJoin(this HtmlHelper html, IEnumerable<Person> persons)
		{
			Func<Person, string> linkifier = p => html.ActionLink(p.Name, "Details", "Person", new { id = p.PersonId }, null).ToString();

			int count = 0;
			string res = "";
			foreach (var person in persons)
			{
				switch (count++)
				{
					case 0:
						res = linkifier(person);
						break;

					case 1:
						res = linkifier(person) + " og " + res;
						break;

					default:
						res = linkifier(person) + ", " + res;
						break;
				}
			}

			return MvcHtmlString.Create(res);
		}

	}
}