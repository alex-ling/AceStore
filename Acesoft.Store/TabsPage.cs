using Acesoft.Components;
using Acesoft.Store.Views;
using Xamarin.Forms;

namespace Acesoft.Store
{
    public class TabsPage : BaseTabsPage
	{
		public TabsPage ()
        {
            // hide bar.
            NavigationPage.SetHasNavigationBar(this, false);

            // add pages
            AddChildrenPages();
        }

        private void AddChildrenPages()
        {
            Children.Add(new TabPage(new HomePage(), "home.png", "home_fill.png", 0, true));
            Children.Add(new TabPage(new StorePage(), "store.png", "store_fill.png", 1));
            Children.Add(new TabPage(new CartPage(), "cart.png", "cart_fill.png", 2));
            Children.Add(new TabPage(new MinePage(), "mine.png", "mine_fill.png", 3));

            base.InitializeChildrenPages();
        }
    }
}