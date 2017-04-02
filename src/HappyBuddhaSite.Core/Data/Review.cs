using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class Review
    {
		public Guid Id { get; set; }

		public virtual Sprint CurrentSprint { get; set; }

		public virtual Guid UserId { get; set; }

		public virtual User User { get; set; }
	}
}
