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
	public partial class BigTasksMainPage : ContentPage
	{
        List<Models.BigTasks> tasks;
		public BigTasksMainPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            await App.Database.CreateTable();
            tasks = App.Database.GetItems();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Name = (i+1).ToString() + ". " + tasks[i].Name + " ";
            }
            BTList.ItemsSource = tasks;
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.BigTasks SelectedTask = (Models.BigTasks)e.SelectedItem;
            SelectedTask.Name = SelectedTask.Name.Remove(0, 3);
            SelectedTask.Name = SelectedTask.Name.Remove(SelectedTask.Name.Length - 1);
            BigTasksPage TPAge = new BigTasksPage();
            TPAge.BindingContext = SelectedTask;
            await Navigation.PushAsync(TPAge);
        }
        // обработка нажатия кнопки добавления
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            Models.BigTasks friend = new Models.BigTasks();
            BigTasksPage TPAge = new BigTasksPage();
            TPAge.BindingContext = friend;
            await Navigation.PushAsync(TPAge);
        }
    }
}