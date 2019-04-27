using Xamarin.Forms;

namespace Acesoft.Components
{
    public static class Toast
    {
        public static void ShowLongMsg(string message)
        {
            DependencyService.Get<IToast>().Long(message);
        }

        public static void ShowShortMsg(string message)
        {
            DependencyService.Get<IToast>().Short(message);
        }
    }
}
