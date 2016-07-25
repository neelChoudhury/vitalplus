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
using Windows.Devices.Geolocation;
using System.Diagnostics;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cord = e.Parameter;
            Debug.WriteLine(cord.ToString());
            String[] snk = new String[2];
            snk = cord.ToString().Split('#');
            Debug.WriteLine(snk[0]);
            Debug.WriteLine(snk[1]);
            //Double.TryParse(snk[0], Double);
            Double Lat = Convert.ToDouble(snk[0]);
            Double longi = Convert.ToDouble(snk[1]);
            
            
            MapControl1.Center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = Lat,
                    Longitude = longi
                });
            MapControl1.ZoomLevel = 19;
            MapControl1.LandmarksVisible = true;

            
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Frame.GoBack();

            

        }
    }
}
