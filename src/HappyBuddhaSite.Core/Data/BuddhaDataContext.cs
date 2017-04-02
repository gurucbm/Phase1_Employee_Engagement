using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
	public class BuddhaDataContext
		: IdentityDbContext<User, Role, Guid>
	{
		public BuddhaDataContext(
				DbContextOptions<BuddhaDataContext> options
			) : base(options)
		{ }

		public DbSet<UserLevel> UserLevel { get; set; }

		public DbSet<Location> Location { get; set; }

		public DbSet<Team> Team { get; set; }

		public DbSet<Sprint> Sprint { get; set; }

		public DbSet<UserTeam> UserTeam { get; set; }

		public DbSet<Tribe> Tribe { get; set; }

        public DbSet<Avatar> Avatar { get; set; }

        public DbSet<UserAvatar> UserAvatar { get; set; }

        public DbSet<SelfReview> SelfReview { get; set; }

        public DbSet<TeamReview> TeamReview { get; set; }

		public DbSet<SelfReviewSummary> SelfReviewSummary
		{
			get; set;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Model.GetEntityTypes().SelectMany(Item => Item.GetForeignKeys()).ToList().ForEach(Item => Item.DeleteBehavior = Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
