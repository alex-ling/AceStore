using System;
using System.Linq;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Acesoft.Components.Effects;
using Acesoft.ViewModels;

namespace Acesoft.Components
{
	public class BaseTabsPage : Xamarin.Forms.TabbedPage
	{
        public event Action<ITabViewModel, ITabViewModel> TabChanged;
        private TabPage currentTabPage;

        public BaseTabsPage ()
		{
            // for android
            InitializeForAndroid();
            // add effect
            Effects.Add(new NoShiftEffect());
        }

        protected virtual void InitializeChildrenPages()
        {
            this.currentTabPage = (TabPage)Children.First();
            this.CurrentPageChanged += (s, e) =>
            {
                var prev = (ITabViewModel)currentTabPage.BindingContext;
                prev.IsSelected = false;

                //set current page from tabbed
                this.currentTabPage = (TabPage)CurrentPage;

                var current = (ITabViewModel)currentTabPage.BindingContext;
                current.IsSelected = true;

                //fire events
                TabChanged?.Invoke(prev, current);
            };
        }

        private void InitializeForAndroid()
        {
            On<Android>().SetIsSwipePagingEnabled(false)
                .SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}