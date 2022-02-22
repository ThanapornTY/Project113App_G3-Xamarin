using Project113_G3_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project113_G3_Xamarin.View.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRoom : ContentPage
    {
        public SQLiteConnection conn;
        public CreateRoomModel regmodel;
        public CreateRoom()
        {
            InitializeComponent();

            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<CreateRoomModel>();
        }

        private void Signed_Clicked(object sender, EventArgs e)
        {
            CreateRoomModel reg = new CreateRoomModel();
            reg.Id_Room = idRoom.Text;
            reg.Room_Name = roomName.Text;
            reg.GameName = gameName.Text;
            reg.TimeToPlay = timeToplay.Time.ToString();
            reg.Rank_Game = rankGame.Text;
            reg.Level_Game = levelGame.Text;
            reg.Deseription_Room = deseriptionRoom.Text;
            int x = 0;

            if (!string.IsNullOrEmpty(idRoom.Text) && !string.IsNullOrEmpty(roomName.Text) && !string.IsNullOrEmpty(gameName.Text))
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
                    DisplayAlert("Resistration", "Thanks for Resistration", "OK");
                }
                else
                {
                    DisplayAlert("Resistration Failled", "Please try again", "ERROR");
                }
            }
            else
            {
                DisplayAlert("Resistration", "Not Complete!", "OK");
            }
        }

        private async void Show_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new FindGame());

            /*
            try
            {
                await Navigation.PushAsync(new Display());
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Resistration Failled", "Please try again", "ERROR");

                await Navigation.PushAsync(new Display());

                throw ex;
            }*/
        }
    }
}