using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.Core.Data
{
    public class Role
		: IdentityRole<Guid>
    {

        public const string NORMAL_USER = "Normal User";
        public const string SUPER_USER = "Super User";
    }
}
