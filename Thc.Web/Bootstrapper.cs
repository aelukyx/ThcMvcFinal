using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

using Thc.Interfaces.Services;
using Thc.Services.Services;

namespace Thc.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      container.RegisterType<IClienteService, ClienteService>();
      container.RegisterType<IProveedorService, ProveedorService>();
      container.RegisterType<IAutoService, AutoService>();
      container.RegisterType<IAlquilerService, AlquilerService>();
      RegisterTypes(container);
      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}