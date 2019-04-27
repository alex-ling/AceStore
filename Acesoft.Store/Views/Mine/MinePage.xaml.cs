using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acesoft.Store.ViewModels;
using Acesoft.Components;

namespace Acesoft.Store.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MinePage : ContentPage
	{
        MineViewModel viewModel;

        public MinePage ()
		{
			InitializeComponent();

            BindingContext = viewModel = new MineViewModel();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ListItem;
            if (item == null) return;

            // Manually deselect item.
            lstView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }

        async void OnOptions(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new OptionPage()));
        }
    }
}