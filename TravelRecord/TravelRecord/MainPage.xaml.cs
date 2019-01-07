using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Password.Text))
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
