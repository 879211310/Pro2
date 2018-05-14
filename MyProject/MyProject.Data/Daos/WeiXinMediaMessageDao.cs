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
    public class WeiXinMediaMessageDao : BaseDao<WeiXinMediaMessage>
    {
        public List<WeiXinMediaMessage> GetList()
        {
            var sql = Sql.Builder.OrderBy("CreateTime desc");
            return Query<WeiXinMediaMessage>(sql).ToList();
        }

        public WeiXinMediaMessage GetById(int id)
        {
            var sql = Sql.Builder.Where("Id=@0", id);
            return FirstOrDefault<WeiXinMediaMessage>(sql);
        }

        public void DeleteById(int id)
        {
            var sql = Sql.Builder.Where("Id = @0", id);
            Delete(sql);
        }
    }
}
