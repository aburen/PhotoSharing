using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoSharing.DAL.Entities
{
    public class FileImage
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        //public List<string> Description { get; set; }
        public DateTime CreationDate { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        
        public int? UserId { get; set; }
        public User Author { get; set; }
    }
}
