using Project113_G3_Xamarin.APIs;
using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Project113_G3_Xamarin.ViewModel
{
    class NotificationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NotificationModel> notificationModel { get; set; }

        ApiService apiService;

        public NotificationViewModel()
        {
            notificationModel = new ObservableCollection<NotificationModel>();

            apiService = new ApiService();

            //notificationModel.Add(new NotificationModel { Title = "No.1", Description = "12345647866" });

            GetNotiAPI();

            //NotiList.ItemsSource = notificationModel;
        }

        async void GetNotiAPI()
        {
            notificationModel = await apiService.GetNotificationModel();
            Console.WriteLine(notificationModel);
        }
    }
}
