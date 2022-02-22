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
    public partial class UpdateRoom : ContentPage
    {
        public SQLiteConnection conn;
        public CreateRoomModel regmodel;
        public UpdateRoom()
        {
            InitializeComponent();

            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<CreateRoomModel>();
        }

        private void DisplayDetails()
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
                    x = conn.Update(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (x == 1)
                {
                    DisplayAlert("Update", "Update Finished", "OK");
                }
                else
                {
                    DisplayAlert("Update Failled", "Please try again", "ERROR");
                }
            }
            else
            {
                DisplayAlert("Requires", "Not Complete!", "OK");
            }
        }
        private void Update_Clicked(object sender, EventArgs e)
        {
            DisplayDetails();
        }

        private void Cancal_Clicked(object sender, EventArgs e)
        {
            idRoom.Text = "";
            roomName.Text = "";
            gameName.Text = "";

            rankGame.Text = "";
            levelGame.Text = "";
            deseriptionRoom.Text = "";
        }
    }


}