using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.BLL.BLLEtities;

namespace PhotoSharing.BLL.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryBLL category);
        void EditCategory(CategoryBLL category);
        CategoryBLL GetCategory(int id);
        IEnumerable<CategoryBLL> GetCategories();
        void Dispose();
    }
}
