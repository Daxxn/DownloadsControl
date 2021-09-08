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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DownloadsManagerClient.Templates
{
   /// <summary>
   /// Interaction logic for ContitionalControl.xaml
   /// </summary>
   public partial class ConditionalControl : UserControl
   {
      static ConditionalControl() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ConditionalControl), new FrameworkPropertyMetadata(typeof(ConditionalControl)));

      #region Condition DP

      public bool Condition
      {
         get => (bool)GetValue(ConditionProperty);
         set => SetValue(ConditionProperty, value);
      }

      public static readonly DependencyProperty ConditionProperty =
        DependencyProperty.Register("Condition", typeof (bool), typeof (ConditionalControl), new UIPropertyMetadata(false));

      #endregion

      #region TrueTemplate DP

      public DataTemplate TrueTemplate
      {
         get => (DataTemplate)GetValue(TrueTemplateProperty);
         set => SetValue(TrueTemplateProperty, value);
      }

      public static readonly DependencyProperty TrueTemplateProperty =
        DependencyProperty.Register("TrueTemplate", typeof (DataTemplate), typeof (ConditionalControl), new UIPropertyMetadata(null));

      #endregion

      #region FalseTemplate DP

      public DataTemplate FalseTemplate
      {
         get => (DataTemplate)GetValue(FalseTemplateProperty);
         set => SetValue(FalseTemplateProperty, value);
      }

      public static readonly DependencyProperty FalseTemplateProperty =
        DependencyProperty.Register("FalseTemplate", typeof (DataTemplate), typeof (ConditionalControl), new UIPropertyMetadata(null));

      #endregion
   }
}
