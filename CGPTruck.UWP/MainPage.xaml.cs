using CGPTruck.UWP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CGPTruck.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

        }



        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
            //string token = await client.AuthenticateUserAsync("jean-michel@gros-lourd.fr", "password");
            //User user = await client.GetUserInfoAsync(token);
            bool result = await WebApiService.Current.Authenticate("lala", "tototutu");
        }

        private void HamburgerButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void HomeButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frame.Visibility = Visibility.Collapsed;
        }

        private void ProfileButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (frame.CurrentSourcePageType != typeof(Profile))
                frame.Navigate(typeof(Profile));

            if (frame.Visibility == Visibility.Collapsed)
                frame.Visibility = Visibility.Visible;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MissionButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (frame.CurrentSourcePageType != typeof(Missions))
                frame.Navigate(typeof(Missions), this);

            if (frame.Visibility == Visibility.Collapsed)
                frame.Visibility = Visibility.Visible;
        }

        public async void setDestination(BasicGeoposition geop)
        {
            map.TrafficFlowVisible = true;
            map.Style = MapStyle.Road;
            MapService.ServiceToken = "vnevem6H-MEWqD795TAckw";

            Geolocator geolocator = new Geolocator() { ReportInterval = 2000 };
            // Carry out the operation.
            Geoposition pos = await geolocator.GetGeopositionAsync();
            geolocator.PositionChanged += Geolocator_PositionChanged;

            BasicGeoposition startLocation = new BasicGeoposition { Latitude = pos.Coordinate.Latitude, Longitude = pos.Coordinate.Longitude };

            // End at the city of Seattle, Washington.
            BasicGeoposition endLocation = geop;


            // Get the route between the points.
            MapRouteFinderResult routeResult =
                  await MapRouteFinder.GetDrivingRouteAsync(
                  new Geopoint(startLocation),
                  new Geopoint(endLocation),
                  MapRouteOptimization.TimeWithTraffic);


            map.Routes.Clear();

            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                // Use the route to initialize a MapRouteView.
                MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
                viewOfRoute.RouteColor = Colors.Blue;
                viewOfRoute.OutlineColor = Colors.Black;

                MessageDialog msg = new MessageDialog("Duree du trajet: " + routeResult.Route.EstimatedDuration.TotalMinutes.ToString() + " minutes");
                await msg.ShowAsync();
                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                map.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await map.TrySetViewBoundsAsync(
                      routeResult.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }

        }

        private async void Geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Geopoint snPoint = new Geopoint(new BasicGeoposition() { Latitude = args.Position.Coordinate.Latitude, Longitude = args.Position.Coordinate.Longitude });

                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/location41.png"));


                mapIcon1.Location = snPoint;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.ZIndex = 0;

                // Add the MapIcon to the map.
                map.MapElements.Clear();
                map.MapElements.Add(mapIcon1);
                // Center the map over the POI.
                map.Center = snPoint;
            });

            
        }



        //private async void MissionButton_Tapped(object sender, TappedRoutedEventArgs e)
        // {
        //    Map.TrafficFlowVisible = true;


        //     for (int i = 0; i < 13; i++)
        //     {
        //         // Specify a known location.
        //         BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 44.853 + i, Longitude = -0.566 + i/2 };
        //         Geopoint snPoint = new Geopoint(snPosition);

        //         // Create a MapIcon.
        //         MapIcon mapIcon1 = new MapIcon();
        //         mapIcon1.Location = snPoint;
        //         mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
        //         mapIcon1.Title = "Mother Fucker " + i;
        //         mapIcon1.ZIndex = 0;

        //         // Add the MapIcon to the map.
        //         Map.MapElements.Add(mapIcon1);

        //         // Center the map over the POI.
        //         if(i == 1)
        //             Map.Center = snPoint;
        //     }


        //     Map.ZoomLevel = 14;

        //     //await Map.TrySetViewAsync(new Geopoint(new BasicGeoposition() { Latitude = 44.853, Longitude = -0.566 }), 14);
        // }

        // private async void TrajetTest(object sender, TappedRoutedEventArgs e)
        // {
        //     // Start at Microsoft in Redmond, Washington.

        //     MapService.ServiceToken = "vnevem6H-MEWqD795TAckw";
        //     BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 44.85310338370592, Longitude = -0.5674400925636292 };

        //     // End at the city of Seattle, Washington.
        //     BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 44.78670251489458, Longitude = -0.6313490867614746 };


        //     // Get the route between the points.
        //     MapRouteFinderResult routeResult =
        //           await MapRouteFinder.GetDrivingRouteAsync(
        //           new Geopoint(startLocation),
        //           new Geopoint(endLocation),
        //           MapRouteOptimization.TimeWithTraffic);


        //     Map.Routes.Clear();

        //     if (routeResult.Status == MapRouteFinderStatus.Success)
        //     {
        //         // Use the route to initialize a MapRouteView.
        //         MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
        //         viewOfRoute.RouteColor = Colors.Yellow;
        //         viewOfRoute.OutlineColor = Colors.Black;

        //         MessageDialog msg = new MessageDialog("Duree du trajet: " + routeResult.Route.EstimatedDuration.TotalMinutes.ToString() + " minutes");
        //         //await msg.ShowAsync();
        //         // Add the new MapRouteView to the Routes collection
        //         // of the MapControl.
        //         Map.Routes.Add(viewOfRoute);

        //         // Fit the MapControl to the route.
        //         await Map.TrySetViewBoundsAsync(
        //               routeResult.Route.BoundingBox,
        //               null,
        //               Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
        //     }

        //     Map.StartContinuousRotate(5);
        // }
    }
}
