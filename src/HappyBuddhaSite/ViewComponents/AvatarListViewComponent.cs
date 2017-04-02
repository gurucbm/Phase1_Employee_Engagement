using HappyBuddhaSite.Core.Data;
using HappyBuddhaSite.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.ViewComponents
{
    [ViewComponent(Name = "AvatarList")]
    public class AvatarListViewComponent : ViewComponent
    {
        private readonly BuddhaDataContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<User> _userManager;

        private string FileUploadTempFolderPath
        {
            get
            {
                return _hostingEnvironment.WebRootPath + "\\temp\\";
            }
        }

        private string DefaultAvatarFolder
        {
            get
            {
                return _hostingEnvironment.WebRootPath + "\\avatars";
            }
        }

        public AvatarListViewComponent(BuddhaDataContext context, IHostingEnvironment hostingEnvironment, UserManager<User> userManager)
        {
            _db = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IViewComponentResult> InvokeAsync(string uploadedFileName)
        {
            var items = await GetItemsAsync(uploadedFileName);

            return View();
        }

        private Task<List<AvatarViewModel>> GetItemsAsync(string fileNameUploaded)
        {            
			return Task<List<AvatarViewModel>>.FromResult(new List<AvatarViewModel>());

            //var list = new List<AvatarViewModel>();

            //string[] fileEntries = Directory.GetFiles(DefaultAvatarFolder); 
            //foreach (string file in fileEntries)
            //{
            //    var avatarViewModel = new AvatarViewModel()
            //    {
            //        AvatarName = Path.GetFileName(file),
            //        Content = File.ReadAllBytes(file)
            //    };

            //    list.Add(avatarViewModel);
            //}

            //var user = this._userManager.GetUserAsync(HttpContext.User).Result;


            //if (fileNameUploaded != null)
            //{
            //    list.Add(new AvatarViewModel() { AvatarName = fileNameUploaded, Content = File.ReadAllBytes(FileUploadTempFolderPath + fileNameUploaded), Selected = true });
            //}
            //else
            //{
            //    if (user != null)
            //    {
            //        //var avatar = _db.Avatar.FirstOrDefault(a => a.Owner == user);
            //        //if (avatar != null)
            //        //{
            //        //    list.Add(new AvatarViewModel() { AvatarName = avatar.Id.ToString(), Content = avatar.Content, Selected = true });
            //        //}
            //        //else
            //        //{
            //        //    list[0].Selected = true; //make first as selected
            //        //}
            //    }
            //    else
            //    {
            //        list[0].Selected = true; //make first as selected
            //    }
            //}

            //return Task.Run(() => list);
        }
    }
}
