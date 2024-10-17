using _16122023_BlogSitesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Models
{
    public class LoginControl
    {
        public static Admin GetUser()
        {
            var user = new Admin();
            if (HttpContext.Current.Session["Kullanici"]!= null)
            {
                try
                {
                    user = HttpContext.Current.Session["Kullanici"] as Admin;
                    return user;
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.Redirect("~/Login");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login");

            }
            return user;

        }
    }
}