using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HappyBuddhaSite.Controllers
{
	public class HomeController
		: Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManagerOfUser;

		public HomeController(UserManager<User> userManager, SignInManager<User> signInManagerOfUser)
		{
			this._userManager = userManager;

			this._signInManagerOfUser = signInManagerOfUser;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			//return base.Redirect("/landing/index.html");

			User user = _userManager.GetUserAsync(HttpContext.User).Result;

			if (user == default(User))
			{
				if (this.User.Identity.Name != null)

					this.ViewBag.CurrentUser = this._userManager.FindByNameAsync(this.User.Identity.Name).Result;

				return base.View("NonRegisteredIndex");
			}
			else
			{
				ViewBag.Message = Resources.Resource.ResourceManager.GetString("WelcomeMsg") + $"{user.NickName}!";

				if (_userManager.IsInRoleAsync(user, "NormalUser").Result)
				{
					ViewBag.RoleMessage = Resources.Resource.ResourceManager.GetString("NormalUserMsg");
				}
			}

			return base.RedirectToRoute("default", new { area = "Admin", controller = "Dashboard", action = "Index" });
		}

		public IActionResult Error()
		{
			return View();
		}       
    }
}
