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
    public partial class PunishmentsPage : ContentPage
    {
        public PunishmentsPage()
        {
            InitializeComponent();
        }
        private async void SaveFriend(object sender, EventArgs e)
        {
            var punishments = (Models.Punishments)BindingContext;
            if (!String.IsNullOrEmpty(punishments.Name))
            {
                await App.Database3.SaveItemAsync(punishments);
            }

            await this.Navigation.PopAsync();
        }
        private async void DeleteFriend(object sender, EventArgs e)
        {
            var punishments = (Models.Punishments)BindingContext;
            await App.Database3.DeleteItemAsync(punishments);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}