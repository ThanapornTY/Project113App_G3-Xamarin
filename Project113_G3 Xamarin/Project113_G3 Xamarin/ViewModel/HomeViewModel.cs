using Project113_G3_Xamarin.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Project113_G3_Xamarin.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GamesModel> Games { get; set; }
        public Command SelectCommand { get; }
        public GamesModel selectProduct { get; set; }

        public HomeViewModel()
        {
            
            Games = new ObservableCollection<GamesModel>();

            Games.Add(new GamesModel { ID = 1, Title = "ramen", Description = "123456", Price = 1000, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg") });
            Games.Add(new GamesModel { ID = 2, Title = "ramen", Description = "123456", Price = 860, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg") });
            Games.Add(new GamesModel { ID = 3, Title = "soamen", Description = "123456", Price = 860, Image = new Uri("https://yodoozy.com/wp-content/uploads/2021/02/ramen-350x350.jpg") });

            
            SelectCommand = new Command(async () =>
            {
                var ProdDetail = new View.MainMenu.GamesDetail
                {
                    BindingContext = selectProduct
                };

                await Application.Current.MainPage.Navigation.PushAsync(ProdDetail);
            });
        }
    }
}
