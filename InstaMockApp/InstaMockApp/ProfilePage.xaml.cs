using InstaMockApp.Modals;
using InstaMockApp.Services;
using Xamarin.Forms;

namespace InstaMockApp
{
	public partial class ProfilePage : ContentPage
	{
        private UserService _service = new UserService();

		public ProfilePage (int userId)
		{
            BindingContext = _service.GetUser(userId);

            InitializeComponent();
		}
	}
}