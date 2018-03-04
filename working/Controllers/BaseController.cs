using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using working.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace working.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 返回Json
        /// </summary>
        /// <returns>The json.</returns>
        /// <param name="backResult">处理结果</param>
        /// <param name="message">消息</param>
        /// <param name="data">返回数据</param>
        /// <param name="dataFormat">日期格式</param>
        protected JsonResult ToJson(BackResult backResult, string message = "", dynamic data = null,string dataFormat="yyyy年MM月dd日")
       {
           return new JsonResult(new {result=(int)backResult,data=data,message=message},new Newtonsoft.Json.JsonSerializerSettings(){ContractResolver=new LowerHelper(),DateFormatString=dataFormat});
       }
    }
}
