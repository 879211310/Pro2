using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Web.Controllers.WeiXinShare
{
    public class WeiXinShareController : Controller
    { 

        public ActionResult Index()
        {
            ViewBag.WxNickName = "zl";
            ViewBag.Score = 888;
            return View();
        }

    }
}
