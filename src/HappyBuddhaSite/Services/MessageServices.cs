using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Services
{
	public class AuthMessageSender
		: IEmailSender
		, ISmsSender
	{
		public AuthMessageSender(IConfiguration Configuration, IAmazonSimpleEmailService IAmazonSimpleEmailService)
			: base()
		{
			var Email = Configuration["Email"];

			this.Configuration = Configuration;

			this.IAmazonSimpleEmailService = IAmazonSimpleEmailService;
		}

		public IConfiguration Configuration { get; private set; }

		public IAmazonSimpleEmailService IAmazonSimpleEmailService { get; private set; }

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			await this.IAmazonSimpleEmailService.SendEmailAsync(
				new SendEmailRequest("88813a9273974bb28cd3962c3f@gmail.com"
				,	new Destination(
						new [] { email }.ToList()
					)
				,	new Message(
						new Content("Happy Buddha! - " + subject)
					,	new Body(
							new Content(message)
						)
					)
				)
			);
		}

		public Task SendSmsAsync(string number, string message)
		{
			return Task.FromResult(0);
		}
	}
}
