using CommonServiceLocator.SimpleInjectorAdapter;
using Demo.Application;
using Demo.Domain.Interface;
using Demo.Domain.Interface.Application;
using Demo.Domain.Interface.Service;
using Demo.Domain.Service;
using Demo.Infra.Repository;
using Demo.Infra.Repository.Config;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Demo.Infra.Ioc
{
    public static class IoC
    {
        public static void Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            var lifeStyle = Lifestyle.Scoped;

            container.Register<IProdutoApplication, ProdutoApplication>(lifeStyle);
            container.Register<IProdutoRepository, ProdutoRepository>(lifeStyle);
            container.Register<IProdutoService, ProdutoService>(lifeStyle);
            container.Register<IUnitOfWork, UnitOfWork>(lifeStyle);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());            

            Registration registration = container.GetRegistration(typeof(ArquiteturaContext)).Registration;

            registration.SuppressDiagnosticWarning(SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Reason of supperssion");            

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));

            container.Verify();
        }
    }
}
