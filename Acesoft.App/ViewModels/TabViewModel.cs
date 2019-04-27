using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Acesoft.ViewModels
{
    public class TabViewModel : BaseViewModel, ITabViewModel
    {
        public string Icon { get; }
        public string SelectedIcon { get; }
        public int Index { get; internal set; }

        public TabViewModel(string title, string icon, string selectedIcon)
        {
            this.Title = title;
            this.Icon = icon;
            this.SelectedIcon = selectedIcon;
        }


        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (SetProperty(ref isSelected, value))
                {
                    OnPropertyChanged(nameof(CurrentIcon));
                }
            }
        }

        public string CurrentIcon => IsSelected ? SelectedIcon : Icon;
    }
}