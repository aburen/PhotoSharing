using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using PhotoSharing.BLL.Interfaces;
using PhotoSharing.BLL.Services;

namespace PhotoSharing.Infrastructure
{
    public class NetworkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IUserService>().To<UserService>();
            Bind<IFileService>().To<FileService>();
        }
    }
}