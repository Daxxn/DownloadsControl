using System.Collections.ObjectModel;
using DownloadsManagerClient.Models.Filters;
using MVVMLibrary;

namespace DownloadsManagerClient.Models.Settings
{
   public class FilterSettingsModel : Model
   {
      #region - Fields & Properties
      private ObservableCollection<Filter> _filters = new();
      #endregion

      #region - Constructors
      public FilterSettingsModel()
      {
         Filters = new()
         {
            new()
            {
               Type = "Test A",
               Description = "Description A",
               Destination = "/Test/A/Test",
               Extensions = new()
               {
                  new() { Value = ".a" },
                  new() { Value = ".b" },
                  new() { Value = ".c" }
               }
            },
            new()
            {
               Type = "Test B",
               Description = "Description B",
               Destination = "/Test/B/Test",
               Extensions = new()
               {
                  new() { Value = ".1" },
                  new() { Value = ".2" },
                  new() { Value = ".3" }
               }
            }
         };
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties
      public ObservableCollection<Filter> Filters
      {
         get => _filters;
         set
         {
            _filters = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
