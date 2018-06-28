using MyProject.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Matrix.Controllers.WeiXinMenu
{
    public class WeiXinMenuController : BaseController
    {
        private readonly WeiXinMenuTask _task = new WeiXinMenuTask();

        public ActionResult Index()
        {
            return View();
        }

    }
}
