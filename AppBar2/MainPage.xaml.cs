using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BV_AppBar
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

        private async void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;

            PopupMenu menu = new PopupMenu();
            menu.Commands.Add(new UICommand("姓名", FilterButton_Click, "name"));
            menu.Commands.Add(new UICommand("日期", FilterButton_Click, "date"));

            var clicked = await menu.ShowForSelectionAsync(element.GetElementRect(0, -10), Placement.Above);
        }

private void FilterButton_Click(IUICommand command)
{
    appBar.IsOpen = false;
}

    }

    public static class Positioning
    {
        public static Rect GetElementRect(this FrameworkElement element, int hOffset, int vOffset)
        {
            Rect rect = Positioning.GetElementRect(element);
            rect.Y += vOffset;
            rect.X += hOffset;
            return rect;
        }

        public static Rect GetElementRect(this FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }
    }
}
