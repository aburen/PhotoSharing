using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSharing.DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual IEnumerable<FileImage> Pictures { get; set; }
        public Category()
        {
            Pictures = new List<FileImage>();
        }
    }
}
