using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
	public static class Extensions
	{
		public static void EnsureSeedData(this BuddhaDataContext BuddhaDataContext)
		{
			if (!BuddhaDataContext.Avatar.Any())
			{
				BuddhaDataContext.Avatar.AddRange(
					(
						from FilePath in Directory.EnumerateFiles(@"Resources\DefaultAvatars", "*.*")
						select new Avatar()
						{
							Content = File.ReadAllBytes(FilePath)
						}
					).ToArray()
				);

				BuddhaDataContext.SaveChanges();
			}
		}
	}
}
