using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Acesoft.Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            // hide bar.
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnRegist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistPage());
        }

        async void OnLogin(object sender, EventArgs e)
        {
            var uid = username.Text.Trim();
            var pwd = password.Text.Trim();

            if (AppCtx.UserService.Login(uid, pwd))
            {
                Navigation.InsertPageBefore(new TabsPage(), this);
                await Navigation.PopAsync();
            }
        }
    }
}