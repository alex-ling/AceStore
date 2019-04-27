using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Acesoft.ViewModels;

namespace Acesoft.Components
{
    public class TabPage : NavigationPage
    {
        public TabPage(Page page, string icon, string selectedIcon, int index, bool selected = false) : base(page)
        {
            this.BindingContext = new TabViewModel(page.Title, icon, selectedIcon)
            {
                Index = index,
                IsSelected = selected
            };
            this.SetBinding(TitleProperty, "Title");
            this.SetBinding(IconProperty, "CurrentIcon");
        }
    }
}