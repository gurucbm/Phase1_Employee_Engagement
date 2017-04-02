using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class SelfReview
		: Review
    {
		public Int16 WorkRate
		{
			get; set;
		}

		public String WorkRateRemarks
		{
			get; set;
		}

		public Int16 TasksRate
		{
			get; set;
		}

		public String TasksRateRemarks
		{
			get; set;
		}

		public Int16 TeamRate
		{
			get; set;
		}

		public String TeamRateRemarks
		{
			get; set;
		}

		public Int16 CompanyRate
		{
			get; set;
		}

		public String CompanyRateRemarks
		{
			get; set;
		}

		public Int16 SelfInvestmentRate
		{
			get; set;
		}

		public String SelfInvestmentRateRemarks
		{
			get; set;
		}

		public String TeamSuggestions
		{
			get; set;
		}

		public String CompanySuggestions
		{
			get; set;
		}
	}
}
