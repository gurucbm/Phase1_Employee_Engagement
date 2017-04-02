using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using HappyBuddhaSite.Core.Data;
using Newtonsoft.Json.Serialization;
using HappyBuddhaSite.Services;
using Amazon.SimpleEmail;
using HappyBuddhaSite.Controllers;

namespace HappyBuddhaSite
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			this.Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<IISOptions>(
				options =>
				{ }
			);

			services.AddSingleton(c => Configuration);

			services
				.AddDbContext<BuddhaDataContext>(
					(options) =>
					{
						options.ConfigureWarnings(
							(Warnings) =>
							{
								//Warnings.Configuration.DefaultBehavior = WarningBehavior.Throw;
							}
						);

						options.UseSqlServer(
							Configuration.GetConnectionString("DefaultConnection")
						,	(o) => o.MigrationsAssembly("HappyBuddhaSite")
						);
					}
				);

			services.AddIdentity<User, Role>(
					(options) =>
					{
						options.Password.RequiredLength = 3;

						options.Password.RequireNonAlphanumeric = 
							options.Password.RequireUppercase = 
							options.Password.RequireLowercase = 
							options.Password.RequireDigit = false;

						options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
						options.Lockout.MaxFailedAccessAttempts = 10;
						options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
						options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
						options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";
						options.User.AllowedUserNameCharacters = options.User.AllowedUserNameCharacters.Insert(0, "\\");
					}
				)
				.AddEntityFrameworkStores<BuddhaDataContext, Guid>()
				.AddDefaultTokenProviders();

			services.AddMvc()
					.AddJsonOptions(
						options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()
					);

			services.AddDefaultAWSOptions(Configuration.GetAWSOptions());

			services.AddAWSService<IAmazonSimpleEmailService>();

			services.AddTransient<IEmailSender, AuthMessageSender>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));

			loggerFactory.AddDebug();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				app.UseBrowserLink();

				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<BuddhaDataContext>().Database.Migrate();

                    serviceScope.ServiceProvider.GetService<BuddhaDataContext>().EnsureSeedData();
                }
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseIdentity();

			app.UseCookieAuthentication(
				new CookieAuthenticationOptions()
				{
					AutomaticChallenge = true
				,	AuthenticationScheme = "Cookies"
				,	AutomaticAuthenticate = true
				,	LoginPath = new PathString("/Account/" + nameof(AccountController.Login))
				,	LogoutPath = new PathString("/Account/" + nameof(AccountController.LogOff))
				,	CookieSecure = CookieSecurePolicy.Always
				}
			);

			app.UseMvc(
				routes =>
                {
                    routes.MapRoute(name: "area-default", template: "{controller=Home}/{action=" + nameof(HomeController.Index) + "}");

                    routes.MapRoute(name: "default", template: "{area}/{controller}/{action}");

					routes.MapRoute("templates", "Template/{Name}", new { controller = "Template", action = nameof(TemplateController.Index) });
				}
			);
		}
	}
}
