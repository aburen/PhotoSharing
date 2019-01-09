using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhotoSharing.BLL.Interfaces;
using PhotoSharing.BLL.Infrastructure;

using PhotoSharing.BLL.BLLEtities;
using AutoMapper;
using PhotoSharingUI.Models;
using System.Threading.Tasks;

namespace PhotoSharingUI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api")]
    public class FileController : ApiController
    {
        IFileService fileService;
        public FileController(IFileService service)
        {
            fileService = service;
        }
        // GET: api/File
        [HttpGet]
        [Route("files")]
        public IEnumerable<FileModel> Get()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileImageBLL, FileModel>()).CreateMapper();
            return mapper.Map<IEnumerable<FileImageBLL>, List<FileModel>>(fileService.GetFiles());
        }

        // GET: api/File/5
        public FileModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileImageBLL, FileModel>()).CreateMapper();
            return mapper.Map<FileImageBLL, FileModel>(fileService.FileDownload(id));
        }

        // POST: api/File
        public async Task<IHttpActionResult> Post([FromBody]FileModel model)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest();
            }
            var provider = new MultipartMemoryStreamProvider();
            string root = System.Web.HttpContext.Current.Server.MapPath("~/Files/");
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] fileArray = await file.ReadAsByteArrayAsync();

                using (System.IO.FileStream fs = new System.IO.FileStream(root + filename, System.IO.FileMode.Create))
                {
                    await fs.WriteAsync(fileArray, 0, fileArray.Length);
                }
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileModel, FileImageBLL> ()).CreateMapper();
                FileImageBLL img = mapper.Map<FileModel, FileImageBLL>(model);
                img.Path = root + filename;
                fileService.FileUpload(img);
            }
            return Ok("Files dowloaded");
        }

        // PUT: api/File/5
        public void Put(int id, [FromBody]FileModel model)
        {

        }

        // DELETE: api/File/5
        public void Delete(int id)
        {
            fileService.DeleteFile(id);
        }
    }
}
