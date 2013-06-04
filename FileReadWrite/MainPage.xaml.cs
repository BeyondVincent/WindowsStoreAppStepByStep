using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BV_FileReadWrite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            // 不通过Picker读取本地文件
            LocalFileWithoutPicker();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public async void IsolatedStorage()
        {
            // settings
            var _Name = "MyFileName";
            var _Folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

            // create file 
            var _File = await _Folder.CreateFileAsync(_Name, _Option);

            // write content
            var _WriteThis = "Hello world!";
            await Windows.Storage.FileIO.WriteTextAsync(_File, _WriteThis);

            // acquire file
            _File = await _Folder.GetFileAsync(_Name);

            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
        }

        private async void ProjectFile()
        {
            // settings
            var _Path = @"MyFolder\MyFile.txt";
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            // acquire file
            var _File = await _Folder.GetFileAsync(_Path);

            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
        }

        async void LocalFileFromPicker()
        {
            // define picker
            var _Picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            _Picker.FileTypeFilter.Add(".txt");

            // let user pick file
            var _File = await _Picker.PickSingleFileAsync();
            if (_File == null)
            {
                await new Windows.UI.Popups.MessageDialog("No file").ShowAsync();
                return;
            }

            // read properties
            var _Message = string.Format("File date: {0}",
                (await _File.GetBasicPropertiesAsync()).DateModified);
            await new Windows.UI.Popups.MessageDialog(_Message).ShowAsync();

            // read content
            var _Content = await Windows.Storage.FileIO.ReadTextAsync(_File);
            await new Windows.UI.Popups.MessageDialog(_Content).ShowAsync();
        }

        async void LocalFileWithoutPicker()
        {
            var _Name = "HelloWorld.txt";
            var _Folder = KnownFolders.DocumentsLibrary;
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

            // create file 
            var _File = await _Folder.CreateFileAsync(_Name, _Option);

            // write content
            var _WriteThis = "Hello world!";
            await Windows.Storage.FileIO.WriteTextAsync(_File, _WriteThis);

            // acquire file
            try { _File = await _Folder.GetFileAsync(_Name); }
            catch (FileNotFoundException) { /* TODO */ }

            // read content
            var _Content = await FileIO.ReadTextAsync(_File);
            await new Windows.UI.Popups.MessageDialog(_Content).ShowAsync();

            await _File.DeleteAsync();
        }
    }
}
