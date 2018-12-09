using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SweetsDokkana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage ()
        {
            InitializeComponent();
        }
        private void MyPage_CurrentPageChanged(object sender, System.EventArgs e)
        {
            //MyPage.BarBackgroundColor = ((ContentPage)MyPage.CurrentPage).BackgroundColor;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}