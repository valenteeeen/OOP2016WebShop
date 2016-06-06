using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Bitaka
{
    public partial class Startup
    {
        
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
           

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
           
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            app.UseFacebookAuthentication(
               appId: "868993459897111",
            appSecret: "74ef81af39f1db50a10fef02d4eb610b");

            app.UseGoogleAuthentication(
                clientId: "847826063844-j7sfrl7v3m5oessvd8o9rpmi6of32knu.apps.googleusercontent.com",
                clientSecret: "K_ow6h1ech-ttrh5Na0Jxe3A");
        }
    }
}