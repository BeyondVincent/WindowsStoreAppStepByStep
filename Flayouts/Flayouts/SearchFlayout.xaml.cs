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

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace DevDiv_AppBar.Flayouts
{
    public sealed partial class SearchFlayout : UserControl
    {
        public SearchFlayout()
        {
            this.InitializeComponent();
        }

    public void Show(Page page, AppBar appbar, Button button)
    {
        SearchPopup.IsOpen = true;
        
        FlyoutHelper.ShowRelativeToAppBar(SearchPopup, page, appbar, button);
    }

    private void SearchButtonClick(object sender, RoutedEventArgs e) 
    {
        SearchPopup.IsOpen = false;
    }
    }
}
