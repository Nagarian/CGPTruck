using CGPTruck.UWP.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace CGPTruck.UWP.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Profile : Page
    {
        Settings s = Settings.getInstance();
        public Profile()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            titleProfile.Text = (await WebApiService.Current.GetUser()).FirstName;
            int id = (await WebApiService.Current.GetUser()).Id;
            image.Source = new BitmapImage(new Uri("http://syfher15.fr/Downloads/Ingesup/" + id + ".jpg", UriKind.Absolute));
            desc.Text = (await WebApiService.Current.GetUser()).FirstName + " " + (await WebApiService.Current.GetUser()).LastName + " (" + (await WebApiService.Current.GetUser()).Birthday.Date + ") \n";
            //desc.Text+= (await WebApiService.Current.GetUser()).
        }
    }
}
