using Project113_G3_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project113_G3_Xamarin.View.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatApp : ContentPage
    {

        public SQLiteConnection conn;
        public CreateRoomModel regmodel;
        ObservableCollection<string> itemList;
        public CreateRoomModel itemSelected;
        string itemChatSelected;


        public ChatApp()
        {
            InitializeComponent();
            itemList = new ObservableCollection
            <string>();
            lstview.ItemsSource = itemList;

            
        }

        public void AddList_Clicked
        (object sender, EventArgs e)
        {
            itemList.Add(InputText.Text);

        }
        
        public async void ListBack_Clicked
        (object sender, EventArgs e)
        {
            await Navigation.PushAsync
            (new MainPage());
        }
        
        public void lst_ItemSelected
        (object sender, SelectedItemChangedEventArgs e)
        {
            itemChatSelected = e.SelectedItem.ToString();
        }

        public async void Report_Clicked
        (object sender, EventArgs e)
        {
            await Navigation.PushAsync
            (new ReportPage());
        }

        public async void Del_Room(object sender, EventArgs e)
        {
            await Navigation.PushAsync
            (new ReportPage());
        }


        public async void lst_ItemDel(object sender, SelectedItemChangedEventArgs e)
        {
            regmodel = e.SelectedItem as CreateRoomModel;
            var resultN = new CreateRoomModel
            {

                Id_Room = regmodel.Id_Room,
                Room_Name = regmodel.Room_Name,
                TimeToPlay = regmodel.TimeToPlay,
                GameName = regmodel.GameName,
                Rank_Game = regmodel.Rank_Game,
                Level_Game = regmodel.Level_Game,
                Deseription_Room = regmodel.Deseription_Room

            };

            bool answer2 = await DisplayAlert("Do you want to Remove Data?", "ID: " + regmodel.Id_Room.ToString() + "\n" + "Name: " + regmodel.Room_Name, "Yes", "No");
            if (answer2 == true)
            {
                int x = 0;
                try
                {
                    x = conn.Delete(regmodel);
                    await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.FindGame());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

    }
}