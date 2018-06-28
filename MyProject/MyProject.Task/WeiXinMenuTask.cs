using MyProject.Core.Entities;
using MyProject.Data.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Task
{
    public class WeiXinMenuTask
    {
        private readonly WeiXinMenuDao _dao = new WeiXinMenuDao();

        public void Add(WeiXinMenu model)
        {
            _dao.Add(model);
        }

        public List<WeiXinMenu> GetList()
        {
            return _dao.GetList();
        }
    }
}
