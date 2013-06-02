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
using DevDiv_DataBinding.Data;
using Windows.ApplicationModel.Search;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DevDiv_DataBinding.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPage : Page
    {
        ViewModel viewModel;
        public ListPage()
        {
            this.InitializeComponent();

            SearchPane.GetForCurrentView().SuggestionsRequested += searchPane_SuggestionsRequested;
        }

        void searchPane_SuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            foreach (ForumItem forumItem in viewModel.ForumItemList)
            {
                string suggestion = forumItem.Name;

                if (suggestion.StartsWith(args.QueryText, StringComparison.CurrentCultureIgnoreCase))
                {
                    args.Request.SearchSuggestionCollection.AppendQuerySuggestion(suggestion);
                }
                if (args.Request.SearchSuggestionCollection.Size >= 5)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = (ViewModel)e.Parameter;

            viewModel.SelectedItemIndex = -1;
            viewModel.ForumItemList.Add(new ForumItem
            {
                Name = "Android开发论坛",
                TopicCount = 4,
                Link = "http://www.devdiv.com/forum-110-1.html",
                Info = "Android开发论坛、Android开发者论坛、环境搭建、应用开发、驱动开发、系统移植、文档"
            });
            viewModel.ForumItemList.Add(new ForumItem { Name = "Android开发资料", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            viewModel.ForumItemList.Add(new ForumItem { Name = "iOS开发论坛/iPhone开发论坛", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            viewModel.ForumItemList.Add(new ForumItem { Name = "iOS开发资料/iPhone开发资料", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            viewModel.ForumItemList.Add(new ForumItem { Name = "微软/诺基亚 Windows Phone开发论坛 ", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            viewModel.ForumItemList.Add(new ForumItem { Name = "Windows Phone开发资料", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            viewModel.ForumItemList.Add(new ForumItem
            {
                Name = "Windows 8 开发论坛 ",
                TopicCount = 8,
                Link = "http://www.devdiv.com/forum-102-1.html",
                Info = "Windows 8 代码、教程、入门、文档、视频"
            });
            viewModel.ForumItemList.Add(new ForumItem { Name = "Symbian开发论坛", TopicCount = 8, Link = "http://www.devdiv.com/forum-102-1.html" });
            this.DataContext = viewModel;

            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectedItemIndex")
                {
                    ForumList.SelectedIndex = viewModel.SelectedItemIndex;
                }
            };
        }

        private void ListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ItemDetail = ((ForumItem)e.AddedItems[0]).Info;
            if (viewModel.ItemDetail == null || viewModel.ItemDetail.Length == 0)
            {
                viewModel.ItemDetail = ((ForumItem)e.AddedItems[0]).Name;
            }
        }
    }
}
