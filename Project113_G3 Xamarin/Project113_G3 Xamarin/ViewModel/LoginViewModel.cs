using Project113_G3_Xamarin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Project113_G3_Xamarin.ViewModel
{
    class LoginViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginModel Logins { get; set; }
        public Command RegistersCommand { get; }

        public Command ProductListCommand { get; }

        string result;
        public string Result
        {
            get => result;
            set
            {
                result = value;
                var args = new PropertyChangedEventArgs(nameof(Result));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            Logins = new LoginModel();
            LoginCommand = new Command(async () =>
            {
                if (Logins.Email == "th@gmail.com" && Logins.Password == "1234")
                {
                    Result = "Success";

                    await Application.Current.MainPage.Navigation.PushAsync(new View.MainTabbedPage());

                }
                else if (Logins.Email == null && Logins.Password == null)
                {
                    Result = "Please input your Email and Password";
                }
                else
                {
                    Result = "Fail!!";
                }
            });

            RegistersCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.Register());
            });
        }
    }
}
