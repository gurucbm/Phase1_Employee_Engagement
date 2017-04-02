using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class TeamReview
		: Review
    {
		public User Member
		{
			get; set;
		}

		public Int16 EffortRate
		{
			get; set;
		}

		public Int16 AssistsRate
		{
			get; set;
		}

		public Int16 MissesRate
		{
			get; set;
		}

		public Int16 InnovationRate
		{
			get; set;
		}

		public Int16 QualityRate
		{
			get; set;
		}

		public String Time
		{
			get; set;
		}

		public Int16 Points
		{
			get; set;
		}

		public String Notes
		{
			get; set;
		}
	}
}
