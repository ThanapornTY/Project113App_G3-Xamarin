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
    public partial class ChatApp : ContentPage
    {
        ObservableCollection<string> itemList;
        string itemSelected;
        public ChatApp()
        {
            InitializeComponent();
            itemList = new ObservableCollection
            <string>();
            lstview.ItemsSource = itemList;
        }

        public void AddList_Clicked
        (object sender, EventArgs e)
        {
            itemList.Add(InputText.Text);

        }
        public void DelList_Clicked
        (object sender, EventArgs e)
        {
            itemList.Remove
            (itemSelected);
        }
        public async void ListBack_Clicked
        (object sender, EventArgs e)
        {
            await Navigation.PushAsync
            (new MainPage());
        }
        public void lst_ItemSelected
        (object sender, SelectedItemChangedEventArgs e)
        {
            itemSelected = e.SelectedItem.ToString();
        }
    }
}