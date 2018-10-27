using InstaMockApp.Modals;
using InstaMockApp.Services;
using Xamarin.Forms;

namespace InstaMockApp
{
	public partial class ActivityFeedPage : ContentPage
	{
        private ActivityService _service = new ActivityService(); 
		public ActivityFeedPage ()
		{
			InitializeComponent ();
            listView.ItemsSource = _service.GetActivities();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var seletedItem = e.SelectedItem as Activity;
            listView.SelectedItem = null;

            Navigation.PushAsync(new ProfilePage(seletedItem.UserId));

        }
    }
}