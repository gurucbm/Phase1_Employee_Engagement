using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyBuddhaSite.Core.Data
{
	public class User
		: IdentityUser<Guid>
	{
		public DateTime JoinedDate { get; set; }

        public Guid AvatarId { get; set; }
        public virtual Avatar Avatar { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public string Alias { get; set; }
		public virtual Location Location { get; set; }
		public virtual UserLevel Level { get; set; }

		public virtual Tribe Tribe { get; set; }

		//public virtual Guid SelectedTeamId { get; set; }

		//public virtual Team SelectedTeam { get; set; }

        public DateTime BirthDate { get; set; }

		public virtual IList<UserAvatar> UserAvatar { get; set; }
	}
}