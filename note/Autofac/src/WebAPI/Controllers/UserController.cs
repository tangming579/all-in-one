using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //https://localhost:5001/api/User/AddUser?name=sss&age=12
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
       //这里已经通过Autofac 注册过了，直接通过构造函数注入即可
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
 
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("AddUser")]
        public IActionResult AddUser(string name, int age)
        {
           //正常调用用户新增操作
            _userService.AddUser(name, age);
            return Ok("Success!!");
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("RemoveUser")]
        public IActionResult RemoveUser(string name)
        {
            _userService.RemoveUser(name);
            return Ok("Success!!");
        }
    }
}
