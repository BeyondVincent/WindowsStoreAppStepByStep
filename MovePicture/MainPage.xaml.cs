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

namespace BV_MovePicture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double x;
        double y;
        public MainPage()
        {
            this.InitializeComponent();

            x = translateTransform.X;
            y = translateTransform.Y;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Image_ManipulationStarted_1(object sender, ManipulationStartedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Image_ManipulationDelta_1(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            Image image = sender as Image;
                
            if (image.RenderTransform.Equals(translateTransform))
            {
                this.translateTransform.X += e.Delta.Translation.X;
                this.translateTransform.Y += e.Delta.Translation.Y;
            }
            else
            {
                this.translateTransform1.X += e.Delta.Translation.X;
                this.translateTransform1.Y += e.Delta.Translation.Y;
            }
        }

        private void Image_ManipulationCompleted_1(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            translateTransform.X = x;
            translateTransform.Y = y;
        }
    }
}
