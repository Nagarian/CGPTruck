using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace CGPTruck.UWP.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Missions : Page
    {
        List<MissionType> listMission = new List<MissionType>();
        MainPage mainP = null;
        

        public Missions()
        {
            this.InitializeComponent();
            List<Entities.Entities.Mission> result = WebApiService.Current.GetMissions().Result;


            

            listMission.Add(new MissionType() { name = "Livrer Ordinateur", position = new BasicGeoposition() { Latitude = 44.78670251489458, Longitude = -0.6313490867614746 }, description = "Liste des appareils a livrer : \n-HP 12\nHP-13\nDell Mes couilles\n\nFaire signer le bon de livraisons!!", isActive = true });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainP = (MainPage)e.Parameter;
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Title.Text = listMission.First(item => item.isActive == true).name + ":";
            textBlock1.Text = listMission.First(item => item.isActive == true).description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Visibility = Visibility.Collapsed;
            mainP.setDestination(listMission.First(item => item.isActive == true).position);
        }
    }

    public class MissionType
    {
        public string name { get; set; }
        public string description { get; set; }
        public BasicGeoposition position { get; set; }
        public bool isActive { get; set; }

        public MissionType() {}
    }
}
