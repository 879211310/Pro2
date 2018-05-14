using MyProject.Core.Entities;
using MyProject.Data.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Task
{
    public class WeiXinReceiveMessageTask
    {
        private readonly WeiXinReceiveMessageDao _dao = new WeiXinReceiveMessageDao();

        public void AddMessage(WeiXinReceiveMessage model)
        {
            _dao.Add(model);
        }

        public List<WeiXinReceiveMessage> GetList()
        {
            return _dao.GetList();
        }

    }
}
