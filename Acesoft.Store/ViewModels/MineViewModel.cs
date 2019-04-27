using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Acesoft.Components;
using Acesoft.ViewModels;

namespace Acesoft.Store.ViewModels
{
	public class MineViewModel : BaseViewModel
	{
        public ObservableCollection<ListItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MineViewModel()
		{
            Title = "我的";
            Items = new ObservableCollection<ListItem>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());

            Items.Add(new ListItem { Title = "我的积分", Text = "" });
        }

        private void ExecuteLoadItemsCommand()
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                Items.Clear();

                Items.Add(new ListItem { Title = "云店资料", Text = "" });
                Items.Add(new ListItem { Title = "我的地址", Text = "" });
            }
            catch (Exception ex)
            {
                Toast.ShowShortMsg(ex.GetMessage());
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}