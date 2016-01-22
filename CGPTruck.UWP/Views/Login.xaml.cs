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
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace CGPTruck.UWP.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void PasswordBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                Button_Click(null, null);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Connecter_Button.Content = new ProgressRing() { IsActive = true };
            if (await WebApiService.Current.Authenticate(Username_TextBox.Text, Password_PasswordTextBox.Password))
                Frame.Navigate(typeof(MainPage));
            else {
                Message_TextBlock.Text = "Identifiant erronés !";
                Connecter_Button.Content = new TextBlock() { Text = "Se connecter" };
            }
        }


    }
}
