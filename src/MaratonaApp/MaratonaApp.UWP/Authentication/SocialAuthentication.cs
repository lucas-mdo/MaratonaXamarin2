using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaratonaApp.Helpers;
using MaratonaApp.UWP.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(SocialAuthentication))]
namespace MaratonaApp.UWP.Authentication
{
    class SocialAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                //Get user
                var user = await client.LoginAsync(provider);

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
