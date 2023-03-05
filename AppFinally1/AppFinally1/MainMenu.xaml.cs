using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppFinally1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
		}
        void OnTapped(object sender, EventArgs e)
        {
            MainPages.BigTasksMainPage TPage = new MainPages.BigTasksMainPage();
            Navigation.PushAsync(TPage);
        }
        void OnTapped2(object sender, EventArgs e)
        {
            MainPages.SmallTasksMainPage TPage = new MainPages.SmallTasksMainPage();
            Navigation.PushAsync(TPage);
        }
        void OnTapped3(object sender, EventArgs e)
        {
            MainPages.UrgentTasksMainPage TPage = new MainPages.UrgentTasksMainPage();
            Navigation.PushAsync(TPage);
        }
        void OnTapped4(object sender, EventArgs e)
        {
            MainPages.PunishmentsMainPage TPage = new MainPages.PunishmentsMainPage();
            Navigation.PushAsync(TPage);
        }
        void OnTapped5(object sender, EventArgs e)
        {
            MainPages.AchievmentsMainPage TPage = new MainPages.AchievmentsMainPage();
            Navigation.PushAsync(TPage);
        }
    }
}