﻿using System.Web;
using System.Web.Mvc;

namespace MyProject.Matrix
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}