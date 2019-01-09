using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.DAL.Entities;
using PhotoSharing.DAL.Interfaces;
using PhotoSharing.DAL.Context;
using System.Data.Entity;

namespace PhotoSharing.DAL.Repositories
{
    class FileImageRepository:IRepository<FileImage>
    {
        PhotoSharingContext db;
        public FileImageRepository(PhotoSharingContext context)
        {
            db = context;
        }

        public void Create(FileImage item)
        {
            db.Files.Add(item);
            
        }

        public void Delete(int id)
        {
            FileImage file = db.Files.Find(id);
            if (file != null)
                db.Files.Remove(file);
            
        }

        public FileImage Get(int id)
        {
            return db.Files.Find(id); 
        }

        public IEnumerable<FileImage> GetAll()
        {
            return db.Files;
        }

        public void Update(FileImage item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            
        }
    }
}
