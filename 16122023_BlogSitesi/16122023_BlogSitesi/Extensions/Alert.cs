using _16122023_BlogSitesi.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Extensions
{
    public static class Alert
    {
        public static string Get(string message , AlertEnum type)
        {
            string text = "<div class='alert alert-{0}' role='alert'> {1} </div>";
            string className = string.Empty;
            switch (type)
            {
                case AlertEnum.success:
                    className= "success";
                    break;
                case AlertEnum.info:
                    className= "info";
                    break;
                case AlertEnum.danger:
                    className = "danger";
                    break;
                case AlertEnum.warning:
                    className = "warning";
                    break;
               
            }
            return string.Format(text, className,message);
        }
    }
}