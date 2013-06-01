using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DevDiv_AppNavBar.Pages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DevDiv_AppNavBar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MainFrame.Navigate(typeof(BlankPage1));
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void NavBarButtonPress(object sender, RoutedEventArgs e)
        {
            Boolean isBlankPage1 = (Button)sender == btBlankPage1;

            btBlankPage1.IsEnabled = !isBlankPage1;
            btBlankPage2.IsEnabled = isBlankPage1;

            if (isBlankPage1)
            {
                MainFrame.Navigate(typeof(BlankPage1));
            }
            else
            {
                MainFrame.Navigate(typeof(BlankPage2));
            }
        }
    }
}
