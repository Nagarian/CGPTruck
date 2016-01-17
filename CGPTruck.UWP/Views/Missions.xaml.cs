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
    public sealed partial class Missions : Page
    {
        public Missions()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor mattis porttitor. In hac habitasse platea dictumst. Nam eu mollis leo, quis ultricies neque. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur pharetra, magna et volutpat maximus, orci sapien tincidunt magna, nec molestie risus ante et nibh. Maecenas volutpat ullamcorper iaculis. Nunc tristique ex eu nisl luctus vestibulum. Praesent placerat velit eget hendrerit sollicitudin. Aenean et lacus eu nisi bibendum bibendum. Aenean in auctor nunc, quis vulputate enim. ";
            textBlock1.Text += "\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempor mattis porttitor. In hac habitasse platea dictumst. Nam eu mollis leo, quis ultricies neque. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur pharetra, magna et volutpat maximus, orci sapien tincidunt magna, nec molestie risus ante et nibh. Maecenas volutpat ullamcorper iaculis. Nunc tristique ex eu nisl luctus vestibulum. Praesent placerat velit eget hendrerit sollicitudin. Aenean et lacus eu nisi bibendum bibendum. Aenean in auctor nunc, quis vulputate enim. ";
        }
    }
}
