using Project113_G3_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project113_G3_Xamarin.APIs;

namespace Project113_G3_Xamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public SQLiteConnection conn;
        //public Register_Model register_Model;

        public Register()
        {
            InitializeComponent();

            //conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            //conn.CreateTable<Register_Model>();

        }

        /*

        public async void Register_Clicked(object odj, EventArgs args)
        {
            /*
            DisplayAlert(
                "DATE", datepicker.Date.ToShortDateString(), "OK");
            

            RegisterModel reg = new RegisterModel();
            reg.UID = uid_useer.Text;
            reg.Name = userName_user.Text;
            reg.Email_User = email_user.Text;
            reg.Password = password_user.Text;
            reg.Bd_User = datepicker_user.Date.ToString();
            reg.GenderUser = gender_user.Text;
            
            int x = 0;

            if (!string.IsNullOrEmpty(uid_useer.Text) && !string.IsNullOrEmpty(userName_user.Text) && !string.IsNullOrEmpty(email_user.Text) && !string.IsNullOrEmpty(password_user.Text))
            {
                try
                {
                    x = conn.Insert(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (x == 1)
                {
                    DisplayAlert("Resistration", "Thanks for Resistration", "OK");

                    await Navigation.PushAsync(new View.MainTabbedPage());


                }
                else
                {
                    DisplayAlert("Resistration Failled", "Please try again", "ERROR");
                }
            }
            else
            {
                DisplayAlert("Resistration", "Not Complete!", "OK");
            }
        }*/


        public async void OnImageNameTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushAsync(new View.Login());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}