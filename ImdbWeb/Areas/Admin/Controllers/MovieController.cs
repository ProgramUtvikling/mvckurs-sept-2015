﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
    public class MovieController : Controller
    {
        public ActionResult Index()
        {
            return Content("Admin area sin MovieController.Index()");
        }
    }
}