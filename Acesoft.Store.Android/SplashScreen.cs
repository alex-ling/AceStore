using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;

namespace Acesoft.Store.Android
{
    [Activity(Label = "云店", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(new Intent(this, typeof(MainActivity)));
            Finish();
        }
    }
}