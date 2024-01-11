
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;


namespace TgApp.Util
{
    public static class WindsorUtil
    {
        public static WindsorContainer Container = new WindsorContainer();
        private static readonly object instanceLock = new object();

        public static void Register()
        {
            Container.Register(Component.For<DbUtil>(),
                Component.For<VersionUtils>(),
                Component.For<TdExceptionHandle>(),
                Component.For<ResUtil>().LifestyleTransient(),
                Component.For<LoggingInterceptor>().LifestyleTransient());
            Container.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>().WithConfig("log4net.config"));
            Container.Register(Component.For<CheckUtil>());
        }

        private static void GetLastClient()
        {
            
          

        }
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    }
}
