using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.DAL.Entities;

namespace PhotoSharing.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<User> Users { get; }
        IRepository<FileImage> Files { get; }

        void Save();
    }
}
