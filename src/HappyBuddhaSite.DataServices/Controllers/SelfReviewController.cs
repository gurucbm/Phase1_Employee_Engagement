using HappyBuddhaSite.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace HappyBuddhaSite.DataServices.Controllers
{
	public class SelfReviewController
		: BaseController<Guid, SelfReview>
	{
		protected override DbSet<SelfReview> Set
		{
			get
			{
				return base.DataContext.SelfReview;
			}
		}

		protected override Func<SelfReview, Guid, bool> IsEqualToKey
		{
			get
			{
				return (Item, Key) => Item.Id == Key;
			}
		}
	}
}