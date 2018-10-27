using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LayoutsApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StackLayout2 : ContentPage
	{
		public StackLayout2 ()
		{
			InitializeComponent ();
            var imageSource = new UriImageSource { Uri = new Uri("http://lorempixel.com/1920/1080/sports/7/") };
            imageSource.CachingEnabled = false;
            image.Source = imageSource;

            
		}

	}
}