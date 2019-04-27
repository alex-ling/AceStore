using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acesoft.Store.ViewModels;

namespace Acesoft.Store.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CartPage : ContentPage
	{
		public CartPage ()
		{
			InitializeComponent();

            BindingContext = new CartViewModel();
        }
	}
}