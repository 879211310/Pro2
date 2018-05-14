using MyProject.Core.Entities;
using MyProject.Data.Daos;
using MyProject.Services.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Task
{
    public class SysExceptionTask
    {
        private static readonly SysExceptionDao _exception = new SysExceptionDao();

        /// <summary>
        /// 添加系统错误日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="url">错误地址</param>
        public static void AddException(Exception ex,string url)
        {
            try
            { 
                    SysException model = new SysException()
                    { 
                        HelpLink = url,
                        Message = ex.Message,
                        Source = ex.Source,
                        StackTrace = ex.StackTrace,
                        TargetSite = ex.TargetSite.ToString(),
                        Data = ex.Data.ToString(),
                        CreateTime = ResultHelper.NowTime 
                    };
                    _exception.Add(model);
            }
            catch (Exception ep)
            {
                try
                {
                    //异常失败写入txt
                    string path = @"~/exceptionLog.txt";
                    string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);//获取绝对路径
                    using (StreamWriter sw = new StreamWriter(txtPath, true, Encoding.Default))
                    {
                        sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|" + DateTime.Now.ToString()).ToString());
                        sw.Dispose();
                        sw.Close();
                    }
                    return;
                }
                catch { return; }
            }
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <returns></returns>
        public List<SysException> GetList()
        {
            return _exception.GetList();
        }
    }
}
