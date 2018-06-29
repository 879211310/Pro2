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
    public class WeiXinMenuDao : BaseDao<WeiXinMenu>
    {
        public List<WeiXinMenu> GetList()
        {
            var sql = Sql.Builder.Where("1=1");
            return Query<WeiXinMenu>(sql).ToList();
        }
    }
}
