using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingUI.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DownloadsQuantity { get; set; }
    }
}