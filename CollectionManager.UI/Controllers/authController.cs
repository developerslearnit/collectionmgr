﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManager.UI.Controllers
{
    [RoutePrefix("auth")]
    public class authController : Controller
    {
        [Route("login")]
        public ActionResult login()
        {
            return View();
        }
    }
}