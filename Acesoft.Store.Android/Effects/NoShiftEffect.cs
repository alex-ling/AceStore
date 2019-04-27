using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Acesoft")]
[assembly: ExportEffect(typeof(Acesoft.Store.Android.Effects.NoShiftEffect), "NoShiftEffect")]
namespace Acesoft.Store.Android.Effects
{
    public class NoShiftEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Container.GetChildAt(0) is ViewGroup layout))
                return;

            if (!(layout.GetChildAt(1) is BottomNavigationView navigationView))
                return;

            // This is what we set to adjust if the shifting happens
            navigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
        }

        protected override void OnDetached()
        {
        }
    }
}