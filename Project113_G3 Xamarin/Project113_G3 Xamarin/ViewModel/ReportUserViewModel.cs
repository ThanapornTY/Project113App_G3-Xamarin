using Project113_G3_Xamarin.APIs;
using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Project113_G3_Xamarin.ViewModel
{
    class ReportUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ReportUserModel reportUsers { get; set; }

        public Command Submit_Clicked { get; }

        ApiService apiService;

        public ReportUserViewModel()
        {
            reportUsers = new ReportUserModel();

            Submit_Clicked = new Command(async () =>
            {
                var response = await apiService.GetReportUser(reportUsers);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Report", "Report successfully!!", "OK");

                    //await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainTabbedPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Report", "Report Fail!!", "OK");
                }
            });
        }
    }
}
