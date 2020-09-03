using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Light : ContentPage
    {
        public Light()
        {
            InitializeComponent();
        }
        Random rnd = new Random();

        private void btn_Clicked(object sender, EventArgs e)
        {
           int c=rnd.Next(1, 4);
            if (c==1)
            {
                red.BackgroundColor = Color.FromRgb(255, 0, 0);
                yell.BackgroundColor = Color.Gray;
                green.BackgroundColor = Color.Gray;
            }
            else if(c==2)
            {
                red.BackgroundColor = Color.Gray;
                yell.BackgroundColor = Color.Yellow;
                green.BackgroundColor = Color.Gray;
            }
            else if (c==3)
            {
                red.BackgroundColor = Color.Gray;
                yell.BackgroundColor = Color.Gray;
                green.BackgroundColor = Color.Green;
               
            }

        }
        

        private void btn2_Clicked(object sender, EventArgs e)
        {
            red.BackgroundColor = Color.FromRgb(100,100,100);
            green.BackgroundColor = Color.Green;
            yell.BackgroundColor = Color.FromHex("#aaaaaa");

        }
    }
}