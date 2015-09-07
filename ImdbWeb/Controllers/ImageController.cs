﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class ImageController : Controller
    {
		[Route("Image/{format}/{id}.jpg")]
		public string CreateImage(string format, string id)
		{
			return $"ImageController.CreateImage({format}, {id})";
        }

	}
}