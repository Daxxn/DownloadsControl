using DownloadsManager.Models.Settings.GlobalSettings;
using JsonReaderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public class FilterSettingsService : IFilterSettingsService
   {
      #region - Fields & Properties
      private IGlobalSettingsService GlobalSettings { get; }
      public IFilterSettingsModel Settings { get; set; }
      #endregion

      #region - Constructors
      public FilterSettingsService()
      {
         GlobalSettings = Injector.InjectService<IGlobalSettingsService, GlobalSettingsService>();
         Settings = Injector.InjectService<IFilterSettingsModel, FilterSettingsModel>();
      }
      #endregion

      #region - Methods
      public void Start()
      {
         try
         {
            Settings = JsonReader.OpenJsonFile<FilterSettingsModel>(GlobalSettings.Settings.FilterSettingsPath);
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
