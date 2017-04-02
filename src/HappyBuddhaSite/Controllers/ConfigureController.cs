using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HappyBuddhaSite.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace HappyBuddhaSite.Controllers
{
	[Authorize]
    public class ConfigureController
		: Controller
    {
		private UserManager<User> UserManager;

		private BuddhaDataContext BuddhaDataContext;

		public ConfigureController(BuddhaDataContext BuddhaDataContext, UserManager<User> UserManager)
			: base()
		{
			this.BuddhaDataContext = BuddhaDataContext;

			this.UserManager = UserManager;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult Account()
        {
            return View(this.UserManager.GetUserAsync(this.User).Result);
        }

		[HttpPost]
        public IActionResult Account(User User)
        {
			User OriginalUser = this.UserManager.GetUserAsync(this.User).Result;

			OriginalUser.AvatarId = User.AvatarId;

			OriginalUser.FirstName = User.FirstName;

			OriginalUser.LastName = User.LastName;

			OriginalUser.NickName = User.NickName;

			OriginalUser.Email = User.Email;

			OriginalUser.Location = User.Location;

			OriginalUser.Tribe = User.Tribe;

			OriginalUser.Level = User.Level;

			IdentityResult Result = this.UserManager.UpdateAsync(OriginalUser).Result;

			if (!Result.Succeeded)

				Result.Errors.ToList().ForEach(Item => this.ModelState.AddModelError("Result", Item.Description));

            return View();
        }

		[Authorize]
        public IActionResult Team()
        {
            return View();
        }

		[Authorize]
        public IActionResult Members()
        {
            return View(this.BuddhaDataContext.Users.Except(new [] { this.UserManager.GetUserAsync(this.User).Result }));
        }

		[Authorize]
        public IActionResult Sprint()
        {
            return View();
        }

    }
}
