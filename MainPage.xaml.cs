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
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.Text;
using Windows.UI.Popups;
using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static String str;
        public String[] snk = new String[15];
        public char delimiter = '#';
        public int n, z = 0;
        public Button[] ba = new Button[10];
        public bool exc = false;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            ba[0] = rb1;
            ba[1] = rb2;
            ba[2] = rb3;
            ba[3] = rb4;
            ba[4] = rb5;
            ba[5] = rb6;
            ba[6] = rb7;
            ba[7] = rb8;
            ba[8] = rb9;
            ba[9] = rb10;
            med.Text = "";
            avlb.Visibility = Visibility.Collapsed;
            //avlb1.Visibility = Visibility.Collapsed;
            for (int i = 0; i < 10; i++)
            {
                ba[i].Visibility = Visibility.Collapsed;
            }
        }
        private void sush()
        {
            snk = str.Split('#');
            int i = 0;
            foreach (string word in snk)
            {
                i++;
                //Debug.WriteLine(word);
                //snk[i++] = word;
            }
            n = i;
           
            //rb1.Click = snkfun();
            
            for (i = 0; i < n / 3; i++)
            {
                ba[i].Content = snk[3 * i];
                //ba[i].Opacity = 10;
                ba[i].Visibility = Visibility.Visible;
                //ba[i].Click = 
            }
            
        }
        private async void NotFound()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("The medicine is not available in any shop in the scope, pls try after some time!");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }
        private async void MessageBoxDisplay_Click()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("Connection error");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }

        private void Track_Click(object sender, RoutedEventArgs e)
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (!isConnected)
            {
                MessageBoxDisplay_Click();
                return;
            }
            else
            {
                ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
                if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
                {
                    isConnected = false;
                    MessageBoxDisplay_Click();
                    return;

                }
            }

            string medicine;
            medicine = med.Text;
            if (medicine == "")
            {
                NotEntered();
                return;
            }
            // Convert("NAresh#12.99#11.12");
            string urlstr = "http://sushrut.site88.net/map.php?search=" + medicine;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(urlstr));
            //HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(request);
            //var snk = request.GetResponseAsync();
            request.BeginGetResponse(ShowText, request);
            //ShowText(IAsyncResult );
            //Debug.WriteLine(snk);
            //b1.Content = snk;
            Debug.WriteLine(str);
            int si = 0;
            while (z != 1)
            {
                Debug.WriteLine("RUN");
                //si++;
                //if (si > 100) { MessageBoxDisplay_Click(); return; }
            }
            if (str == "incorrect")
            {
                Debug.WriteLine("fffffffffffffffffffffffffffffffffffffffffff");
                NotFound();
                //this.InitializeComponent();
            }
            else
            {
                avlb.Visibility = Visibility.Visible;
                //avlb1.Visibility = Visibility.Visible;
                sush();

            }
            

        }

        private async void NotEntered()
        {
            MessageDialog msgbox = new MessageDialog("Please enter a medicine name to search!!");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }



        public void ShowText(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);

            
                //HttpWebResponse response = null;
             
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {   
                string content = streamReader.ReadToEnd();
                Debug.WriteLine(content);
                // return content;
                //sush.Text = "sush";
                // b1.Content = content;
                str = content;
                //str = "sushrut#77#88#naresh#99#100#vinod#88#55#zzz#55#66#qqq#55#55#sss#66#66#eee#99#99";
                
                //Convert(str);
                z = 1;
                //return;
            }

            //sush("ss"); 
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e,string s)
        {   Debug.WriteLine(s);
        Button foo = sender as Button;
        Debug.WriteLine(foo.Content);
            Frame.Navigate(typeof(BlankPage1));
        }

        private void rb1_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine(s);
            Button foo = sender as Button;
            Debug.WriteLine(foo.Name);
            int i;
            for (i = 0; i < 10; i++)
            {
                if (foo == ba[i]) break;
            }
            String cord =snk[3*i+1] + "#" + snk[3*i+2];
            Debug.WriteLine(cord);
            Frame.Navigate(typeof(BlankPage1),cord);


            //Frame.Navigate(typeof(BlankPage1));
        }


    }
}
