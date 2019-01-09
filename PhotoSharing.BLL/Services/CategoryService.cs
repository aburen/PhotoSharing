using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.BLL.BLLEtities;
using PhotoSharing.BLL.Interfaces;
using PhotoSharing.DAL.Interfaces;
using PhotoSharing.DAL.Entities;
using AutoMapper;
using PhotoSharing.BLL.Infrastructure;

namespace PhotoSharing.BLL.Services
{
   public class CategoryService : ICategoryService
    {
        IUnitOfWork Database { get; set; }
        AutoMapperCollection mapperCollection;
        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }

        public void CreateCategory(CategoryBLL category)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryBLL, Category> ()).CreateMapper();
            Category result = mapper.Map<CategoryBLL,Category>(category);
            Database.Categories.Create(result);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditCategory(CategoryBLL category)
        {
            Category result = Mapper.Map<CategoryBLL,Category>(category);
            Database.Categories.Update(result);
        }

        public IEnumerable<CategoryBLL> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryBLL>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>,List<CategoryBLL>>(Database.Categories.GetAll());
        }

        public CategoryBLL GetCategory(int id)
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<Category,CategoryBLL>()).CreateMapper();
            return mapper.Map<Category, CategoryBLL>(Database.Categories.Get(id));
        }
    }
}
