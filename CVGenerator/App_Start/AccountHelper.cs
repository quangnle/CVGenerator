using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator
{
    public class AccountHelper
    {
        public static string Token
        {
            get
            {
                if (HttpContext.Current.Session == null)
                {
                    return string.Empty;
                }                
                return HttpContext.Current.Session["__USER_TOKEN"] as string;
            }
            set { HttpContext.Current.Session["__USER_TOKEN"] = value; }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}