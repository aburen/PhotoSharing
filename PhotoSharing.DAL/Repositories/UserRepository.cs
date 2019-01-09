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
    public class UserRepository:IRepository<User>
    {
        PhotoSharingContext db;
        public UserRepository(PhotoSharingContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
           db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
