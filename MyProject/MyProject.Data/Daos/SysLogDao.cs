using MyProject.Core.Entities;
using MyProject.Services.MvcPager;
using MyProject.Services.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Daos
{
    [DbFactory("MyP")]
    public class SysLogDao:BaseDao<SysLog>
    {
        public SysLog GetSysLog(string id)
        {
            var sql = Sql.Builder.Where("Id=@0", id);
            return FirstOrDefault<SysLog>(sql);
        }

        public List<SysLog> GetList()
        {
            var sql = Sql.Builder.OrderBy("Createtime desc");
            return Query<SysLog>(sql).ToList();
        }
    }
}
