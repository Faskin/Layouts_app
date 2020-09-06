using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor2 : ContentPage
    {
        public Valgusfoor2()
        {
            //InitializeComponent();
            Label punane = new Label()
            {
                Text = "punane",
                TextColor = Color.Black,
                FontSize=30,
                FontAttributes=FontAttributes.Bold,
                             
            };
            Frame pun = new Frame()
            {
                BackgroundColor = Color.Red,
                Content = punane,
                CornerRadius = 90,
                Margin = new Thickness(145, 0, 145, 0),



            };
            Label kollane = new Label()
            {
                Text = "kollane",
                TextColor = Color.Black,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };
            Frame koll = new Frame()
            {
                BackgroundColor = Color.Yellow,
                Content = kollane,
                CornerRadius = 90,
                Margin = new Thickness(145, 0, 145, 0),



            };
            Label roheline = new Label()
            {
                Text = "roheline",
                TextColor = Color.Black,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold

            };
            Frame roh = new Frame()
            {
                BackgroundColor = Color.Green,
                Content = roheline,
                CornerRadius = 90,
                Margin = new Thickness(145, 0, 145, 0),





            };
            Button btn = new Button()
            {
                Text = "On",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                
                HorizontalOptions = LayoutOptions.Center



            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { pun, koll, roh, btn, }
            };
            stackLayout.Orientation = StackOrientation.Vertical;
            Content = stackLayout;
        }
    }
}