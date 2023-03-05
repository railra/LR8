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
	public partial class PunishmentsMainPage : ContentPage
	{
        List<Models.Punishments> tasks = new List<Models.Punishments>();
		public PunishmentsMainPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            await App.Database3.CreateTable();
            tasks = App.Database3.GetItems();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Name = (i + 1).ToString() + ". " + tasks[i].Name + " ";
            }
            PList.ItemsSource = tasks;
        }

        private async void PList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.Punishments selectedPunishment = (Models.Punishments)e.SelectedItem;
            selectedPunishment.Name = selectedPunishment.Name.Remove(0, 3);
            selectedPunishment.Name = selectedPunishment.Name.Remove(selectedPunishment.Name.Length - 1);
            PunishmentsPage punishmentPage = new PunishmentsPage();
            punishmentPage.BindingContext = selectedPunishment;
            await Navigation.PushAsync(punishmentPage);
        }
        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            Models.Punishments punishment = new Models.Punishments();
            PunishmentsPage punishmentPage = new PunishmentsPage();
            punishmentPage.BindingContext = punishment;
            await Navigation.PushAsync(punishmentPage);
        
        }
    }
}