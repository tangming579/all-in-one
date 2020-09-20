using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AutofacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //程序集范围注入
            builder.RegisterAssemblyTypes(typeof(IManagerService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().PropertiesAutowired();
            //单个注册
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();

            //在控制器中使用属性依赖注入，其中注入属性必须标注为public
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
        }
    }
}
