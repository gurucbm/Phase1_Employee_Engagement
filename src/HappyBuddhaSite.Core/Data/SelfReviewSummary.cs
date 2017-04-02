using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class SelfReviewSummary
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id
		{
			get; set;
		}

		public virtual Guid SelfReviewId { get; set; }

		public virtual SelfReview SelfReview
		{
			get; set;
		}

		public virtual Guid TeamId { get; set; }

		public virtual Team Team
		{
			get; set;
		}

		public virtual Guid UserId { get; set; }

		public virtual User User
		{
			get; set;
		}

		public virtual Guid SprintId { get; set; }

		public virtual Sprint Sprint
		{
			get; set;
		}

		public Int16 SelfRate
		{
			get; set;
		}

		public Int16 TeamRate
		{
			get; set;
		}

		public Int16 CompanyRate
		{
			get; set;
		}

		public Int16 OveralRate
		{
			get; set;
		}
	}
}
