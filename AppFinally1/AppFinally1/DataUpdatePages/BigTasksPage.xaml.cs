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
    public partial class BigTasksPage : ContentPage
    {
        public BigTasksPage()
        {
            InitializeComponent();
        }
        FlyoutPage fl = new FlyoutPage();
        private async void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Models.BigTasks)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                await App.Database.SaveItemAsync(friend);
            }
            
            await this.Navigation.PopAsync();
        }
        private async void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Models.BigTasks)BindingContext;
            await App.Database.DeleteItemAsync(friend);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}