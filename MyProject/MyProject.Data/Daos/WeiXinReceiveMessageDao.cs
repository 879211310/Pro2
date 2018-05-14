﻿using MyProject.Core.Entities;
using MyProject.Services.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Daos
{
    [DbFactory("MyP")]
    public class WeiXinReceiveMessageDao : BaseDao<WeiXinReceiveMessage>
    {
        public List<WeiXinReceiveMessage> GetList()
        {
            var sql = Sql.Builder.OrderBy("CreateDate desc");
            return Query<WeiXinReceiveMessage>(sql).ToList();
        }
    }
}
