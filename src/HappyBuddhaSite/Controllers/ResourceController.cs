using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HappyBuddhaSite.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.IO;
using HappyBuddhaSite.ViewComponents;

namespace HappyBuddhaSite.Controllers
{
	public class ResourceController
		: Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly BuddhaDataContext _buddhaDataContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ResourceController(BuddhaDataContext buddhaDataContext, UserManager<User> userManager, IHostingEnvironment hostingEnvironment)
		{
			this._buddhaDataContext = buddhaDataContext;
            this._hostingEnvironment = hostingEnvironment;
			this._userManager = userManager;
		}

        private string FileUploadTempFolderPath
        {
            get
            {
                return _hostingEnvironment.WebRootPath + "\\temp\\";
            }
        }

        public IActionResult RefreshViewComponent()
        {
            string uploadedFileName = Request.Form["filename"];
            return ViewComponent(typeof(AvatarListViewComponent), new { uploadedFileName });
        }

        [HttpPost]
        public IActionResult UploadFilesAjax()
        {
            var file = Request.Form.Files[0];
            var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
            filename = Guid.NewGuid() + "_" + filename;

            var fileNamePath = FileUploadTempFolderPath + filename;
            using (FileStream fs = System.IO.File.Create(fileNamePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            return Json(new { success = true, message = filename });
        }
    }
}
