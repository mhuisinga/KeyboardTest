using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KeyboardTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            DataContext = new ViewModelOrders();
            ViewModel.Defaults();

            //Loaded += (sender, e) =>
            //{
            //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
            //};

            //Unloaded += (sender, e) =>
            //{
            //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated -= Dispatcher_AcceleratorKeyActivated;
            //};
        }

        private async void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        {
            await HandleKey(sender, args);
        }

        private async Task HandleKey(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        {
                if (args.EventType != CoreAcceleratorKeyEventType.KeyDown) return;
                if (args.Handled) return;

                // Standard controls
                //if ((args.VirtualKey == Windows.System.VirtualKey.Tab || args.VirtualKey == Windows.System.VirtualKey.Enter) && (FocusManager.GetFocusedElement() == txtPrijs))
                //{
                //    args.Handled = true;
                //    await AddOrderline();
                //}
                //else if (args.VirtualKey == Windows.System.VirtualKey.Tab || args.VirtualKey == Windows.System.VirtualKey.Enter)
                //{
                //    args.Handled = true;
                //    FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                //}

        }

        private async Task AddOrderline()
        {
            await Task.Delay(0);

            ViewModel.AddLine();
            ViewModel.Defaults();

            txtArtikelcode.Focus(FocusState.Programmatic);
        }

        private void TextboxSelectAll(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearLines();
        }

        ViewModelOrders ViewModel
        {
            get { return DataContext as ViewModelOrders; }
        }
    }
}
