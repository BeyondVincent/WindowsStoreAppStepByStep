using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace SimplePad2
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Loaded += (sender, args) =>
            {
                txtbox.Focus(FocusState.Keyboard);
            };
        }

        void OnWrapOptionsAppBarButtonClick(object sender, RoutedEventArgs args)
        {
            // Create dialog
            WrapOptionsDialog wrapOptionsDialog = new WrapOptionsDialog
            {
                TextWrapping = txtbox.TextWrapping
            };

            // Bind dialog to TextBox
            Binding binding = new Binding
            {
                Source = wrapOptionsDialog,
                Path = new PropertyPath("TextWrapping"),
                Mode = BindingMode.TwoWay
            };
            txtbox.SetBinding(TextBox.TextWrappingProperty, binding);

            // Create popup
            Popup popup = new Popup
            {
                Child = wrapOptionsDialog,
                IsLightDismissEnabled = true
            };

            // Adjust location based on content size
            wrapOptionsDialog.SizeChanged += (dialogSender, dialogArgs) =>
            {
                popup.VerticalOffset = this.ActualHeight - wrapOptionsDialog.ActualHeight
                                                         - this.BottomAppBar.ActualHeight - 48;
                popup.HorizontalOffset = 48;
            };

            // Open the popup
            popup.IsOpen = true;
        }

        async void OnOpenAppBarButtonClick(object sender, RoutedEventArgs args)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");

            // Asynchronous call!
            StorageFile storageFile = await picker.PickSingleFileAsync();

            if (storageFile == null)
                return;

            // Asynchronous call!
            txtbox.Text = await FileIO.ReadTextAsync(storageFile);
        }

        async void OnSaveAsAppBarButtonClick(object sender, RoutedEventArgs args)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.DefaultFileExtension = ".txt";
            picker.FileTypeChoices.Add("Text", new List<string> { ".txt" });

            // Asynchronous call!
            StorageFile storageFile = await picker.PickSaveFileAsync();

            if (storageFile == null)
                return;

            // Asynchronous call!
            await FileIO.WriteTextAsync(storageFile, txtbox.Text);
        }
    }

}
