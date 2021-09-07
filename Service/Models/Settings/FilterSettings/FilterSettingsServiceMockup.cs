using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadsManager.Models.Settings.GlobalSettings;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public class FilterSettingsServiceMockup : IFilterSettingsService
   {
      #region - Fields & Properties
      private IGlobalSettingsService GlobalSettings { get; }
      public IFilterSettingsModel Settings { get; set; }
      #endregion

      #region - Constructors
      public FilterSettingsServiceMockup()
      {
         GlobalSettings = Injector.InjectService<IGlobalSettingsService, GlobalSettingsServiceMockup>();
         Settings = Injector.InjectService<IFilterSettingsModel, FilterSettingsModelMockup>();
      }
      #endregion

      #region - Methods
      public void Start() => Settings = new FilterSettingsModelMockup();
      #endregion
   }
}
