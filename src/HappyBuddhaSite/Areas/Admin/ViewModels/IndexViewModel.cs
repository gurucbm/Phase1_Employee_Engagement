using HappyBuddhaSite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Areas.Admin.ViewModels
{
    public class IndexViewModel
    {
		public IndexViewModel(
			SelfReviewSummary SelfReviewSummary
		,	SelfReviewSummary[] SelfReviewSummaryHistory
		)
		{
			this.SelfReviewSummary = SelfReviewSummary;

			this.SelfReviewSummaryHistory = SelfReviewSummaryHistory;
		}

		public SelfReviewSummary SelfReviewSummary
		{
			get; set;
		}

		public SelfReviewSummary[] SelfReviewSummaryHistory
		{
			get; set;
		}
	}
}
