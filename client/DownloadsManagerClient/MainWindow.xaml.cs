using System.Windows;
using DownloadsManagerClient.ViewModels;

namespace DownloadsManagerClient
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         DataContext = new MainViewModel();
         InitializeComponent();
      }
   }
}
