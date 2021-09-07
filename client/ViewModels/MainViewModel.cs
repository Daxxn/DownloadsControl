using DownloadsManagerClient.Models.Settings;
using MVVMLibrary;

namespace DownloadsManagerClient.ViewModels
{
   public class MainViewModel : Model
   {
      #region - Fields & Properties
      private GlobalSettingsModel _globalSettings;
      private FilterSettingsModel _filterSettings;

      private bool _filtersOnlyMode;
      #region - Commands

      #endregion
      #endregion

      #region - Constructors
      public MainViewModel()
      {
         GlobalSettings = new();
         FilterSettings = new();
      }
      #endregion

      #region - Methods

      #region - Command Methods

      #endregion
      #endregion

      #region - Full Properties
      public GlobalSettingsModel GlobalSettings
      {
         get => _globalSettings;
         set
         {
            _globalSettings = value;
            OnPropertyChanged();
         }
      }

      public FilterSettingsModel FilterSettings
      {
         get => _filterSettings;
         set
         {
            _filterSettings = value;
            OnPropertyChanged();
         }
      }

      public bool FiltersOnlyMode
      {
         get { return _filtersOnlyMode; }
         set
         {
            _filtersOnlyMode = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
