using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Acesoft.Store.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistPage : ContentPage
	{
		public RegistPage ()
		{
			InitializeComponent ();
		}

        async void OnRegist(object sender, EventArgs e)
        {
            await Task.CompletedTask;
        }
    }
}