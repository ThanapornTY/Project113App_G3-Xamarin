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
using Project113_G3_Xamarin.APIs;

namespace Project113_G3_Xamarin.View.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRoom : ContentPage
    {
        public SQLiteConnection conn;

        ObservableCollection<GamesModel> Games;

        public CreateRoomModel regmodel;

        ApiService apiService;


        public CreateRoom()
        {
            InitializeComponent();

            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<CreateRoomModel>();

            apiService = new ApiService();
            GetGameModel();

            Games = new ObservableCollection<GamesModel>();

            Games.Add(new GamesModel { NameGame = "Genshin Impact" });
            Games.Add(new GamesModel { NameGame = "Call of Duty" });
            Games.Add(new GamesModel { NameGame = "Valorant" });
            Games.Add(new GamesModel { NameGame = "Pubg" });
            Games.Add(new GamesModel { NameGame = "Goose Goose Duck" });
            Games.Add(new GamesModel { NameGame = "League of Legends" });

            pickerGames.ItemsSource = Games;

        }

        private async void Signed_Clicked(object sender, EventArgs e)
        {
            CreateRoomModel reg = new CreateRoomModel();
            reg.Id_Room = idRoom.Text;
            reg.Room_Name = roomName.Text;
            reg.TimeToPlay = timeToplay.Time.ToString();
            reg.GameName = Games.ToString();
            reg.Rank_Game = rankGame.Text;
            reg.Level_Game = levelGame.Text;
            reg.Deseription_Room = deseriptionRoom.Text;
            int x = 0;

            if (!string.IsNullOrEmpty(idRoom.Text) && !string.IsNullOrEmpty(roomName.Text)  )
            {
                try
                {
                    x = conn.Insert(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (x == 1)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.CreateRoom());
                    
                    await DisplayAlert("Create Room", "Thanks for Resistration", "OK");

                    
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Create Room Failled", "Please try again", "ERROR");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Create Room Failled", "Not Complete!", "OK");
            }
        }

        public async void Show_Clicked(object sender, EventArgs args)
        {
            
            await Navigation.PushAsync(new View.MainMenu.FindGame());
            
        }

        


        async void GetGameModel()
        {
            Games = await apiService.GetGameModel();
            Console.WriteLine(Games);
        }


    }
}