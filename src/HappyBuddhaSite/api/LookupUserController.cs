using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.api
{
	[Route("api/[controller]")]
    public class LookupUserController
		: Controller
    {
		public BuddhaDataContext BuddhaDataContext { get; private set; }

		public LookupUserController(BuddhaDataContext BuddhaDataContext)
			: base()
		{
			this.BuddhaDataContext = BuddhaDataContext;
		}

		[HttpGet]
		public IEnumerable<EnumValue<Guid, dynamic>> Get(String Query)
		{
			String[] keywords = Query.Split(' ');

			Func<User, String> UserDescriber = (Item) => Item.Email + " " + Item.Alias + " " + Item.FirstName + " " + Item.LastName + " " + Item.NickName + " " + Item.UserName;

			return this.BuddhaDataContext.Users
				.Select(Item => new { User = Item, Description = UserDescriber(Item) })
				.Where(
					(Item) => keywords.Any(K => Item.Description.Contains(K))
				)
				.Select(
					(Item) => new EnumValue<Guid, dynamic>(
						Item.User.Id
					,	new
						{
							AvatarId = Item.User.AvatarId
						,	Alias = Item.User.Alias
						,	NickName = Item.User.NickName
						,	FirstName = Item.User.FirstName
						,	LastName = Item.User.LastName
						,	Email = Item.User.Email
						}
					)
				);
		}
    }
}
