using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}