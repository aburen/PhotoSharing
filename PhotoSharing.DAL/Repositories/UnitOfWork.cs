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
    public class UnitOfWork:IUnitOfWork
    {
        PhotoSharingContext context;
        CategoryRepository categories;
        FileImageRepository files;
        UserRepository users;
        public UnitOfWork(string connectionString)
        {
            context = new PhotoSharingContext(connectionString);
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = new CategoryRepository(context);
                return categories;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (users == null)
                    users = new UserRepository(context);
                return users;
            }
        }

        public IRepository<FileImage> Files
        {
            get
            {
                if (files == null)
                    files = new FileImageRepository(context);
                return files;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); ;
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
