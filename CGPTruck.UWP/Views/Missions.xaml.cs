using CGPTruck.UWP.Entities.Entities;
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
        Entities.Entities.Mission mission;
        MainPage mainP = null;

        public Missions()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainP = (MainPage)e.Parameter;
            LoadMission();
            //Latitude = 44.78670251489458, Longitude = -0.6313490867614746
        }

        private async void LoadMission()
        {
            //GenerateData();
            var result = await WebApiService.Current.GetMyMissions();
            mission = result.FirstOrDefault();

            mission?.Steps.Add(new Entities.Entities.Step() { Step_Type = Entities.Entities.StepType.PickupProgressing });

            if (mission != null)
            {
                Title.Text = mission.Name;
                textBlock1.Text = mission.Description;
            }
            else
            {
                Title.Text = "Aucune mission attribuée";
                textBlock1.Text = "Patientez jusqu'a l'attribution d'une mission par l'administrateur. Faite vous un café en attendant :D";
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Visibility = Visibility.Collapsed;
            if (mission.Steps.Last().Step_Type == Entities.Entities.StepType.PickingUp)
                mainP.setDestination(new BasicGeoposition() { Latitude = mission.PickupPlace.Position.Latitude, Longitude = mission.PickupPlace.Position.Longitude });
            else
                mainP.setDestination(new BasicGeoposition() { Latitude = mission.DeliveryPlace.Position.Latitude, Longitude = mission.DeliveryPlace.Position.Longitude });
        }

        private void GenerateData()
        {
            mission = new Entities.Entities.Mission()
            {
                Name = "Nestle c'est fort en chocolat",
                Description = "It's an amazing mission to complete",
                PickupPlace = new Entities.Entities.Place()
                {
                    Name = "Taf",
                    Position = new Entities.Entities.Position()
                    {
                        Latitude = 44.7867,
                        Longitude = -0.6313
                    }
                },
                DeliveryPlace = new Entities.Entities.Place()
                {
                    Name = "Auchan Lac",
                    Position = new Entities.Entities.Position()
                    {
                        Latitude = 44.8807,
                        Longitude = -0.56578
                    }
                },
                Steps = new List<Entities.Entities.Step>()
            }; ;
        }
    }
}
