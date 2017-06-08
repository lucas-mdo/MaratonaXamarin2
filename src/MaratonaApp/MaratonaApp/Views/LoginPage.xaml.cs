using MaratonaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaratonaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
    }
}