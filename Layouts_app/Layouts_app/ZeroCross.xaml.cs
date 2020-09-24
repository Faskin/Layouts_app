using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_app
{
    public partial class ZeroCross : ContentPage
    {
        Image boxs;
        Button resetButton;
        const int gridColumns = 3;

        public ZeroCross()
        {

            StackLayout stackLayout = new StackLayout();
            Grid ground = new Grid()
            {
                HeightRequest = 100,
            }
            for (int i = 0; i < gridColumns; i++)
            {
                ground.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                ground.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            
            for (int i = 0; i < gridColumns; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {
                    boxs = new Image
                    {HeightRequest = 100, BackgroundColor = Color.FromHex("#2485AB")};
                    ground.Children.Add(boxs, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    boxs.GestureRecognizers.Add(tap);
                }
            }
            resetButton = new Button()
            {
                Text = "Reset Game"
            }
        }
        
        private void Tap_Tapped(object sender, EventArgs e)
        {

            
        }
    }
}
