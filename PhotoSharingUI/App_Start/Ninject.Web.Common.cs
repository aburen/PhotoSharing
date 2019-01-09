[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PhotoSharing.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PhotoSharing.App_Start.NinjectWebCommon), "Stop")]

namespace PhotoSharing.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System.Web.Http;
    using Ninject.Web.WebApi;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using PhotoSharing.Infrastructure;
    using PhotoSharing.BLL.Infrastructure;
    using System.Web.Mvc;
    using Ninject.Modules;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            NinjectModule networkModule = new NetworkModule();
            NinjectModule serviceModule = new ServiceModule("DBConnection");
            var kernel = new StandardKernel(networkModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

        }
    }
}