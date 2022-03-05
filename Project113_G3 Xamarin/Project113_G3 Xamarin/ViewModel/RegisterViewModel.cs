using Project113_G3_Xamarin.APIs;
using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Project113_G3_Xamarin.ViewModel
{
    class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterModel Regismodel { get; set; }

        ApiService apiService;

        public Command RegistersCommand { get; }

        public Command BackCommand { get; }


        public RegisterViewModel()
        {
            Regismodel = new RegisterModel();
            apiService = new ApiService();



            BackCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            
            RegistersCommand = new Command(async () =>
            {
                var response = await apiService.Register(Regismodel);

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
    }
}
