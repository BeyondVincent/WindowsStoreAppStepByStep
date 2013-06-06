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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace BV_MessageDialog
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。Parameter
        /// 属性通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("你好，这里是Windows Store app学习之旅！");
            dialog.Title = "温馨提示";
            await dialog.ShowAsync();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("你好，欢迎访问移动技术开发社区：DevDiv.com");
            dialog.Title = "温馨提示";
            dialog.Commands.Add(new UICommand("DevDiv主页", command =>
            {
                //在这里做相关操作
                OpenDevDiv("http://www.DevDiv.com");
            }));
            dialog.Commands.Add(new UICommand("关闭", command =>
            {
                //在这里做相关操作
            }));
            await dialog.ShowAsync();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("你好，欢迎访问移动技术开发社区：DevDiv.com");
            dialog.Title = "温馨提示";
            dialog.Commands.Add(new UICommand("DevDiv主页", null, 0));
            dialog.Commands.Add(new UICommand("DevDiv论坛", null, 1));
            dialog.Commands.Add(new UICommand("关闭", null, 2));
            var command = await dialog.ShowAsync();
            if (Convert.ToInt32(command.Id) == 0)
            {
                OpenDevDiv("http://www.DevDiv.com");
            }
            else if (Convert.ToInt32(command.Id) == 0)
            {
                OpenDevDiv("http://www.devdiv.com/forum.php");
            }
            else
            {
                // do nothing
            }
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("你好，欢迎访问移动技术开发社区：DevDiv.com");
            dialog.Title = "温馨提示";
            dialog.Commands.Add(new UICommand("DevDiv主页", null, 0));
            dialog.Commands.Add(new UICommand("DevDiv论坛", null, 1));
            dialog.Commands.Add(new UICommand("关闭", null, 2));

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 2;

            var command = await dialog.ShowAsync();
            if (Convert.ToInt32(command.Id) == 0)
            {
                //OpenDevDiv("http://www.DevDiv.com");
            }
            else if (Convert.ToInt32(command.Id) == 1)
            {
                OpenDevDiv("http://www.devdiv.com/forum.php");
            }
            else
            {
                // do nothing
            }
        }

        private async void OpenDevDiv(string url)
        {
            // The URI to launch
            string uriToLaunch = url;

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
