using Project113_G3_Xamarin.Model;
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
    public partial class QRGame : ContentPage
    {
        public RqGame rqGame;

        public Command RqGames;
        public QRGame()
        {
            InitializeComponent();

            RqGames = new Command(async () =>
            {

                if (rqGame.NameGame_Rq == null && rqGame.Deseription_Rq == null)
                {

                    await Application.Current.MainPage.DisplayAlert("Message", "Report: Fail! " , "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Message", "Report: " + rqGame.NameGame_Rq + " \n" + rqGame.Deseription_Rq, "OK");
                }

            });

           
        }
        /*
        public async void sub_rqGame (object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Message", "Report: " + rqGame.NameGame_Rq + " \n" + rqGame.Deseription_Rq , "OK");
        }*/


    }
}