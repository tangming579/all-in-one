using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPI.AOP;
using WebAPI.Interface;

namespace WebAPI.Models
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //程序集范围注入
            //builder.RegisterAssemblyTypes(typeof(IManagerService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().PropertiesAutowired();
            //单个注册
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();

            //在控制器中使用属性依赖注入，其中注入属性必须标注为public
            //var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            //builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();


            ////注册AOP拦截器
            //builder.RegisterType(typeof(UserAop));

            ////获取所有控制器类型并使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            //    .AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors()//开启切面，需要引入Autofac.Extras.DynamicProxy
            //    .InterceptedBy(typeof(UserAop))//指定拦截器，可以指定多个
            //    .PropertiesAutowired();

            //注册用户维护业务层

            //注册AOP拦截器
            builder.RegisterType(typeof(UserAop));
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()//开启切面，需要引入Autofac.Extras.DynamicProxy
                .InterceptedBy(typeof(UserAop));//指定拦截器，可以指定多个

        }
    }
}
