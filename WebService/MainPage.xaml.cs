using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BV_WebServiceDemo.WeatherWebService;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BV_WebServiceDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

private async void GoButton_Click(object sender, RoutedEventArgs e)
{
    ring.IsActive = true;
    WeatherWebServiceSoapClient proxy = new WeatherWebServiceSoapClient();
    //string[] result = await proxy.getSupportCityAsync(inputZipCode.Text);

    if (inputZipCode.Text.Length == 0)
    {
        inputZipCode.Text = "大理";
    }
    string[] result = await proxy.getWeatherbyCityNameAsync(inputZipCode.Text);
    if (result.Length > 0)
    {
        ring.IsActive = false;

        StringBuilder resultString = new StringBuilder(100);
        foreach (string temp in result)
        {
            resultString.AppendFormat("{0}\n", temp);
        }
        resultDetails.Text = resultString.ToString();
    }
}
    }
    public class image
    {
        public string imageurl
        {
            get;
            set;
        }
    }
}
