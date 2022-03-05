using Project113_G3_Xamarin.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

using Project113_G3_Xamarin.APIs;


namespace Project113_G3_Xamarin.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<GamesModel> Games
        {
            get
            {
                return myproducts;
            }
            set
            {
                myproducts = value;
                var args = new PropertyChangedEventArgs(nameof(GamesModel));
                PropertyChanged?.Invoke(this, args);

            }

        }

        ObservableCollection<GamesModel> myproducts;

        public Command SelectCommand { get; }
        public GamesModel selectProduct { get; set; }

        ApiService apiService;


        public HomeViewModel()
        {
            
            Games = new ObservableCollection<GamesModel>();

            apiService = new ApiService();

            GetGameModel();

            SelectCommand = new Command(async () =>
            {
                var ProdDetail = new View.MainMenu.GamesDetail
                {
                    BindingContext = selectProduct
                };

                await Application.Current.MainPage.Navigation.PushAsync(ProdDetail);
            });
        }

        async void GetGameModel()
        {
            Games = await apiService.GetGameModel();
            Console.WriteLine(Games);
        }
    }
}
