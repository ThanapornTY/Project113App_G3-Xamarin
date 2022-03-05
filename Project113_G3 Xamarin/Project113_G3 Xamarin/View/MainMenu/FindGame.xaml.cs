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
    public partial class FindGame : ContentPage
    {
        public SQLiteConnection conn;
        public CreateRoomModel regmodel;
        ObservableCollection<string> itemList;
        public CreateRoomModel itemSelected;

        public FindGame()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<CreateRoomModel>();
            DisplayDetails();
            itemList = new ObservableCollection<string>();
        }

        private void DisplayDetails()
        {
            var detail = (from x in conn.Table <CreateRoomModel>() select x).ToList();
            myListView.ItemsSource = detail;
        }

        private async void lst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.ChatApp());

            
            itemSelected = e.SelectedItem as CreateRoomModel;
            var resultN = new CreateRoomModel
            {
                Id_Room = itemSelected.Id_Room,
                Room_Name = itemSelected.Room_Name,
                GameName = itemSelected.GameName,
                TimeToPlay = itemSelected.TimeToPlay,
                Rank_Game = itemSelected.Rank_Game,
                Level_Game = itemSelected.Level_Game,
                Deseription_Room = itemSelected.Deseription_Room
            };
            
            /*
            bool answerl = await DisplayAlert("Do you want to Edit Data?", "ID: " + itemSelected.Room_Name.ToString() + "\n" + "Name: " + itemSelected.GameName, "Yes", "No");
            if (answerl == true)
            {
                UpdateRoom newP = new UpdateRoom();
                newP.BindingContext = resultN;
                await Navigation.PushAsync(newP);
            }
            else if (answerl == false)
            {*/
                bool answer2 = await DisplayAlert("Do you want to Remove Data?", "ID: " + itemSelected.Room_Name.ToString() + "\n" + "Name: " + itemSelected.GameName, "Yes", "No");
                if (answer2 == true)
                {
                    int x = 0;
                    try
                    {
                        x = conn.Delete(itemSelected);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            
        }

        public async void CreRoom_Click(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainMenu.CreateRoom());
        }


    }
}