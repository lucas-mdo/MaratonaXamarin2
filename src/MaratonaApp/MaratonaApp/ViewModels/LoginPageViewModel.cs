using System.Threading.Tasks;
using System.Windows.Input;
using MaratonaApp.Helpers;
using MaratonaApp.Services;
using Xamarin.Forms;

namespace MaratonaApp.ViewModels
{
    public class LoginPageViewModel : MyBaseViewModel
    {
        private readonly AzureService _azureService;

        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            _azureService = DependencyService.Get<AzureService>();

            LoginCommand = new Command(async () => await ExecuteLoginCommandAsync());

            Title = "Maratona Xamarin 2";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !await LoginAsync())
                return;
            else
            {
                await PushAsync<ProfilePageViewModel>();
            }
        }

        public async Task<bool> LoginAsync()
        {
            if (Settings.isLoggedIn)
                return await Task.FromResult(true);

            //User not logged in, call login method
            return await _azureService.LoginAsync();
            
        }
    }
}
