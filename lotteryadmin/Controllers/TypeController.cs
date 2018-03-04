using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lotteryadmin.Models;
using lotteryadmin.Utill;
using Microsoft.EntityFrameworkCore;

namespace lotteryadmin.Controllers
{
    public class TypeController : BaseController
    {
        private readonly appDbContext db;
        public TypeController(appDbContext db)
        {
            this.db=db;
        }
        // GET: /<controller>/
        public  IActionResult Index()
        {
            ViewData["username"] = HttpContext.Session.GetString("uname");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Query()
        {
            try
            {
                var list =await db.CPType.OrderBy(m=>m.Sort).ToListAsync();
                return Json(list);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> Modify(CPType model)
        {
            model.Name=PinyingHelper.MkPinyinString(model.Title);//转换编码
            if(model.Type==1){
                model.CodeList="0,1,2,3,4,5,6,7,8,9";
            }else if (model.Type==2)
            {
                model.CodeList="01,02,03,04,05,06,07,08,09,10,11";
            }
            model.ShortName=model.Title;
            var msg=0;
            try
            {
                db.CPType.Update(model);
                msg=await db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(msg);
        }
        [HttpPost]
        public async Task<JsonResult> Add(CPType model)
        {
            model.Name=PinyingHelper.MkPinyinString(model.Title);//转换编码
            model.Sort=1;
            if(model.Type==1){
                model.CodeList="0,1,2,3,4,5,6,7,8,9";
            }else if (model.Type==2)
            {
                model.CodeList="01,02,03,04,05,06,07,08,09,10,11";
            }
            model.ShortName=model.Title;
            var msg=0;
            try
            {
                db.CPType.Add(model);
                msg=await db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json(msg);
        }

        [HttpPost]
        public async Task<JsonResult> QueryModel(int? id)
        {
            try
            {
                var model=await db.CPType.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
                return Json(model);
            }
            catch (Exception  ex )
            {
                throw ex;
            }
        }
    }
}
