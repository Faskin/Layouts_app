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
        Grid ground;
        bool turn;
        Label cT;
        Image boxs;
        Button resetButton;
        const int gridColumns = 3;
        private const bool Zero = false;
        private const bool Cross = true;
        Dictionary<Image, int> ticTac;
        Dictionary<Image, int[]> boxsPos;
        public ZeroCross()
        {
            
            Grid ground = new Grid()
            {
                HeightRequest = 600,
            };
            for (int i = 0; i < gridColumns; i++)
            {
                ground.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            
            for (int i = 0; i < gridColumns; i++)
            {
                for (int j = 0; j < gridColumns; j++)
                {
                    boxs = new Image
                    {HeightRequest = 100, BackgroundColor = Color.FromHex("DEF7FE") };
                    ground.Children.Add(boxs, i, j);
                    boxsPos.Add(boxs, new int[2] { i, j });
                    var tap = new TapGestureRecognizer();
                    boxs.GestureRecognizers.Add(tap);
                    tap.Tapped += box_Tapped;
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
            randomTurn();
            
        }

        private void box_Tapped(object sender, EventArgs e)
        {
            Image boxs = sender as Image;
            if (turn == Cross && !ticTac.ContainsKey(boxs))
            {
                ticTac[boxs] = 1;
                updateT(boxs);

            }
            else if (turn == Zero && !ticTac.ContainsKey(boxs))
            {
                ticTac[boxs] = 2;
                updateT(boxs);
            }

        }

        private void randomTurn()
        {
            Random random = new Random();
            turn = Convert.ToBoolean(random.Next(2));
            cT.Text = turn ? "1 Player" : "2 Player";
        }
        private void updateT(Image boxs )
        {
            if (ticTac[boxs] == 1)
            {
                boxs.Source = "cross.jpg";
                turn = Cross;
                cT.Text = "This turn: 1 Player";

            }
            else
            {
                boxs.Source = "zero.jpg";
                turn = Zero;
                cT.Text = "This turn: 2 Player";
            }
            
        }
    }
}
