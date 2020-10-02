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
    public partial class Lumememm : ContentPage
    {
        private Label RText, GText, BText;
        private Slider RSlider, GSlider, BSlider;
        private readonly int[] RGB = new int[3];
        private Frame vedro2, vedro, head, body;
        Button BtnVisible, BtnColor, BtnReset;
        public Lumememm()
        {
            
            head = new Frame()
            {
                WidthRequest = 100,
                HeightRequest = 100,
                BackgroundColor = Color.White,
                CornerRadius = 180,
                Margin = new Thickness(150, 80, 150, -85),


            };
            vedro2 = new Frame()
            {

                HeightRequest = 40,
                BackgroundColor = Color.DarkGray,
                CornerRadius = 0,
                Margin = new Thickness(160, 60, 160, -70),

            };

            vedro = new Frame()
            {
                WidthRequest = 10,
                HeightRequest = 5,
                BackgroundColor = Color.Gray,
                CornerRadius = 0,
                Margin = new Thickness(140, 60, 140, -85),

            };


            body = new Frame()
            {
                WidthRequest = 150,
                HeightRequest = 150,
                BackgroundColor = Color.White,
                CornerRadius = 180,
                Margin = new Thickness(125, 80, 125, 0),

            };

            BtnVisible = new Button()
            {
                TextColor = Color.White,
                Text = "Visble On/Off",
                BackgroundColor = Color.MediumPurple,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                BorderColor = Color.Black,

            };

            BtnColor = new Button()
            {
                TextColor = Color.White,
                Text = "Random color",
                BackgroundColor = Color.MediumPurple,
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                BorderColor = Color.Black,

            };

            RText = new Label()
            {
                Text = "Red: 0",
                WidthRequest = 80,
                
            };

            RSlider = new Slider()
            {
                
                BackgroundColor = Color.IndianRed,
                Minimum = 0,
                Maximum = 255,
                Value = 0,
                

                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            GText = new Label()
            {
                Text = "Green: 0",
                WidthRequest = 80,

            };

            GSlider = new Slider()
            {
                BackgroundColor = Color.Green,
                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            BText = new Label()
            {
                Text = "Blue: 0",
                WidthRequest = 80,

            };

            BSlider = new Slider()
            {
                BackgroundColor = Color.Blue,
                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand,

            };

            BtnReset = new Button()
            {
                TextColor = Color.White,
                BackgroundColor = Color.MediumPurple,
                Text = "Reset Color",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                BorderColor = Color.Black,

            };




            StackLayout buttonsLayout = new StackLayout()
            {
                Children = { BtnVisible, BtnColor, BtnReset, RSlider, RText, GSlider, GText, BSlider, BText },
                HorizontalOptions = LayoutOptions.Center,
                

            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { vedro2, vedro, head, body, buttonsLayout },
                 
            };
            stackLayout.Orientation = StackOrientation.Vertical;
            Content = stackLayout;



            BtnVisible.Clicked += BtnVisible_Clicked;
            BtnColor.Clicked += BtnColor_Clicked;
            RSlider.ValueChanged += OnSliderValueChanged;
            GSlider.ValueChanged += OnSliderValueChanged;
            BSlider.ValueChanged += OnSliderValueChanged;
            BtnReset.Clicked += BtnReset_Clicked;

        }

        private async void BtnReset_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Reset Color of snowman", "Are you sure you want to reset the color?", "Yes", "No");
            if (answer == true)
            {
                ResetColor();
            }

        }

        private void ResetColor()
        {
            vedro2.BackgroundColor = Color.DarkGray;
            vedro.BackgroundColor = Color.Gray;
            head.BackgroundColor = Color.White;
            body.BackgroundColor = Color.White;
        }

        private async void BtnColor_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Random Color for snowman", "A random color will be chosen for the snowman", "OK");
            vedro2.BackgroundColor = RandomColor();
            vedro.BackgroundColor = RandomColor();
            head.BackgroundColor = RandomColor();
            body.BackgroundColor = RandomColor();
        }

        private void BtnVisible_Clicked(object sender, EventArgs e)
        {
            vedro2.IsVisible = !vedro2.IsVisible;
            vedro.IsVisible = !vedro.IsVisible;
            head.IsVisible = !head.IsVisible;
            body.IsVisible = !body.IsVisible;
        }
        /*private void VisibleOn()
        {
            vedro2.Opacity = 100;
            vedro.Opacity = 100;
            head.Opacity = 100;
            body.Opacity = 100;
        }

        private void VisibleOff()
        {
            vedro2.Opacity = 0;
            vedro.Opacity = 0;
            head.Opacity = 0;
            body.Opacity = 0;
        }
        */

        private Color RandomColor()
        {
            Random random = new Random();
            RGB[0] = random.Next(0, 256);
            RGB[1] = random.Next(0, 256);
            RGB[2] = random.Next(0, 256);
            return Color.FromRgb(RGB[0], RGB[1], RGB[2]);
        }
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == RSlider)
            {
                RGB[0] = Convert.ToInt32(e.NewValue);
                RGBValues();

            }
            
            else if (sender == GSlider)
            {
                RGB[1] = Convert.ToInt32(e.NewValue);
                RGBValues();
            }
            else if (sender == BSlider)
            {
                RGB[2] = Convert.ToInt32(e.NewValue);
                RGBValues();
            }
            vedro2.BackgroundColor = Color.FromRgb((int)RSlider.Value,
                                          (int)BSlider.Value,
                                          (int)GSlider.Value);

            vedro.BackgroundColor = Color.FromRgb((int)RSlider.Value,
                                         (int)BSlider.Value,
                                         (int)GSlider.Value);

            head.BackgroundColor = Color.FromRgb((int)RSlider.Value,
                                         (int)BSlider.Value,
                                         (int)GSlider.Value);
            body.BackgroundColor = Color.FromRgb((int)RSlider.Value,
                                         (int)BSlider.Value,
                                         (int)GSlider.Value);

        }
        private void RGBValues()
        {
            RText.Text = $"Red: {RGB[0]}";
            RSlider.Value = RGB[0];
            GText.Text = $"Green: {RGB[1]}";
            GSlider.Value = RGB[1];
            BText.Text = $"Blue: {RGB[2]}";
            BSlider.Value = RGB[2];
        }
       
        

    }
}