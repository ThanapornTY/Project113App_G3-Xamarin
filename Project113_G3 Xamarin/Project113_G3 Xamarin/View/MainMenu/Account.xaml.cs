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
    public partial class Account : ContentPage
    {
        public SQLiteConnection conn;
        public RegisterModel Regismodel;
        ObservableCollection<string> itemList;
        public RegisterModel itemSelected;



        public Account()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<RegisterModel>();
            DisplayDetails();
            itemList = new ObservableCollection<string>();

        }

        private void DisplayDetails()
        {
            var detail = (from x in conn.Table<CreateRoomModel>() select x).ToList();

        }

        public async void LogOut_Click (object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new View.Login());
        }


        public async void EditPf_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainMenu.EditProfile());
        }


        public async void RqGame_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainMenu.QRGame());
        }

    }
}