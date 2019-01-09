using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSharing.BLL.BLLEtities;

namespace PhotoSharing.BLL.Interfaces
{
    public interface IFileService
    {
        void FileUpload(FileImageBLL file);
        FileImageBLL FileDownload(int id);
        IEnumerable<FileImageBLL> GetFiles();
        IEnumerable<FileImageBLL> GetFilesByCategory(string category);
        void Dispose();
        void DeleteFile(int id);
        //IEnumerable<FileImageBLL> GetFilesByTag(List<string> tags);
    }
}
