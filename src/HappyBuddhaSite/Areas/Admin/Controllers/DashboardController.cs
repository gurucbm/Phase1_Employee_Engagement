using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HappyBuddhaSite.Core.Data;

namespace HappyBuddhaSite.Areas.Admin.Controllers
{   
    /// <summary>
    /// This controls the dashboard of the app. For now we show the full dashboard to all users.
    /// </summary>
    [Area("admin")]
    public class DashboardController
        : Controller
    {
		public DashboardController(
			UserManager<User> UserManager
		,	BuddhaDataContext BuddhaDataContext
		)
		{
			this.UserManager = UserManager;

			this.BuddhaDataContext = BuddhaDataContext;
		}

		public UserManager<User> UserManager { get; }

		public BuddhaDataContext BuddhaDataContext { get; }

        public IActionResult Index()
        {
			User CurrentUser = this.UserManager.GetUserAsync(this.User).Result;

            return View();
        }

        public IActionResult SelfReview()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Administration()
        {
            return View();
        }
        public IActionResult TeamReview()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LeadDashboard()
        {
            return View();
        }
        public IActionResult SprintReview()
        {
            return View();
        }
    }
}
