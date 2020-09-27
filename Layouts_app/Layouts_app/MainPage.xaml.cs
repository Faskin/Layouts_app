using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Layouts_app
{
    public partial class MainPage : ContentPage
    {
        BoxView box;
        public MainPage()
           

        {
            Grid grid = new Grid();
            for (int i = 0; i < 5; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; 0 < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    box = new BoxView { Color = Color.FromRgb(200, 100, 50) };
                    grid.Children.Add(box, 1, j);
                    var tap = new TapGestureRecognizer();
                    //tap.Tapped += Tap_Tapped;
                    box.GestureRecognizers.Add(tap);


                }

            }
            
        }

        //private void Tap_Tapped(object sender, EventArgs e)
        //{
           // BoxView box = sender as BoxView;
            //box.Color = Color.FromRgb(0, 0, 0);
        //}
    }
}
