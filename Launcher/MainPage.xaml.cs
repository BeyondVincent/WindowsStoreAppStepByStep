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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BV_Launcher
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



        private async void DefaultLaunch(object sender, RoutedEventArgs e)
        {
            // Path to the file in the app package to launch
            string imageFile = @"data\[DevDiv翻译]Metro Revealed_ Building Windows 8 apps with XAML and C#中文翻译合集_2012_09_03.pdf";

            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            if (file != null)
            {
                // Launch the retrieved file
                var success = await Windows.System.Launcher.LaunchFileAsync(file);

                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }


        private async void DisplayApplicationPicker(object sender, RoutedEventArgs e)
        {
            // Path to the file in the app package to launch
            string imageFile = @"data\7.jpg";

            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            if (file != null)
            {
                // Set the option to show the picker
                var options = new Windows.System.LauncherOptions();
                options.DisplayApplicationPicker = true;

                // Launch the retrieved file
                bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }

        private async void RecommendedApp(object sender, RoutedEventArgs e)
        {
            // Path to the file in the app package to launch
            string imageFile = @"data\1.BeyondVincent";

            // Get the image file from the package's image directory
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);

            if (file != null)
            {
                // Set the recommended app
                var options = new Windows.System.LauncherOptions();

                // 设置为应用商店中要推荐的应用的程序包系列名称
                options.PreferredApplicationPackageFamilyName = "BeyondVincent格式文件程序";

                // 设置为该应用的名称
                options.PreferredApplicationDisplayName = "BV_Launcher";


                // Launch the retrieved file pass in the recommended app 
                // in case the user has no apps installed to handle the file
                bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    // File launched
                }
                else
                {
                    // File launch failed
                }
            }
            else
            {
                // Could not find file
            }
        }

        private async void OpenDevDiv(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            string uriToLaunch = @"http://www.DevDiv.com";

            // Create a Uri object from a URI string 
            var uri = new Uri(uriToLaunch);

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }
    }
}
