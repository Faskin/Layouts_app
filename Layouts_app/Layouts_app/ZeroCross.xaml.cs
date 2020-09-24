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
        bool turn;
        Label cT;
        Image boxs;
        Button resetButton;
        const int gridColumns = 3;

        public ZeroCross()
        {
            
            Grid ground = new Grid()
            {
                HeightRequest = 600,
            };
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
                    {HeightRequest = 100, BackgroundColor = Color.FromHex("DEF7FE") };
                    ground.Children.Add(boxs, i, j);
                    var tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    boxs.GestureRecognizers.Add(tap);
                }
            }
            resetButton = new Button()
            {
                Text = "Reset Game",
                BackgroundColor = Color.FromHex("DEF7FE"),
                HorizontalOptions = LayoutOptions.StartAndExpand

            };
            cT = new Label()
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

            };
            
           
            StackLayout buttonLayout = new StackLayout()
            {
                BackgroundColor = Color.Black,
                Children = { resetButton }
            };
            StackLayout stackLayout = new StackLayout()
            {
                BackgroundColor = Color.Black,
                Children = { ground, buttonLayout, cT }
            };

            Content = stackLayout;
            cT.Text = turn ? "X Player" : "Z Player";
            
        }
        private void updateT()
        {
            if (turn = true)
            {
                turn = false;
                cT.Text = "X Player";

            }
            if (turn = false)
            {
                turn = true;
                cT.Text = "Z Player";
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            
            
        }
    }
}
