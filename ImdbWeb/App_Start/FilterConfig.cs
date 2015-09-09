using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ImdbWeb
{
	public class FilterConfig
	{
		public static void RegisterFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			//filters.Add(new AuthorizeAttribute());
		}
	}
}
