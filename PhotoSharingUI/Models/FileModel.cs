using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingUI.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string AuthorEmail { get; set; }
    }
}