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
    public partial class Account : ContentPage
    {
        public SQLiteConnection conn;
        public RegisterModel Regismodel;
        ObservableCollection<string> itemList;
        public RegisterModel itemSelected;

        public Command LogOutCommand { get; set; }

        ApiService apiService;

        public Account()
        {
            InitializeComponent();
            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<RegisterModel>();
            DisplayDetails();
            itemList = new ObservableCollection<string>();

            apiService = new ApiService();

            LogOutCommand = new Command(async () =>
            {
                var respone = await  apiService.Logout();

                if (respone)
                {
                    Application.Current.MainPage = new NavigationPage( new View.Login());
                }
            });

        }

        private void DisplayDetails()
        {
            var detail = (from x in conn.Table<CreateRoomModel>() select x).ToList();

        }

        public async void LogOut_Click (object sender, EventArgs e)
        {

            await Application.Current.MainPage.Navigation.PushAsync(new View.Login());
        }


        public async void EditPf_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.EditProfile());
        }


        public async void RqGame_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.QRGame());
        }

    }
}