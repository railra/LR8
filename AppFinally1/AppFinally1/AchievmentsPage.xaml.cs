using AppFinally1.Models;
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
    public partial class AchievmentsPage : ContentPage
    {
        public AchievmentsPage()
        {
            InitializeComponent();
        }
        private async void SaveFriend(object sender, EventArgs e)
        {
            var achievments = (Models.Achievments)BindingContext;
            if (!String.IsNullOrEmpty(achievments.Name))
            {
                await App.Database5.SaveItemAsync(achievments);
            }

            await this.Navigation.PopAsync();
        }
        private async void DeleteFriend(object sender, EventArgs e)
        {
            var achievments = (Models.Achievments)BindingContext;
            await App.Database5.DeleteItemAsync(achievments);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}