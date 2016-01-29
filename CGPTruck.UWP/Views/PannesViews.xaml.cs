using CGPTruck.UWP.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class PannesViews : Page
    {
        Settings s = Settings.getInstance();
        MainPage mainP;
        List<Entities.Entities.Failure> fails;
        public PannesViews()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainP = (MainPage)e.Parameter;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (s.actualFailure == null && ((await WebApiService.Current.GetMyFailures()).Find(item => item.State == Entities.Entities.FailureState.Processing)) == null)
            {
                fails = (await WebApiService.Current.GetMyFailures());
                List_ComboBox.ItemsSource = fails;

                Itineraire_Button.IsEnabled = false;
                Choose_Button.IsEnabled = false;
                Cancel_Button.IsEnabled = false;
            }
            else
            {
                

                List_ComboBox.Items.Clear();
                if (s.actualFailure == null)
                    s.actualFailure = ((await WebApiService.Current.GetMyFailures()).Find(item => item.State == Entities.Entities.FailureState.Processing));
                List_ComboBox.Items.Add(s.actualFailure);
                List_ComboBox.SelectedItem = s.actualFailure;
                List_ComboBox.IsEnabled = false;
                Cancel_Button.IsEnabled = true;
                Choose_Button.IsEnabled = false;
                Itineraire_Button.IsEnabled = true;
            }
        }

        private void List_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(List_ComboBox.SelectedItem != null)
            {
                Choose_Button.IsEnabled = true;
                Itineraire_Button.IsEnabled = false;
                Cancel_Button.IsEnabled = false;

                Title_TextBlock.Text = ((Entities.Entities.Failure)List_ComboBox.SelectedItem).Mission.Name;
                Date_TextBlock.Text = ((Entities.Entities.Failure)List_ComboBox.SelectedItem).Date.ToString();
            }
        }

        private void Itineraire_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Visibility = Visibility.Collapsed;
            mainP.setDestination(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = ((Entities.Entities.Failure)List_ComboBox.SelectedItem).Vehicule.Position.Latitude, Longitude = ((Entities.Entities.Failure)List_ComboBox.SelectedItem).Vehicule.Position.Longitude });
        }

        private async void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            s.actualFailure = ((Entities.Entities.Failure)List_ComboBox.SelectedItem);
            s.actualFailure.State = Entities.Entities.FailureState.Processing;

            await WebApiService.Current.PushFailureUpdate(s.actualFailure);

            Page_Loaded(null, null);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msg = new MessageDialog("Comment souhaitez vous definir la panne selectionné ?", "Update Panne");
            msg.Commands.Add(new UICommand("Retour", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            msg.Commands.Add(new UICommand("Annuler", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            msg.Commands.Add(new UICommand("Terminer", new UICommandInvokedHandler(this.CommandInvokedHandler)));

            msg.ShowAsync();
        }

        private async void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label == "Terminer")
            {
                s.actualFailure.State = Entities.Entities.FailureState.Resolved;
                await WebApiService.Current.PushFailureUpdate(s.actualFailure);

                s.actualFailure = null;
            }
            else if(command.Label == "Annuler")
            {
                s.actualFailure.State = Entities.Entities.FailureState.Declared;
                await WebApiService.Current.PushFailureUpdate(s.actualFailure);

                s.actualFailure = null;
            }

            Page_Loaded(null, null);
        }
    }
}
