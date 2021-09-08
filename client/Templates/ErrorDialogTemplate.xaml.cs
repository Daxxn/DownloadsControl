using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DownloadsManagerClient.ViewModels;

namespace DownloadsManagerClient.Templates
{
   /// <summary>
   /// Interaction logic for ErrorDialogTemplate.xaml
   /// </summary>
   public partial class ErrorDialogTemplate : Window
   {
      public ErrorDialogTemplate(Exception error)
      {
         DataContext = new ErrorDialogViewModel(error);
         InitializeComponent();
      }
   }
}
