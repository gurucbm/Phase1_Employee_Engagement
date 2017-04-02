using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HappyBuddhaSite.Core.Data;

namespace HappyBuddhaSite.Migrations
{
    [DbContext(typeof(BuddhaDataContext))]
    [Migration("20161124112606_M3")]
    partial class M3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Avatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Avatar");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.SelfReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("CompanyRate");

                    b.Property<string>("CompanyRateRemarks");

                    b.Property<string>("CompanySuggestions");

                    b.Property<Guid?>("CurrentSprintId");

                    b.Property<short>("SelfInvestmentRate");

                    b.Property<string>("SelfInvestmentRateRemarks");

                    b.Property<short>("TasksRate");

                    b.Property<string>("TasksRateRemarks");

                    b.Property<short>("TeamRate");

                    b.Property<string>("TeamRateRemarks");

                    b.Property<string>("TeamSuggestions");

                    b.Property<Guid?>("UserId");

                    b.Property<short>("WorkRate");

                    b.Property<string>("WorkRateRemarks");

                    b.HasKey("Id");

                    b.HasIndex("CurrentSprintId");

                    b.HasIndex("UserId");

                    b.ToTable("SelfReview");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Sprint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Sprint");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CurrentCycle");

                    b.Property<Guid?>("CurrentSprintId");

                    b.Property<Guid?>("CycleId");

                    b.Property<Guid?>("DirectorId");

                    b.Property<Guid?>("LeadId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("NextCycle");

                    b.Property<bool>("UsePreviousReview");

                    b.Property<Guid?>("VicePresidentId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentSprintId");

                    b.HasIndex("CycleId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("LeadId");

                    b.HasIndex("VicePresidentId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.TeamCycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("TeamCycle");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.TeamReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("AssistsRate");

                    b.Property<Guid?>("CurrentSprintId");

                    b.Property<short>("EffortRate");

                    b.Property<short>("InnovationRate");

                    b.Property<Guid?>("MemberId");

                    b.Property<short>("MissesRate");

                    b.Property<string>("Notes");

                    b.Property<short>("Points");

                    b.Property<short>("QualityRate");

                    b.Property<string>("Time");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentSprintId");

                    b.HasIndex("MemberId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamReview");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Tribe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tribe");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Alias");

                    b.Property<Guid>("AvatarId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("JoinedDate");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("LevelId");

                    b.Property<Guid?>("LocationId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NickName");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<Guid?>("TribeId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("LevelId");

                    b.HasIndex("LocationId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("TribeId");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.UserAvatar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AvatarId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAvatar");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.UserLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("UserLevel");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.UserTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("TeamId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTeam");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Director", b =>
                {
                    b.HasBaseType("HappyBuddhaSite.Core.Data.User");


                    b.ToTable("Director");

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.TeamLead", b =>
                {
                    b.HasBaseType("HappyBuddhaSite.Core.Data.User");


                    b.ToTable("TeamLead");

                    b.HasDiscriminator().HasValue("TeamLead");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.VicePresident", b =>
                {
                    b.HasBaseType("HappyBuddhaSite.Core.Data.User");


                    b.ToTable("VicePresident");

                    b.HasDiscriminator().HasValue("VicePresident");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.SelfReview", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Sprint", "CurrentSprint")
                        .WithMany()
                        .HasForeignKey("CurrentSprintId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.Team", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Sprint", "CurrentSprint")
                        .WithMany()
                        .HasForeignKey("CurrentSprintId");

                    b.HasOne("HappyBuddhaSite.Core.Data.TeamCycle", "Cycle")
                        .WithMany()
                        .HasForeignKey("CycleId");

                    b.HasOne("HappyBuddhaSite.Core.Data.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("HappyBuddhaSite.Core.Data.TeamLead", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId");

                    b.HasOne("HappyBuddhaSite.Core.Data.VicePresident", "VicePresident")
                        .WithMany()
                        .HasForeignKey("VicePresidentId");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.TeamReview", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Sprint", "CurrentSprint")
                        .WithMany()
                        .HasForeignKey("CurrentSprintId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.User", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.HasOne("HappyBuddhaSite.Core.Data.UserLevel", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("HappyBuddhaSite.Core.Data.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("HappyBuddhaSite.Core.Data.Tribe", "Tribe")
                        .WithMany()
                        .HasForeignKey("TribeId");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.UserAvatar", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User", "User")
                        .WithMany("UserAvatar")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HappyBuddhaSite.Core.Data.UserTeam", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("HappyBuddhaSite.Core.Data.Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.HasOne("HappyBuddhaSite.Core.Data.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });
        }
    }
}
