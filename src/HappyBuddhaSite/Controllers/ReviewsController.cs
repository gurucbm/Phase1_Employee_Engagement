using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HappyBuddhaSite.Controllers
{
	[Authorize]
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            return View();
        }

        public IActionResult Teams()
        {
            return View();
        }

        public IActionResult Summaries()
        {
            return View();
        }

        public IActionResult TeamMemberReview(string id = "" )
        {
            if (string.IsNullOrEmpty(id))
                id = "None";

            this.ViewData["id"] = id;

            return PartialView("_TeamMemberReview");
            //return View();
        }

    }
}
