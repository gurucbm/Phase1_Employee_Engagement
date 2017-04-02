using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBuddhaSite.ViewModels
{
    public class AvatarViewModel
    {
        public bool Selected { get; set; }
        public string AvatarName { get; set; }
        public byte[] Content { get; set; }
    }
}
