using System;
using System.Windows;
using DownloadsManagerClient.Templates;
using DownloadsManagerClient.ViewModels;

namespace DownloadsManagerClient
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private readonly MainViewModel _vm;
      public MainWindow()
      {
         _vm = new MainViewModel();
         DataContext = _vm;
         InitializeComponent();
         _vm.OpenErrorDialog += VM_OpenErrorDialog;
      }

      private void VM_OpenErrorDialog(object sender, Exception e) => new ErrorDialogTemplate(e).ShowDialog();

      private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
      {

      }
   }
}
