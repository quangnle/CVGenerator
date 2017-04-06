using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
                LoginPath = new PathString("/Account/Login"),
                //Provider = new CookieAuthenticationProvider
                //{
                //    //OnApplyRedirect = ApplyRedirect
                //},
                //AuthenticationMode = AuthenticationMode.Active,
                //CookieSecure = CookieSecureOption.Always
            });
        }
    }
}