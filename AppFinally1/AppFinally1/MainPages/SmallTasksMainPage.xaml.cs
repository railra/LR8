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
	public partial class SmallTasksMainPage : ContentPage
	{
        List<Models.SmallTasks> tasks;
        public SmallTasksMainPage ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            await App.Database2.CreateTable();
            tasks = App.Database2.GetItems();
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Name = (i + 1).ToString() + ". " + tasks[i].Name + " ";
            }
            STList.ItemsSource = tasks;
            base.OnAppearing();
        }

        private async void STList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.SmallTasks SelectedTask = (Models.SmallTasks)e.SelectedItem;
            SelectedTask.Name = SelectedTask.Name.Remove(0, 3);
            SelectedTask.Name = SelectedTask.Name.Remove(SelectedTask.Name.Length-1);
            SmallTasksPage TPAge = new SmallTasksPage();
            TPAge.BindingContext = SelectedTask;
            await Navigation.PushAsync(TPAge);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Models.SmallTasks small = new Models.SmallTasks();
            SmallTasksPage smallPage = new SmallTasksPage();
            smallPage.BindingContext = small;
            await Navigation.PushAsync(smallPage);
        }
    }
}