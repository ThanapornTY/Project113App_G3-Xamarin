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
    public partial class GamesDetail : ContentPage
    {
        public GamesDetail()
        {
            InitializeComponent();
        }

        public async void GotoFind_Click (object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View.MainMenu.FindGame());
        }
    }
}