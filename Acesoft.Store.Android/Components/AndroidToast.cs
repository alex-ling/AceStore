using Android.App;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(Acesoft.Store.Android.Components.AndroidToast))]
namespace Acesoft.Store.Android.Components
{
    public class AndroidToast : Acesoft.Components.IToast
    {
        public void Long(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
        public void Short(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}