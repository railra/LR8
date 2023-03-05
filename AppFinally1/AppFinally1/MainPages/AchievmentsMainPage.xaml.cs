using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinally1.MainPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AchievmentsMainPage : ContentPage
	{
        List<Models.Achievments> tasks = new List<Models.Achievments>();
		public AchievmentsMainPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            await App.Database5.CreateTable();
            tasks = App.Database5.GetItems();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Name = (i + 1).ToString() + ". " + tasks[i].Name + " ";
            }
            AList.ItemsSource = tasks;
            base.OnAppearing();
        }

        private async void AList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.Achievments selectedAchievment = (Models.Achievments)e.SelectedItem;
            AchievmentsPage achievmentPage = new AchievmentsPage();
            achievmentPage.BindingContext = selectedAchievment;
            await Navigation.PushAsync(achievmentPage);
        }
    }
}