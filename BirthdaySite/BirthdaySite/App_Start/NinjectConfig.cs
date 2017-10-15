[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BirthdaySite.App_Start.NinjectConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BirthdaySite.App_Start.NinjectConfig), "Stop")]

namespace BirthdaySite.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Data.Entity;
    using BirthdaySite.Models;
    using MVCTemplate.Data.Common;
    using MVCTemplate.Data.Common.SaveContext;
    using MVCTemplate.Services.Data;
    using Microsoft.AspNet.SignalR;
    using BirthdaySite.App_Start.Helpers;
    using System.Security.Principal;
    using MVCTemplate.Data.Common.Repositories;

    public static class NinjectConfig
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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                GlobalHost.DependencyResolver = new NinjectSignalRDependencyResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(DbContext)).To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>)).InRequestScope();
            kernel.Bind<ISaveContext>().To<SaveContext>().InRequestScope();
            kernel.Bind<IGroupService>().To<GroupService>().InRequestScope();
            kernel.Bind<IFriendListService>().To<FriendListService>().InRequestScope();
            kernel.Bind<IPrincipal>().ToMethod(context => HttpContext.Current.User).InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind(typeof(IUserRepository<>)).To(typeof(UserRepository<>)).InRequestScope();
        }
    }
}
