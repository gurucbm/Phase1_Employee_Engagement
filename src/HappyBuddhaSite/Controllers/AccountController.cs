using HappyBuddhaSite.Core.Data;
using HappyBuddhaSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Controllers
{
	[Authorize]
	public class AccountController
		: Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManagerOfUser;
		private readonly RoleManager<Role> _roleManager;
		private readonly ILogger _logger;
		private IHostingEnvironment _hostingEnv;

		public BuddhaDataContext DataContext { get; private set; }

		private string DefaultAvatarFolder
		{
			get
			{
				return _hostingEnv.WebRootPath + "\\avatars";
			}
		}

		private string FileUploadTempFolderPath
		{
			get
			{
				return _hostingEnv.WebRootPath + "\\temp\\";
			}
		}

		public AccountController(
			UserManager<User> userManager,
			SignInManager<User> loginManager,
			RoleManager<Role> roleManager,
			ILoggerFactory ILoggerFactory,
			IHostingEnvironment env,
			BuddhaDataContext DataContext
		)
		{
			this._userManager = userManager;

			this._signInManagerOfUser = loginManager;

			this._roleManager = roleManager;

			this._logger = ILoggerFactory.CreateLogger<AccountController>();

			this._hostingEnv = env;

			this.DataContext = DataContext;
		}

		[AllowAnonymous]
		public IActionResult Register()
		{
			var registerViewModel = new RegisterViewModel() { UserName = this._userManager.GetUserName(this.User) };
			registerViewModel.BirthDate = DateTime.Today;

			return View(registerViewModel);

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public IActionResult Register(RegisterViewModel obj)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					AvatarId = obj.AvatarId
				,
					FirstName = obj.FirstName
				,
					Email = obj.Email
				,
					LastName = obj.LastName
				,
					NickName = obj.NickName
				,
					BirthDate = obj.BirthDate
				,
					UserName = obj.UserName
				};

				IdentityResult result = _userManager.CreateAsync(user, obj.Password).Result;

				if (result.Succeeded)
				{
					if (!_roleManager.RoleExistsAsync(Role.NORMAL_USER).Result)
					{
						Role role = new Role();

						role.Name = Role.NORMAL_USER;

						IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

						if (!roleResult.Succeeded)
						{
							ModelState.AddModelError(string.Empty, Resources.Resource.ResourceManager.GetString("ErrorRoleCreation"));

							return View(obj);
						}
					}

					_userManager.AddToRoleAsync(user, Role.NORMAL_USER).Wait();
                    
					DataContext.SaveChanges();
					this._userManager.UpdateAsync(user);
				

					return RedirectToAction("Login", "Account");
				}
				else ModelState.AddModelError("UserCreation", string.Join(Environment.NewLine, result.Errors.Select(Item => Item.Description).ToArray()));
			}

			return View(obj);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			ViewData["Title"] = Resources.Resource.ResourceManager.GetString("TitleLogin");

			return View(new LoginViewModel() { WindowsIdentity = this.User.Identity.Name });
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;

			if (ModelState.IsValid)
			{
				var result = await this._signInManagerOfUser.PasswordSignInAsync(model.WindowsIdentity, model.Password, model.RememberMe, lockoutOnFailure: false);

				if (result.Succeeded)
				{
					_logger.LogInformation(1, Resources.Resource.ResourceManager.GetString("LoginSuccess"));

					if (string.IsNullOrEmpty(returnUrl))

						return base.RedirectToAction("Index", "Home");

					return base.Redirect(returnUrl);
				}
				if (result.RequiresTwoFactor)
				{
					return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
				}
				if (result.IsLockedOut)
				{
					_logger.LogWarning(2, Resources.Resource.ResourceManager.GetString("UserAccountLocked"));

					return View("Lockout");
				}
				else
				{
					this.ViewData["ShowForgotPassword"] = true;

					ModelState.AddModelError(string.Empty, Resources.Resource.ResourceManager.GetString("InvalidLogin"));

					return View(model);
				}
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> LogOff()
		{
			await this._signInManagerOfUser.SignOutAsync();

			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		//
		// GET: /Account/SendCode
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
		{
			var user = await this._signInManagerOfUser.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
			{
				return View("Error");
			}

			return View(new SendCodeViewModel { /*Providers = factorOptions*/ ReturnUrl = returnUrl, RememberMe = rememberMe });
		}
	}
}
