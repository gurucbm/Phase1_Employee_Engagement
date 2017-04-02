using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class Avatar
    {
		public Guid Id { get; set; }

		public byte[] Content { get; set; }

		public AvatarType Type { get; set; }
	}
}
