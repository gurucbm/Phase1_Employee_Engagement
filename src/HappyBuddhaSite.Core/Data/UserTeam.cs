using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class UserTeam
    {
		public Guid Id
		{
			get; set;
		}

		public virtual User User
		{
			get; set;
		}

		public virtual Team Team
		{
			get; set;
		}
	}
}
