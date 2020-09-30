using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;

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
        public ZeroCross()

        {
            ground = startGame();

            resetButton = new Button()
            {
                Text = "Reset Game",
                BackgroundColor = Color.FromHex("DEF7FE"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                

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
            resetButton.Clicked += ResetButton_Clicked;



        }

        

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            foreach (Image image in ground.Children)
            {
                image.Source = "";
            }
            randomTurn();
           
            
        }

        private Grid startGame()
        {
            Grid ground = new Grid()

            {
                HeightRequest = 450,
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
                    {
                       
                        HeightRequest = 100,
                        BackgroundColor = Color.FromHex("DEF7FE")
                    };
                    ground.Children.Add(boxs, i, j);
                    var tap = new TapGestureRecognizer();
                    boxs.GestureRecognizers.Add(tap);
                    tap.Tapped += Box_Tapped;
                }
            }
            return ground;
        }
        

        private void Box_Tapped(object sender, EventArgs e)
        {
            Image boxs = sender as Image;
            if (turn)
            {
                boxs.Source = "zero.png";
                UpdateT();
                cT.Text = "1 Player";
            }

            else
            {
                turn = true;
                boxs.Source = "cross.png";
                cT.Text = "2 Player";


            }
            


        }


        private void randomTurn()
        {
            Random random = new Random();
            turn = Convert.ToBoolean(random.Next(2));
            cT.Text = turn? "1 Player" : "2 Player";
        }
        private void UpdateT()
        {
            if (turn == true)
            {
                turn = false;

            }

            else 
            {
                turn = true;
               
            }
            
        }
    }
}
