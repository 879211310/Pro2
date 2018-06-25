using MyProject.Core.Enum;
using MyProject.Matrix.Controllers.Core;
using MyProject.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Services.Extensions;

namespace MyProject.Matrix.Controllers.SysLog
{
    public class SysLogController : BaseController
    {
        private readonly SysLogTask _logTask = new SysLogTask();
        private readonly SysExceptionTask _extTask = new SysExceptionTask();

        [SupportFilter]
        public ActionResult IndexLog(int logType=0, int logModule=0, int pageIndex = 1, int pageSize = 15)
        {

            ViewData["LogTypeList"] = LogTypeEnum.Add.ToSelectList();
            ViewData["LogModuleList"] = LogModuleEnum.Land.ToSelectList();
            var model = _logTask.GetPagedList(logType,logModule, pageIndex, pageSize);
            return View(model);
        }
        [HttpPost]
        public ActionResult GetLog(int id)
        {
            return Json(_logTask.GetSysLog(id));
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
