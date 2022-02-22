using Project113_G3_Xamarin.Model;
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
    public partial class Home : ContentPage
    {
        ObservableCollection<GamesModel> Games;
        public Home()
        {
            InitializeComponent();

            Games = new ObservableCollection<GamesModel>
            {
                new GamesModel{ID = 1, Title = "Aamen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg")},
                new GamesModel{ID = 2, Title = "Bamen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg")},
                new GamesModel{ID = 3, Title = "ramen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg")},
                new GamesModel{ID = 4, Title = "ramen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg")},
                new GamesModel{ID = 5, Title = "Camen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg")},
                new GamesModel{ID = 6, Title = "Gin-Chan", Description = "123456", Price = 1000, Image = new Uri("https://i.kym-cdn.com/entries/icons/facebook/000/010/163/gintoki_by_lightningfarron165-d57obmk.jpg")},

            };

            NameGameListGames.ItemsSource = Games;
        }

        private void search_TextChanged(object sender,TextChangedEventArgs e)
        {
            var keyword = Games.Where(g => g.Title.StartsWith(e.NewTextValue));
            NameGameListGames.ItemsSource = keyword;
        }
    }


    
}

