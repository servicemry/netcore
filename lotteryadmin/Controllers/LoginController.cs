using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lotteryadmin.Models;
using Microsoft.AspNetCore.Http;

namespace lotteryadmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly appDbContext db;
        public LoginController(appDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckLogin(Manager model)
        {
            if (!string.IsNullOrEmpty(model.UserName))
            {
                if (!string.IsNullOrWhiteSpace(model.PassWord))
                {
                    var user = db.Manager.Where(m => m.UserName == model.UserName && m.PassWord == model.PassWord).Single();
                    if (user != null)
                    {
                        HttpContext.Session.SetString("uname", model.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult LoginOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

       
    }
}
