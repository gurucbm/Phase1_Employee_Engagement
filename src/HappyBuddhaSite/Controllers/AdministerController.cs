using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HappyBuddhaSite.ViewModels;
using HappyBuddhaSite.Core.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HappyBuddhaSite.Controllers
{
	[Authorize]
    public class AdministerController
		: Controller
    {
		public BuddhaDataContext DataContext { get; private set; }

		public UserManager<User> UserManager
		{
			get; set;
		}

		public AdministerController(BuddhaDataContext dataContext, UserManager<User> userManager)
		{
			this.DataContext = dataContext;

			this.UserManager = userManager;
		}

        public IActionResult Locations()
        {
            return View(new ListViewModel<Location>(this.DataContext.Location));
        }

        public IActionResult Teams()
        {
            return View(new ListViewModel<Team>(this.DataContext.Team));
        }

        public IActionResult Users()
        {
            return View(new ListViewModel<User>(this.DataContext.Users));
        }

        public IActionResult Tribes()
        {
            return View();
        }

        public IActionResult Levels()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            var records = new List<User>(this.DataContext.Users);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetLevels()
        {
            var records = new List<UserLevel>(this.DataContext.UserLevel);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetLocations()
        {
            var records = new List<Location>(this.DataContext.Location);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetRoles()
        {
            var records = new List<Role>(this.DataContext.Roles);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetTeams()
        {
            var records = new List<Team>(this.DataContext.Team);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetTribes()
        {
            var records = new List<Tribe>(this.DataContext.Tribe);
            int total = records.Count;
            return Json(new { records, total });
        }

        [HttpGet]
        public JsonResult GetHistoryOfReviews()
        {
            User CurrentUser = this.UserManager.GetUserAsync(this.User).Result;

            var records = new List<SelfReview>(this.DataContext.SelfReview.Where(Item => Item.UserId == CurrentUser.Id));

            int total = records.Count;

            return Json(new { records, total });
        }
    }
}
