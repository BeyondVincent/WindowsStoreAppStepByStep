using BV_MyGridApp.Data;

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

// “分组项页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234231 上提供

namespace BV_MyGridApp
{
    /// <summary>
    /// 显示分组的项集合的页。
    /// </summary>
    public sealed partial class GroupedItemsPage : BV_MyGridApp.Common.LayoutAwarePage
    {
        public GroupedItemsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            this.DefaultViewModel["Groups"] = sampleDataGroups;
        }

        /// <summary>
        /// 在单击组标题时进行调用。
        /// </summary>
        /// <param name="sender">用作选定组的组标题的 Button。</param>
        /// <param name="e">描述如何启动单击的事件数据。</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // 确定 Button 实例表示的组
            var group = (sender as FrameworkElement).DataContext;

            // 导航至相应的目标页，并
            // 通过将所需信息作为导航参数传入来配置新页
            this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// 在单击组内的项时进行调用。
        /// </summary>
        /// <param name="sender">显示所单击项的 GridView (在应用程序处于对齐状态时
        /// 为 ListView)。</param>
        /// <param name="e">描述所单击项的事件数据。</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 导航至相应的目标页，并
            // 通过将所需信息作为导航参数传入来配置新页
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }
    }
}
