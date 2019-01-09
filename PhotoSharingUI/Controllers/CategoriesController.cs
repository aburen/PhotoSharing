using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoSharing.BLL.Interfaces;
using PhotoSharing.BLL.Infrastructure;
using PhotoSharing.Models;
using PhotoSharing.BLL.BLLEtities;
using AutoMapper;


namespace PhotoSharing.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api")]
    public class CategoriesController : ApiController
    {
        ICategoryService categoryService;
        AutoMapperCollection mapperCollection;
        public CategoriesController(ICategoryService service)
        {
            categoryService = service;
            mapperCollection = new AutoMapperCollection();

        }
        // GET: api/Category
        [HttpGet]
        [Route("categories")]
        public IEnumerable<CategoryModel> Get()
        {
            var categories = categoryService.GetCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryBLL, CategoryModel>()).CreateMapper();
            var result = mapper.Map<IEnumerable<CategoryBLL>,IEnumerable<CategoryModel>>(categories);
            return result;
        }

        [HttpGet]
        [Route("categories/{id}")]
        public CategoryModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryBLL, CategoryModel>()).CreateMapper();
            return mapper.Map<CategoryBLL, CategoryModel>(categoryService.GetCategory(id));
        }

        [HttpPost]
        [Route("categories")]
        public void Post([FromBody]CategoryModel model)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryModel, CategoryBLL>()).CreateMapper();
            
            categoryService.CreateCategory(mapper.Map<CategoryModel,CategoryBLL>(model));
            
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]CategoryModel model)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryModel, CategoryBLL>()).CreateMapper();

            categoryService.EditCategory(mapper.Map<CategoryModel, CategoryBLL>(model));
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
