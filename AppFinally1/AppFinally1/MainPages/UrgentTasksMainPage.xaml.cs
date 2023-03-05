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
	public partial class UrgentTasksMainPage : ContentPage
	{
        List<Models.UrgentTasks> tasks;
		public UrgentTasksMainPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            await App.Database4.CreateTable();
            tasks = App.Database4.GetItems();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Name = (i + 1).ToString() + ". " + tasks[i].Name + " ";
            }
            UTList.ItemsSource = tasks;
            base.OnAppearing();
        }
        private async void UTList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.UrgentTasks SelectedTask = (Models.UrgentTasks)e.SelectedItem;
            SelectedTask.Name = SelectedTask.Name.Remove(0, 3);
            SelectedTask.Name = SelectedTask.Name.Remove(SelectedTask.Name.Length - 1);
            UrgentTasksPage TPage = new UrgentTasksPage();
            TPage.BindingContext = SelectedTask;
            TPage.setPunishment(SelectedTask);
            TPage.Pic();
            await Navigation.PushAsync(TPage);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Models.UrgentTasks urgent = new Models.UrgentTasks();
            UrgentTasksPage urgentPage = new UrgentTasksPage();
            urgentPage.BindingContext = urgent;
            await Navigation.PushAsync(urgentPage);
        }
    }
}