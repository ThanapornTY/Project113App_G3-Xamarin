using Project113_G3_Xamarin.APIs;
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
    public partial class ReportPage : ContentPage
    {
        //ObservableCollection<ReportUserModel> reportUsers;

        public ReportUserModel reportUsers;
        
        ApiService apiService;

        public Command ReportCommand { get; }

        
        
        private void Submit_Clicked(object s, EventArgs e)
        {
            //RadioButton button = s as RadioButton;
            //sex = $"{button.Content}";

            reportUsers = new ReportUserModel();
            
    
            if (Re1.IsChecked)
            {
                reportUsers.RQrp_Toppic = Re1.Value.ToString();
                reportUsers.RQrp_ToUserName = UserName_report.Text;
                reportUsers.RQrp_Date = DateTime.Now;
                reportUsers.RQrp_Note = ReNote.Text;

            }
            if (Re2.IsChecked)
            {
                reportUsers.RQrp_Toppic = Re2.Value.ToString();
                reportUsers.RQrp_ToUserName = UserName_report.Text;
                reportUsers.RQrp_Date = DateTime.Now;
                reportUsers.RQrp_Note = ReNote.Text;
            }
            if (Re3.IsChecked)
            {
                reportUsers.RQrp_Toppic = Re3.Value.ToString();
                reportUsers.RQrp_ToUserName = UserName_report.Text;
                reportUsers.RQrp_Date = DateTime.Now;
                reportUsers.RQrp_Note = ReNote.Text;
            }
            if (Re4.IsChecked)
            {
                reportUsers.RQrp_Toppic = Re4.Value.ToString();
                reportUsers.RQrp_ToUserName = UserName_report.Text;
                reportUsers.RQrp_Date = DateTime.Now;
                reportUsers.RQrp_Note = ReNote.Text;
            }

            DisplayAlert("Message", "Report: " + reportUsers.RQrp_Toppic + " \n" + reportUsers.RQrp_ToUserName + " \n" + reportUsers.RQrp_Date + " \n" + reportUsers.RQrp_Note, "OK");

        }

        public ReportPage()
        {
            InitializeComponent();

            reportUsers = new ReportUserModel();
            apiService = new ApiService();

            
            ReportCommand = new Command(async () =>
            {

                var response = await apiService.GetReportUser(reportUsers);

                if (response)
                {
                    await Application.Current.MainPage.DisplayAlert("Regiater", "Register successfully!!", "OK");

                    //await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainTabbedPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Regiater", "Fail!!", "OK");
                }
            });
        }
        /*
        private async void Submit_Clicked(object s, EventArgs e)
        {
            //RadioButton button = s as RadioButton;
            //sex = $"{button.Content}";

            reportUsers = new ReportUserModel();
            apiService = new ApiService();
            var response = await apiService.GetReportUser(reportUsers);

            
            if (response)
            {
                if (Re1.IsChecked)
                {
                    reportUsers.RQrp_Toppic = Re1.Value.ToString();
                    reportUsers.RQrp_ToUserName = UserName_report.Text;
                    reportUsers.RQrp_Date = DateTime.Now;
                    reportUsers.RQrp_Note = ReNote.Text;

                }
                if (Re2.IsChecked)
                {
                    reportUsers.RQrp_Toppic = Re2.Value.ToString();
                    reportUsers.RQrp_ToUserName = UserName_report.Text;
                    reportUsers.RQrp_Date = DateTime.Now;
                    reportUsers.RQrp_Note = ReNote.Text;
                }
                if (Re3.IsChecked)
                {
                    reportUsers.RQrp_Toppic = Re3.Value.ToString();
                    reportUsers.RQrp_ToUserName = UserName_report.Text;
                    reportUsers.RQrp_Date = DateTime.Now;
                    reportUsers.RQrp_Note = ReNote.Text;
                }
                if (Re4.IsChecked)
                {
                    reportUsers.RQrp_Toppic = Re4.Value.ToString();
                    reportUsers.RQrp_ToUserName = UserName_report.Text;
                    reportUsers.RQrp_Date = DateTime.Now;
                    reportUsers.RQrp_Note = ReNote.Text;
                }

                await Application.Current.MainPage.DisplayAlert("Regiater", "Register successfully!!", "OK");

                //await Application.Current.MainPage.Navigation.PushModalAsync(new View.MainTabbedPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Regiater", "Fail!!", "OK");
            }



        }
        */
    }
}