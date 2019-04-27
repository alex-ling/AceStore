using System.ComponentModel;
using System.IO;

using Android.Content;
using Android.Views;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Acesoft.Store.Android.Renderers;
using Acesoft.Util;
using Acesoft.Components;

[assembly: ExportRenderer(typeof(BaseTabsPage), typeof(TabsPageRenderer))]
namespace Acesoft.Store.Android.Renderers
{
    public class TabsPageRenderer : TabbedPageRenderer
    {
        private BottomNavigationView bottomNavigation;

        public TabsPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                ((BaseTabsPage)Element).TabChanged += (prev, current) =>
                {
                    if (bottomNavigation == null)
                    {
                        return;
                    }

                    var menu = bottomNavigation.Menu.GetItem(prev.Index);
                    SetCurrentTabIcon(menu, prev.CurrentIcon);
                    menu = bottomNavigation.Menu.GetItem(current.Index);
                    SetCurrentTabIcon(menu, current.CurrentIcon);
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (bottomNavigation == null && e.PropertyName == "Renderer")
            {
                var layout = (ViewGroup)ViewGroup.GetChildAt(0);
                bottomNavigation = (BottomNavigationView)layout.GetChildAt(1);

                //change by set effect on BaseTabsPage
                //bottomNavigation.SetShiftMode(false, false);
            }
        }

        void SetCurrentTabIcon(IMenuItem menu, string icon)
        {
            var name = Path.GetFileNameWithoutExtension(icon);
            menu.SetIcon(AndroidHelper.GetIdFromName(name, ResourceManager.DrawableClass));
        }
    }
}