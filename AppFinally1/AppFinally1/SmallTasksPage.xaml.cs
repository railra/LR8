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
    public partial class SmallTasksPage : ContentPage
    {
        public SmallTasksPage()
        {
            InitializeComponent();
        }
        private async void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Models.SmallTasks)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                await App.Database2.SaveItemAsync(friend);
            }

            await this.Navigation.PopAsync();
        }
        private async void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Models.SmallTasks)BindingContext;
            await App.Database2.DeleteItemAsync(friend);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}