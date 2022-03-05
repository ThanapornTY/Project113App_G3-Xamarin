using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Project113_G3_Xamarin.APIs;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project113_G3_Xamarin.View.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        ObservableCollection<GamesModel> Games;

        ApiService apiService;

        public Home()
        {
            InitializeComponent();


            apiService = new ApiService();

            GetGameModel();


            NameGameListGames.ItemsSource = Games;

 


        }

        private void search_TextChanged(object sender,TextChangedEventArgs e)
        {
            var keyword = Games.Where(g => g.NameGame.StartsWith(e.NewTextValue));
            NameGameListGames.ItemsSource = keyword;
        }

        async void GetGameModel()
        {
            Games = await apiService.GetGameModel();
            Console.WriteLine(Games);
        }

       


    }


    
}

