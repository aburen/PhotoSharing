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
    public class FileService : IFileService
    {
        IUnitOfWork Database { get; set; }
        AutoMapperCollection mapperCollection;

        public FileService(IUnitOfWork uow)
        {
            Database = uow;
            mapperCollection = new AutoMapperCollection();
        }
        public FileImageBLL FileDownload(int id)
        {
            return Mapper.Map<FileImage, FileImageBLL>(Database.Files.Get(id));
        }

        public void FileUpload(FileImageBLL file)
        {
            Database.Files.Create(Mapper.Map<FileImageBLL, FileImage>(file));
            Database.Save();
            
        }

        public IEnumerable<FileImageBLL> GetFiles()
        {
           return mapperCollection.Map<FileImage,FileImageBLL>(Database.Files.GetAll());
        }

        public IEnumerable<FileImageBLL> GetFilesByCategory(string category)
        {
            return mapperCollection.Map<FileImage, FileImageBLL>(Database.Files.GetAll().Where(x => x.Category.CategoryName == category));
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void DeleteFile(int id)
        {
            Database.Files.Delete(id);
        }
    }
}
