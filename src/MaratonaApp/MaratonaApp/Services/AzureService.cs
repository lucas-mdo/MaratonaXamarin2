using System.Threading.Tasks;
using MaratonaApp.Authentication;
using MaratonaApp.Helpers;
using MaratonaApp.Services;
using MaratonaApp.ViewModels;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureService))]
namespace MaratonaApp.Services
{
    public class AzureService
    {
        //Azure Mobile Apps url
        private static readonly string AppUrl = "http://maratonaapp2.azurewebsites.net";

        //Mobile Service Client instance
        public MobileServiceClient Client { get; set; } = null;
        
        //Check if using authentication
        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            //Check if user is already authenticated
            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                //It is, get his info
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            //Get auth for the current platform
            var auth = DependencyService.Get<IAuthentication>();

            //Login using facebook
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                //Clear user's stored data
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                //Throw error (display alert box) as it couldnt retrieve user
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Unable to login. Try again.", "OK");
                });

                return false;
            }
            else
            {
                //Sucessfully logged in, save user's data
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}
