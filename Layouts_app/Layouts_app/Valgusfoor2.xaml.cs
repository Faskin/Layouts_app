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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor2 : ContentPage
    {
        Label kollane, punane, roheline;
        Frame pun, koll, roh;
        Button sisse, valja, sizze;
        bool sisse_valja;
        public Valgusfoor2()
        {
            //InitializeComponent();
            punane = new Label()
            {
                Text = "punane",
                TextColor = Color.Black,
                FontSize=10,
                FontAttributes=FontAttributes.Bold,
                             
            };
            pun = new Frame()
            {
                BackgroundColor = Color.Red,
                Content = punane,
                CornerRadius = 90,
                Margin = new Thickness(125, 0, 125, 0),



            };
            kollane = new Label()
            {
                Text = "kollane",
                TextColor = Color.Black,
                FontSize = 10,
                FontAttributes = FontAttributes.Bold
            };
            koll = new Frame()
            {
                BackgroundColor = Color.Yellow,
                Content = kollane,
                CornerRadius = 90,
                Margin = new Thickness(125, 0, 125, 0),



            };
            roheline = new Label()
            {
                Text = "roheline",
                TextColor = Color.Black,
                FontSize = 10,
                FontAttributes = FontAttributes.Bold

            };
            roh = new Frame()
            {
                BackgroundColor = Color.Green,
                Content = roheline,
                CornerRadius = 90,
                Margin = new Thickness(125, 0, 125, 0),





            };
            sisse = new Button()
            {
                Text = "On",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                
                HorizontalOptions = LayoutOptions.EndAndExpand



            };
            valja = new Button()
            {
                Text = "Off",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,

                HorizontalOptions = LayoutOptions.End



            };
            sizze = new Button()
            {
                Text = "+Size",
                TextColor = Color.White,
                BackgroundColor = Color.Black,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,

                HorizontalOptions = LayoutOptions.End



            };
            valja.Clicked += Valja_Clicked;
            sisse.Clicked += Sisse_Clicked;
            sizze.Clicked += Sizze_Clicked;

            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            pun.GestureRecognizers.Add(tap);
            koll.GestureRecognizers.Add(tap);
            roh.GestureRecognizers.Add(tap);

            StackLayout stackLayout = new StackLayout()
            {
                Children = { pun, koll, roh, sisse, valja, sizze }
            };
            stackLayout.Orientation = StackOrientation.Vertical;
            Content = stackLayout;
        }

        private async void Sizze_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Вопрос", "Ты действительно хочешь этого?", "Да", "нет");
            if (answer == true)
            {
                pun.BackgroundColor = Color.Red;
                pun.BorderColor = Color.WhiteSmoke;
                roh.BackgroundColor = Color.Green;
                koll.BackgroundColor = Color.Yellow;
                for (int i = 0; i < 100; i++)
                {

                    punane.FontSize++;
                    kollane.FontSize++;
                    roheline.FontSize++;
                    await Task.Run(() => Thread.Sleep(1000));
                }
            }
        }
            
        

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            Frame fr = sender as Frame;

            if (sisse_valja == false)
            {
                await DisplayAlert("Hoiatus", "Сначала включи светофор", "OK");
            }
            else
            {
                if (fr == pun)
                {
                    punane.Text = "seitsa ja oota!!";

                }
                if (fr == koll)
                {
                    kollane.Text = "Untren";

                }
                if (fr == roh)
                {
                    roheline.Text = "Go";

                }

            }



        }

        private async void Sisse_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Hoiatus", "ValgusFoor põleb", "OK");
            pun.BackgroundColor = Color.Red;
            koll.BackgroundColor = Color.Yellow;
            roh.BackgroundColor = Color.Green;
            sisse_valja = true;
        }

        private async void Valja_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Hoiatus", "ValgusFoor on valjas", "OK");
            pun.BackgroundColor = Color.Gray;
            koll.BackgroundColor = Color.Gray;
            roh.BackgroundColor = Color.Gray;
            sisse_valja = false;
        }
    }
}