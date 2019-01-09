using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DownloadsQuantity { get; set; }

        public virtual ICollection<FileImage> UploadedFiles { get; set; }
        public virtual ICollection<FileImage> DownloadedFiles { get; set; }

        public User()
        {
            UploadedFiles = new List<FileImage>();
            DownloadedFiles = new List<FileImage>();
        }
    }
}
