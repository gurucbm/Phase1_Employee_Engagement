using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Controllers
{
    public class AvatarController
		: Controller
    {
		private UserManager<User> _userManager = default(UserManager<User>);

		public AvatarController(UserManager<User> userManager)
		{
			this._userManager = userManager;
		}

		[Authorize]
		public IActionResult Get(Guid Id)
		{
			return new FileStreamResult(new MemoryStream(this._userManager.GetUserAsync(this.User).Result.Avatar.Content), "image/jpeg");
		}
    }
}
