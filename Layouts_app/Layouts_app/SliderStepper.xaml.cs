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
    public partial class SliderStepper : ContentPage
    {
       
        Slider slider1, Rslider, Gslider, Bslider;
        Stepper stepper1;
        Frame frame1;
        Editor editor1;
        


        public SliderStepper()
        {
            frame1 = new Frame()
            {
                BackgroundColor = Color.FromRgb(0, 0, 0),
                HorizontalOptions = LayoutOptions.Center




            };
            stepper1 = new Stepper()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 5,
                Increment = 2,
                HorizontalOptions = LayoutOptions.End
            };
            slider1 = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Rslider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Gslider = new Slider()
            {
                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Bslider = new Slider()
            {

                Minimum = 0,
                Maximum = 255,
                Value = 0,

                HorizontalOptions = LayoutOptions.FillAndExpand,
                
            };


            editor1 = new Editor()
            {
                Text = "Some text",

                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { frame1, stepper1, Rslider, Gslider, Bslider  }
            };
            stackLayout.Orientation = StackOrientation.Vertical;
            Content = stackLayout;
            Rslider.ValueChanged += OnSliderValueChanged;
            Gslider.ValueChanged += OnSliderValueChanged;
            Bslider.ValueChanged += OnSliderValueChanged;
            slider1.ValueChanged += Slider1_ValueChanged;
            stepper1.ValueChanged += Stepper1_ValueChanged;





        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == Rslider)
            {
                Rslider.Value = e.NewValue;
            }
            else if (sender == Gslider)
            {
                Gslider.Value = e.NewValue;
            }
            else if (sender == Bslider)
            {
                Bslider.Value = e.NewValue;
            }

            frame1.BackgroundColor = Color.FromRgb((int)Rslider.Value,
                                          (int)Bslider.Value,
                                          (int)Gslider.Value);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            frame1.Scale = slider1.Value;
        }


        private void Stepper1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                frame1.Scale = e.NewValue;
                stepper1.Value = e.NewValue;
            }
        }

        private void Slider1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                frame1.Scale = e.NewValue;
                slider1.Value = e.NewValue;
            }
        }
    }
    
}