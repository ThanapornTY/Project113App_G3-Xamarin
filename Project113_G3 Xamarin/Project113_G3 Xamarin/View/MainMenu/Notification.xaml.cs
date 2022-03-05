using Project113_G3_Xamarin.Model;
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
    public partial class Notification : ContentPage
    {
        ObservableCollection<NotificationModel> notificationModels;

        ApiService apiService;


        public Notification()
        {
            InitializeComponent();

            //notificationModels = new ObservableCollection<NotificationModel>();

            apiService = new ApiService();

            GetNotiAPI();

            NotiList.ItemsSource = notificationModels;


        }

        async void RePage (System.Object sender, System.EventArgs e)
        {
            await Task.Delay(3000);

            //notificationModels = new ObservableCollection<NotificationModel>(Item);
            RePageView.IsRefreshing = false;

        }

        
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var keyword = Games.Where(g => g.NameGame.StartsWith(e.NewTextValue));

            var keyword = notificationModels.Where(g => g.Title.StartsWith(e.NewTextValue));
            NotiList.ItemsSource = keyword;

        }

        async void GetNotiAPI()
        {
            notificationModels = await apiService.GetNotificationModel();
            Console.WriteLine(notificationModels);
        }
    }
}