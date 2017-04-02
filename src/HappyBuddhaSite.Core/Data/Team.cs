using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class Team
    {
		public Guid Id { get; set; }

		public String Name { get; set; }

		public TeamCycle Cycle { get; set; }

		public DateTime CurrentCycle { get; set; }

		public DateTime NextCycle { get; set; }

		public Boolean UsePreviousReview { get; set; }

		public virtual TeamLead Lead { get; set; }

		public virtual Director Director { get; set; }

		public virtual VicePresident VicePresident { get; set; }

		public virtual Guid CurrentSprintId { get; set; }
		public virtual Sprint CurrentSprint { get; set; }
	}
}