using Gallery.Data.DBInteractions.Concrete;
using Gallery.Data.DBInteractions.Interface;
using Gallery.Data.EntityRepositories.Concrete;
using Gallery.Data.EntityRepositories.Interface;
using Gallery.Services.Interfaces;
using Gallery.Services.Services;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Gallery.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Gallery.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Gallery.WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Db interactions
            kernel.Bind<IDbFactory>().To<DbFactory>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            //Repositories
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<IDepartamentRepository>().To<DepartamentRepository>();
            kernel.Bind<IGenreRepository>().To<GenreRepository>();
            kernel.Bind<IImageRepository>().To<ImageRepository>();
            kernel.Bind<IPainterRepository>().To<PainterRepository>();
            kernel.Bind<IPictureRepository>().To<PictureRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITokenRepository>().To<TokenRepository>();

            //Services
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IDepartamentService>().To<DepartamentService>();
            kernel.Bind<IGenreService>().To<GenreService>();
            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<IPainterService>().To<PainterService>();
            kernel.Bind<IPictureService>().To<PictureService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ITokenSevice>().To<TokenService>();
            kernel.Bind<IUserService>().To<UserService>();
        }        
    }
}
