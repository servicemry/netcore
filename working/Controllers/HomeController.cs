using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using working.Models;
using Microsoft.Extensions.Logging;//引入loggin命名空间
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;//
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using working.Models.Repository;
using working.Models.DataModel;

namespace working.Controllers
{
    [Authorize(Roles="Manager,Leader,Employee")]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 日志类
        /// </summary>
         readonly ILogger<HomeController> _logger;
        /// <summary>
        /// 用户仓储类
        /// </summary>
         readonly IUserRepository _userRepository;
         /// <summary>
         /// 部门仓储类
         /// </summary>
        readonly IDepartRepository _departRepository;

        public HomeController(ILogger<HomeController> logger,IUserRepository userRepository,IDepartRepository departRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _departRepository = departRepository;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("这是Home下的Index action");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]//允许所有人访问
        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.returnUrl = returnUrl;
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(string userName,string password,string returnUrl)
        {
            try
            {
                var userRole = _userRepository.Login(userName, password);
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Role,userRole.RoleName),
                    new Claim(ClaimTypes.Name,userRole.Name),
                    new Claim(ClaimTypes.Sid,userRole.ID.ToString())
                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(new ClaimsIdentity(claims) ));
                return new RedirectResult(string.IsNullOrEmpty(returnUrl)?"/":returnUrl);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }
        
        public IActionResult Department()
        {
            return View();
        }
        /// <summary>
        /// 获取所有带父级部门的部门信息
        /// </summary>
        /// <returns>The PD epartment.</returns>
        [HttpGet("getallpdepartment")]
        public IActionResult GetPDepartment()
        {
            try
            {
                var lst=_departRepository.GetPDepartment();
                //自定义返回json方法
                return ToJson(BackResult.Success,data:lst);
            }
            catch (Exception ex)
            {
                return ToJson(BackResult.Exception, message: ex.Message);
            }
        }

        [HttpPost("adddepartment")]
        public IActionResult AddDepartment(Department department)
        {
            try
            {
                var result=_departRepository.ModifyDepartment(department);
                return ToJson(result?BackResult.Success:BackResult.Fail,message:result?"添加成功":"添加失败");
            }
            catch (Exception ex)
            {
                return ToJson(BackResult.Exception,message:ex.Message);
            }
        }

        [HttpPost("modifydepartment")]
        public IActionResult ModifyDepartment(Department department)
        {
            try
            {
                var result=_departRepository.ModifyDepartment(department);
                return ToJson(result?BackResult.Success:BackResult.Fail,message:result?"修改成功":"修改失败");
            }
            catch (Exception ex)
            {
                return ToJson(BackResult.Exception,message:ex.Message);
            }
        }

        [HttpDelete("removedepartment")]
        public IActionResult RemoveDepartment(int departmentID)
        {
            try
            {
                var result=_departRepository.RemoveDepartment(departmentID);
                return ToJson(result?BackResult.Success:BackResult.Fail,message:result?"删除成功":"删除失败");
            }
            catch (Exception ex)
            {
                return ToJson(BackResult.Exception,message:ex.Message);
            }
        }
    }
}
