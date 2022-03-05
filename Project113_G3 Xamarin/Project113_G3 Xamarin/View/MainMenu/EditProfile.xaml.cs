using Project113_G3_Xamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project113_G3_Xamarin.View.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfile : ContentPage
    {
        public SQLiteConnection conn;
        public RegisterModel regmodel;
        public EditProfile()
        {
            InitializeComponent();

            conn = DependencyService.Get<SQLiteDroid>().GetConnection();
            conn.CreateTable<RegisterModel>();
        }

        private void DisplayDetails()
        {

            RegisterModel reg = new RegisterModel();

            reg.UID = uid_useer.Text;
            reg.Name = userName_user.Text;
            reg.Email_User = email_user.Text;
            reg.Bd_User = datepicker_user.Date.ToString();
            reg.Password = password_user.Text;
            reg.GenderUser = gender_user.Text;

            int x = 0;

            if (!string.IsNullOrEmpty(uid_useer.Text) && !string.IsNullOrEmpty(userName_user.Text) && !string.IsNullOrEmpty(email_user.Text))
            {
                try
                {
                    x = conn.Update(reg);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (x == 1)
                {
                    DisplayAlert("Update", "Update Finished", "OK");
                }
                else
                {
                    DisplayAlert("Update Failled", "Please try again", "ERROR");
                }
            }
            else
            {
                DisplayAlert("Requires", "Not Complete!", "OK");
            }
        }
        private void Update_Clicked(object sender, EventArgs e)
        {
            DisplayDetails();
        }

        private void Cancal_Clicked(object sender, EventArgs e)
        {
            uid_useer.Text = "";
            userName_user.Text = "";
            gender_user.Text = "";

        }
    }


}