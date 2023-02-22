using AppFinally1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFinally1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrgentTasksPage : ContentPage
    {
        List<Punishments> selN;

        public UrgentTasks CurrentUrgentTask { get; private set; }

        public async void Pic()
        {

            selN = (from p in await App.Database3.GetItemsAsync()
                       select p).ToList();
            var pun = selN.Where(v => v.Id == ((this.BindingContext as UrgentTasks).PunishmentId == 0 ? 0 : (this.BindingContext as UrgentTasks).PunishmentId)).FirstOrDefault();
            pic.SelectedIndex = selN.IndexOf(pun);
        }

        public UrgentTasksPage()
        {
            InitializeComponent();
            selN = (from p in  App.Database3.GetItems()
                    select p).ToList();
            pic.ItemsSource = selN.ToList(); 
          
        }
        private async void SaveFriend(object sender, EventArgs e)
        {
           
            var friend = (Models.UrgentTasks)BindingContext;
            friend.Date = friend.Date.Substring(0, Math.Min(friend.Date.Length, 10));
            friend.PunishmentId = (pic.SelectedItem as Punishments).Id;
            if (!String.IsNullOrEmpty(friend.Name))
            {
                await App.Database4.SaveItemAsync(friend);
            }


            await this.Navigation.PopAsync();
        }
        private async void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Models.UrgentTasks)BindingContext;
            await App.Database4.DeleteItemAsync(friend);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private void pic_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal void setPunishment(UrgentTasks selectedFriend)
        {
            this.CurrentUrgentTask = selectedFriend;
        }
    }
}