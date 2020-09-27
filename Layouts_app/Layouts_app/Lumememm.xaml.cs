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
        
        Frame vedro, head, body;
        public Lumememm()
        {

            vedro = new Frame()
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 180,
                Margin = new Thickness(125, 0, 125, 0),
                HorizontalOptions = LayoutOptions.Center

            };
            head= new Frame()
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 11,
                Margin = new Thickness(125, 50, 125, 50),
                HorizontalOptions = LayoutOptions.Center

            };
            body = new Frame()
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 30,
                Margin = new Thickness(125, 0, 125, 0),
                HorizontalOptions = LayoutOptions.Center
            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { vedro, head, body }
            };
            stackLayout.Orientation = StackOrientation.Vertical;
            Content = stackLayout;

        }
        
    }
}