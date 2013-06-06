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
using NotificationsExtensions;
using NotificationsExtensions.ToastContent;
using Windows.UI.Notifications;
using NotificationsExtensions.BadgeContent;
using NotificationsExtensions.TileContent;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DevDiv_Notifications
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
            //switch (App.args.Kind)
            //{
            //    case Windows.ApplicationModel.Activation.ActivationKind.
            //}
            textbolck.Text = App.args.Kind.ToString() + App.args.Arguments;
        }

        private void sendToast(object sender, RoutedEventArgs e)
        {
            IToastImageAndText01 toastContent = ToastContentFactory.CreateToastImageAndText01();
            toastContent.Launch = "this is launch string test";
            toastContent.TextBodyWrap.Text = "破船，恭喜你，中500W！";
            toastContent.Image.Src = "/Assets/98_avatar_big.jpg";

            ToastNotificationManager.CreateToastNotifier().Show(toastContent.CreateNotification());
        }


        void ClearBadge()
        {
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
        }

        void UpdateBadgeWithNumber(int number)
        {
            BadgeNumericNotificationContent badgeContent = new BadgeNumericNotificationContent((uint)number);

            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeContent.CreateNotification());
        }

        void UpdateBadgeWithGlyph(GlyphValue index)
        {
            BadgeGlyphNotificationContent badgeContent = new BadgeGlyphNotificationContent(index);

            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeContent.CreateNotification());
        }

        private void SendBadgeNumber(object sender, RoutedEventArgs e)
        {
            UpdateBadgeWithNumber(12);
        }

        private void SendBadgeGlyph(object sender, RoutedEventArgs e)
        {
            UpdateBadgeWithGlyph(GlyphValue.Playing);
        }

        private void ClearBadge(object sender, RoutedEventArgs e)
        {
            ClearBadge();
        }


        private void UpdateTileWithText()
        {
            ITileWideText03 tileContent = TileContentFactory.CreateTileWideText03();
            tileContent.TextHeadingWrap.Text = "你有三条未读短信！";

            ITileSquareText04 squareContent = TileContentFactory.CreateTileSquareText04();
            squareContent.TextBodyWrap.Text = "你有三条未读短信！";
            tileContent.SquareContent = squareContent;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

        private void SendTileText(object sender, RoutedEventArgs e)
        {
            UpdateTileWithText();
        }

        private void ClearTile(object sender, RoutedEventArgs e)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
        }

        void UpdateTileWithWebImage()
        {
            ITileWideImageAndText01 tileContent = TileContentFactory.CreateTileWideImageAndText01();

            tileContent.TextCaptionWrap.Text = "高清：撑杆跳伊辛巴耶娃4米70无缘奥运三连冠";

            tileContent.Image.Src = "http://img1.gtimg.com/4/460/46005/4600509_980x1200_292.jpg";
            tileContent.Image.Alt = "Web image";

            ITileSquareImage squareContent = TileContentFactory.CreateTileSquareImage();

            squareContent.Image.Src = "http://img1.gtimg.com/4/460/46005/4600509_980x1200_292.jpg";
            squareContent.Image.Alt = "Web image";

            tileContent.SquareContent = squareContent;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

        private void SendTilePic(object sender, RoutedEventArgs e)
        {
            UpdateTileWithWebImage();
        }
    }
}
