using MyProject.Matrix.Controllers.Core;
using MyProject.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Matrix.Controllers.SysLog
{
    public class SysLogController : BaseController
    {
        private readonly SysLogTask _logTask = new SysLogTask();
        private readonly SysExceptionTask _extTask = new SysExceptionTask();

        [SupportFilter]
        public ActionResult IndexLog()
        {
            var list = _logTask.GetList();
            ViewBag.list = "{Rows:" + JsonConvert.SerializeObject(list) + ",Total:" + list.Count + "}";  //列表
            return View();
        }

       

        [SupportFilter]
        public ActionResult IndexExt(string helpLink,int pageIndex = 1, int pageSize = 15)
        {
            var model = _extTask.GetPagedList(helpLink,pageIndex, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult GetExt(int id)
        {
            return Json(_extTask.GetExt(id));
        }

    }
}
