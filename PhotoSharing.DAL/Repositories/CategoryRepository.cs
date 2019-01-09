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
    class CategoryRepository : IRepository<Category>
    {
        private PhotoSharingContext db;
        public CategoryRepository(PhotoSharingContext context)
        {
            this.db = context;
        }
        public void Create(Category item)
        {
            if (item != null)
                db.Categories.Add(item);
            

        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
            
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
            
        }
    }
}
