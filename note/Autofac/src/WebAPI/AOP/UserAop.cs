﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.AOP
{
    public class UserAop : IInterceptor
    {　　　　//关键所在，在执行方法前后进行相关逻辑处理
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("新增用户前进行其他处理");

            //调用原有方法
            invocation.Proceed();

            Console.WriteLine("新增用户后进行其他处理");
        }
    }
}
