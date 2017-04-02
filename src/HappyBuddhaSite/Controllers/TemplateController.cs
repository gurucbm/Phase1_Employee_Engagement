using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HappyBuddhaSite.Controllers
{
    public class TemplateController
		: Controller
    {
        public IActionResult Index(String Name)
        {
			return this.ViewComponent(Name);
        }
    }
}
