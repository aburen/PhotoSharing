using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.BLL.BLLEtities
{
    public class FileImageBLL
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public string Category { get; set; }
        public string AuthorEmail { get; set; }
    }
}
