using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HappyBuddhaSite.Core.Data;

namespace HappyBuddhaSite.api
{
    [Route("api/[controller]")]
    public class TeamController
		: Controller
    {
		public BuddhaDataContext BuddhaDataContext { get; private set; }

		public TeamController(BuddhaDataContext BuddhaDataContext)
		{
			this.BuddhaDataContext = BuddhaDataContext;
		}

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return this.BuddhaDataContext.Team.AsQueryable();
        }

        [HttpPost]
        public void Post(
			[FromBody]
			Team Team
		)
        {
			if (Team.Id != Guid.Empty)

				this.BuddhaDataContext.Team.Update(Team);

			else this.BuddhaDataContext.Team.Add(Team);

			this.BuddhaDataContext.SaveChanges(true);
        }

        [HttpPut("{id}")]
        public void Put(
			Guid			Id
		,	[FromBody]
			Team			Team
		)
        {
			this.BuddhaDataContext.Team.Update(Team);

			this.BuddhaDataContext.SaveChanges(true);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {
			this.BuddhaDataContext.Team.Remove(this.BuddhaDataContext.Team.Single(Item => Item.Id == Id));

			this.BuddhaDataContext.SaveChanges(true);
        }
    }
}
