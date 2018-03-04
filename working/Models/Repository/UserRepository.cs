using System;
using Microsoft.Extensions.Configuration;
using working.Models.DataModel;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;

namespace working.Models.Repository
{
/// <summary>
/// 登陆仓储类
/// </summary>
    public class UserRepository:IUserRepository
    {
        /// <summary>
        /// 链接对象
        /// </summary>
        IDbConnection _con;
        /// <summary>
        /// 构造方法中初始化链接对象
        /// </summary>
        /// <param name="con">链接对象</param>
        /// <param name="conStr">链接字符串</param>
        public UserRepository(IDbConnection con)
        {
            _con = con;

        }
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <returns>UserRole</returns>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public UserRole Login(string userName, string password)
        {
            var user= _con.QuerySingleOrDefault<UserRole>("select users.*,roles.rolename from users join roles on users.roleid=roles.ID where username=@username and password=@password", new { username = userName, password = password });
            if(user==null)
            {
               throw new Exception("用户名或者密码错误！");
            }
            else
            {
                return user;
            }
        }
    }
}