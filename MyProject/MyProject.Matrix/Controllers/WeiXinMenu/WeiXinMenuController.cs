﻿using MyProject.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Services.Extensions;
using MyProject.Core.Dtos;

namespace MyProject.Matrix.Controllers.WeiXinMenu
{
    public class WeiXinMenuController : BaseController
    {
        private readonly WeiXinMenuTask _task = new WeiXinMenuTask();
        private readonly WeiXinReplyMessageTask _replay = new WeiXinReplyMessageTask();

        public ActionResult Index()
        { 
            var name_1 = _task.GetById(1);
            ViewBag.name_1 = name_1 == null ? "菜单1" : name_1.name ;
            var name_2 = _task.GetById(2);
            ViewBag.name_2 = name_2 == null ? "菜单2" : name_2.name;
            var name_3 = _task.GetById(3);
            ViewBag.name_3 = name_3 == null ? "菜单3" : name_3.name;
            var name_11 = _task.GetById(11);
            ViewBag.name_11 = name_11 == null ? "菜单1-1" : name_11.name;
            var name_12 = _task.GetById(12);
            ViewBag.name_12 = name_12 == null ? "菜单1-2" : name_12.name;
            var name_13 = _task.GetById(13);
            ViewBag.name_13 = name_13 == null ? "菜单1-3" : name_13.name;
            var name_14 = _task.GetById(14);
            ViewBag.name_14 = name_14 == null ? "菜单1-4" : name_14.name;
            var name_15 = _task.GetById(15);
            ViewBag.name_15 = name_15 == null ? "菜单1-5" : name_15.name;
            var name_21 = _task.GetById(21);
            ViewBag.name_21 = name_21 == null ? "菜单2-1" : name_21.name;
            var name_22 = _task.GetById(22);
            ViewBag.name_22 = name_22 == null ? "菜单2-2" : name_22.name;
            var name_23 = _task.GetById(23);
            ViewBag.name_23 = name_23 == null ? "菜单2-3" : name_23.name;
            var name_24 = _task.GetById(24);
            ViewBag.name_24 = name_24 == null ? "菜单2-4" : name_24.name;
            var name_25 = _task.GetById(25);
            ViewBag.name_25 = name_25 == null ? "菜单2-5" : name_25.name;
            var name_31 = _task.GetById(31);
            ViewBag.name_31 = name_31 == null ? "菜单3-1" : name_31.name;
            var name_32 = _task.GetById(32);
            ViewBag.name_32 = name_32 == null ? "菜单3-2" : name_32.name;
            var name_33 = _task.GetById(33);
            ViewBag.name_33 = name_33 == null ? "菜单3-3" : name_33.name;
            var name_34 = _task.GetById(34);
            ViewBag.name_34 = name_34 == null ? "菜单3-4" : name_34.name;
            var name_35 = _task.GetById(35);
            ViewBag.name_35 = name_35 == null ? "菜单3-5" : name_35.name;
            ViewBag.replay = _replay.GetByReplayType().ToSelectList(c => c.MatchKey, c => c.MatchKey);
            return View();
        }

        [HttpPost]
        public ActionResult GetByMenuId(int menuId)
        {
            return Json(_task.GetById(menuId));
        }

        public ActionResult Save(string appid,string key,string media_id,int menuid,string name,string pagepath,string type,string url )
        {
            var menuinfo = _task.GetById(menuid);
            if (menuinfo == null)
            {
                menuinfo = new MyProject.Core.Entities.WeiXinMenu()
                {
                    creater = GetCurrentAdmin(),
                    createtime = DateTime.Now,
                    appid = appid,
                    key = key,
                    media_id = media_id,
                    menuid = menuid,
                    name = name,
                    pagepath = pagepath,
                    type = type,
                    url = url
                };
                _task.Add(menuinfo);
                return Json(new RequestResultDto() { Ret = 0, Msg = "添加成功" });
            }
            else
            {
                menuinfo.creater = GetCurrentAdmin();
                    menuinfo.createtime = DateTime.Now;
                   menuinfo.appid = appid;
                    menuinfo.key = key;
                    menuinfo.media_id = media_id;
                    menuinfo.name = name;
                    menuinfo.pagepath = pagepath;
                    menuinfo.type = type;
                    menuinfo.url = url;
                    _task.Update(menuinfo);
                    return Json(new RequestResultDto() { Ret = 0, Msg = "修改成功" });
            }
           
        }
    }
}
