using System.Linq;
using System.Web.Mvc;
using MyProject.Matrix.Controllers.SysManage.ViewModels;
using MyProject.Core.Entities;
using MyProject.Tasks;
using MyProject.Services.Mappers;
using MyProject.Task;
using System;
using MyProject.Matrix.Controllers.Account.ViewModels;
using MyProject.Services.Utility;
using MyProject.Core.Dtos;
using MyProject.Core.Enum;

namespace MyProject.Matrix.Controllers.Home
{
    public class HomeController : BaseController
    { 
        private readonly AdminRoleMenuTask _roleMenuTask = new AdminRoleMenuTask();
        private readonly AdminMenuTask _menusTask = new AdminMenuTask();
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();

        #region 主页面
        public ActionResult Index()
        {
            if (GetCurrentAdmin() == null)
            {
                return Redirect("/account/index");
            }
            ViewBag.account = GetCurrentAdmin().UserName;
            var menuIds = _roleMenuTask.GetListByRoleId(GetCurrentAdmin().RoleId)
                .Select(c => c.MenuId).ToList();
            return View();
        }

        public ActionResult Menu()
        {
            var menus = _roleMenuTask.GetMenuLstByRoleId(GetCurrentAdmin().RoleId)
                .Select(EntityMapper.Map<AdminMenu, MenuModel>)
                .OrderBy(c => c.SortOrder)
                .ToList();
            return View(menus);
        }

        public ActionResult FirstIndex()
        {
            return View();
        } 
        #endregion 

        #region 登录
        public ActionResult LogInIndex()
        {
            var model = new LogOnModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                var userPassword = _adminUserTask.GetByUserName(model.UserName);
                if (userPassword == null)
                    return AlertMsg("账号不存在", Request.UrlReferrer.PathAndQuery);
                if (userPassword.Password != CryptTools.HashPassword(model.Password))
                    return AlertMsg("账号或密码不正确", Request.UrlReferrer.PathAndQuery);
                if (userPassword.IsLock)
                    return AlertMsg("对不起，您的账号被锁定", Request.UrlReferrer.PathAndQuery);
                //if (model.ValidationCode != Session["code"].ToString())
                //    return AlertMsg("验证码不正确", Request.UrlReferrer.PathAndQuery);
                AccountDto account = new AccountDto();
                account.AdminUserId = userPassword.AdminUserId;
                account.UserName = userPassword.UserName;
                account.RoleId = userPassword.RoleId;
                Session["Account"] = account;
                SysLogTask.AddLog(new MyProject.Core.Entities.SysLogDto() { Message = "", Module = LogModuleEnum.Land, Type = LogTypeEnum.Land, Operator = userPassword.UserName, Result = "登陆成功" });
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        #endregion

        #region 退出
        public ActionResult LogOut()
        {
            Session["Account"] = "";
            return RedirectToAction("Index", "Account");
        }
        #endregion

    

    }
}