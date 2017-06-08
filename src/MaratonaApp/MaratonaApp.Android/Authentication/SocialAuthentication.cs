using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaratonaApp.Authentication;
using MaratonaApp.Droid.Authentication;
using MaratonaApp.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(SocialAuthentication))]
namespace MaratonaApp.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                //Get user
                var user = await client.LoginAsync(Forms.Context, provider);

                //Store user's information in Settings
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                throw;
            }
        }
    }
}