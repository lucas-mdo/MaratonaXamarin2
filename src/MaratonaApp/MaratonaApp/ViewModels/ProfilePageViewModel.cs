using MaratonaApp.Helpers;

namespace MaratonaApp.ViewModels
{
    public class ProfilePageViewModel : MyBaseViewModel
    {
        public string UserId { get; } = Settings.UserId;
        public string Token { get; } = Settings.AuthToken;

        public ProfilePageViewModel()
        {
            Title = "Profile Page";
        }
    }
}
