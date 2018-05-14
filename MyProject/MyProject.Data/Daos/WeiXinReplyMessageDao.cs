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
    public class WeiXinReplyMessageDao : BaseDao<WeiXinReplyMessage>
    {
        public List<WeiXinReplyMessage> GetList()
        {
            var sql = Sql.Builder.OrderBy("CreateTime desc");
            return Query<WeiXinReplyMessage>(sql).ToList();
        }

        public WeiXinReplyMessage GetById(int id)
        {
            var sql = Sql.Builder.Where("Id=@0",id);
            return FirstOrDefault<WeiXinReplyMessage>(sql);
        }

        public void DeleteById(int id)
        {
            var sql = Sql.Builder.Where("Id = @0", id);
            Delete(sql);
        }

        public WeiXinReplyMessage GetMessage(string matchKey)
        {
            var sql = Sql.Builder.Select("*").From("WeiXinReplyMessage").Where(string.Format("MatchKey like'%{0}%'", matchKey)); 
            return FirstOrDefault<WeiXinReplyMessage>(sql);
        }
    }
}
