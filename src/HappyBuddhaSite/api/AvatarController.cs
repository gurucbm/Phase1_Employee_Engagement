using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.api
{
	[Route("api/[controller]")]
	public class AvatarController
		: Controller
	{
		public BuddhaDataContext BuddhaDataContext { get; private set; }

		public UserManager<User> UserManager { get; private set; }

		public AvatarController(BuddhaDataContext BuddhaDataContext, UserManager<User> UserManager)
			: base()
		{
			this.BuddhaDataContext = BuddhaDataContext;

			this.UserManager = UserManager;
		}

		public class AvatarIds
			: Avatar
		{
			public Boolean IsSelected { get; set; }
		}

		[HttpGet]
		public IEnumerable<AvatarIds> Get()
		{
			User CurrentUser = this.UserManager.GetUserAsync(this.User).Result;

            Guid? AvatarId = CurrentUser?.AvatarId;

			AvatarIds[] AllAvatars = this.BuddhaDataContext.Avatar.Select(Item => new AvatarIds() { Id = Item.Id, IsSelected = Item.Id == AvatarId.GetValueOrDefault(), Type = Item.Type }).ToArray();

			AvatarIds[] Result = AllAvatars.Where(Item => Item.Type == AvatarType.Default).ToArray();

			if (CurrentUser != null)
			{
				UserAvatar[] UserAvatars = this.BuddhaDataContext.UserAvatar.Where(Item => Item.UserId == CurrentUser.Id).ToArray();
				
				Result = Result.Concat(
					from assignment in UserAvatars
					join Item in AllAvatars.Where(Item => Item.Type == AvatarType.Custom)
					on assignment.AvatarId equals Item.Id
					where CurrentUser != null && assignment.UserId == CurrentUser.Id
					select new AvatarIds() { Id = Item.Id, IsSelected = Item.Id == AvatarId.GetValueOrDefault() }
				)
				.ToArray();
			}

			return Result.AsQueryable();
		}

		[HttpGet]
		[Route("{Id}")]
		public IActionResult Get(Guid Id)
		{
			return base.File(this.BuddhaDataContext.Avatar.Single(Item => Item.Id == Id).Content, "image/jpeg");
		}

		[HttpGet]
		[Route("Current")]
		[Authorize]
		public IActionResult Current()
		{
			User CurrentUser = this.UserManager.GetUserAsync(this.User).Result;

			if (CurrentUser == default(User))

				return base.NoContent();

			Avatar SelectedAvatar = this.BuddhaDataContext.Avatar.Where(Item => Item.Id == CurrentUser.AvatarId).SingleOrDefault();

			if (SelectedAvatar == default(Avatar))

				return base.NoContent();

			return base.File(SelectedAvatar.Content, "image/jpeg");
		}

		[HttpPost]
		[Authorize]
		public void Post()
		{
			Avatar Avatar = new Avatar() { Type = AvatarType.Custom };

			using (var Stream = Request.Form.Files[0].OpenReadStream())
			{
				using (var MemoryStream = new MemoryStream())
				{
					Stream.CopyTo(MemoryStream);

					Avatar.Content = MemoryStream.ToArray();
				}
			}

			this.BuddhaDataContext.UserAvatar.Add(
				new UserAvatar()
				{
					User = this.UserManager.GetUserAsync(this.User).Result
				,	Avatar = Avatar
				}
			);

			this.BuddhaDataContext.SaveChanges();			
		}

		[HttpPut("{id}")]
		[Authorize]
		public void Put(
			Guid Id
		, [FromBody]
			Team            Team
		)
		{
			this.BuddhaDataContext.Team.Update(Team);

			this.BuddhaDataContext.SaveChanges(true);
		}

		[HttpDelete("{id}")]
		[Authorize]
		public void Delete(Guid Id)
		{
			this.BuddhaDataContext.Team.Remove(this.BuddhaDataContext.Team.Single(Item => Item.Id == Id));

			this.BuddhaDataContext.SaveChanges(true);
		}

		[Route("CanAdd")]
		[HttpGet]
		public IActionResult CanAdd()
		{
			if (this.UserManager.GetUserAsync(this.User).Result == default(User))

				return base.Json(new { Result = false });

			return base.Json(new { Result = true });
		}
	}
}
