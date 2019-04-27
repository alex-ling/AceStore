using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acesoft.Store.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Acesoft.Store
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (AppCtx.UserService.AutoLogin())
            {
                MainPage = new NavigationPage(new TabsPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        #region events
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion
    }
}
