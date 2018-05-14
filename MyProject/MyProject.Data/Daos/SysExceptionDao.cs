using MyProject.Core.Entities;
using MyProject.Services.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Daos
{
    [DbFactory("MyP")]
    public class SysExceptionDao : BaseDao<SysException>
    {
        public List<SysException> GetList()
        {
            var sql = Sql.Builder.OrderBy("Createtime desc");
            return Query<SysException>(sql).ToList();
        }
    }
}
