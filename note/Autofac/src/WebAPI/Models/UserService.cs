using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;

namespace WebAPI.Models
{
    public class UserService : IUserService
    {
        /// <summary>
        /// 模拟新增用户，这里没有写数据处理层
        /// </summary>
        public int AddUser(string strName, int nAge)
        {
            Console.WriteLine("新增用户到数据库中");
            return 1;
        }
    }
}
