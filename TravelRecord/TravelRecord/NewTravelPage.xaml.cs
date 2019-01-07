using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var p = new Model.Post()
            {
                Experience = xpEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.Dbl))
            {
                conn.CreateTable<Post>();
                var rows = conn.Insert(p);

                if (rows > 0)
                    DisplayAlert("Success", "Experience was saved", "Ok");
                else
                    DisplayAlert("Error", "Experience not saved", "Ok");
            }            
        }
    }
}