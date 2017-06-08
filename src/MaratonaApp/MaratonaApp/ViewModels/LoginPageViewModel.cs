using System.Threading.Tasks;
using System.Windows.Input;
using MaratonaApp.Helpers;
using MaratonaApp.Services;
using MaratonaApp.Views;
using Xamarin.Forms;

namespace MaratonaApp.ViewModels
{
    public class LoginPageViewModel
    {
        private AzureService azureService;
        private INavigation navigation;

        private ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginPageViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;

            //Title = "Maratona Xamarin 2"
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                var profilePage = new ProfilePage();
                await navigation.PushAsync(profilePage);

                RemovePageFromStack();
            }
        }

        private void RemovePageFromStack()
        {
            
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.isLoggedIn)
                return Task.FromResult(true);

            //User not logged in, call login method
            return azureService.LoginAsync();
        }
    }
}
