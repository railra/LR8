﻿using AppFinally1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinally1
{
    public partial class MainPage : ContentPage
    {
        string s = "";
        int count = 0;
        public MainPage()
        {
            InitializeComponent();

        }
        string Par(Models.BigTasks task)
        {
            
            if (task.Parrent == null)
            {
                return s;
            }
            else
            {
                var selectedPeople = from p in App.Database.GetItems()
                                     where task.Parrent.Value == p.Id
                                     select p;
                s += "  ";
                return Par(selectedPeople.First());
            }
        }
        protected override async void OnAppearing()
        {
            // создание таблицы, если ее нет
            await App.Database.CreateTable();
            // привязка данных
            friendsList.ItemsSource = await App.Database.GetItemsAsync();
            friends2List.ItemsSource = await App.Database2.GetItemsAsync();
            friends3List.ItemsSource = await App.Database4.GetItemsAsync();
            friends4List.ItemsSource = await App.Database3.GetItemsAsync();
            friends5List.ItemsSource = await App.Database5.GetItemsAsync();

            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.BigTasks selectedFriend = (Models.BigTasks)e.SelectedItem;
            BigTasksPage friendPage = new BigTasksPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            Models.BigTasks friend = new Models.BigTasks();
            BigTasksPage friendPage = new BigTasksPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void friends2List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.SmallTasks selectedFriend = (Models.SmallTasks)e.SelectedItem;
            SmallTasksPage friendPage = new SmallTasksPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }

        private async void friends3List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.UrgentTasks selectedFriend = (Models.UrgentTasks)e.SelectedItem;
            UrgentTasksPage friendPage = new UrgentTasksPage();
            friendPage.BindingContext = selectedFriend;
            friendPage.setPunishment(selectedFriend);
            friendPage.Pic();
            await Navigation.PushAsync(friendPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Models.UrgentTasks urgent = new Models.UrgentTasks();
            UrgentTasksPage urgentPage = new UrgentTasksPage();
            urgentPage.BindingContext = urgent;
            await Navigation.PushAsync(urgentPage);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Models.SmallTasks small = new Models.SmallTasks();
            SmallTasksPage smallPage = new SmallTasksPage();
            smallPage.BindingContext = small;
            await Navigation.PushAsync(smallPage);
        }

        private async void friends4List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.Punishments selectedPunishment = (Models.Punishments)e.SelectedItem;
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

        private async void friends5List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.Achievments selectedAchievment = (Models.Achievments)e.SelectedItem;
            AchievmentsPage achievmentPage = new AchievmentsPage();
            achievmentPage.BindingContext = selectedAchievment;
            await Navigation.PushAsync(achievmentPage);
        }
    }
}
