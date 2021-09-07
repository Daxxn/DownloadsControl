using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public class GlobalSettingsServiceMockup : IGlobalSettingsService
   {
      #region - Fields & Properties
      public IGlobalSettings Settings { get; set; }
      #endregion

      #region - Constructors
      public GlobalSettingsServiceMockup() => Settings = Injector.InjectService<IGlobalSettings, GlobalSettingsModelMockup>();
      #endregion

      #region - Methods
      public void Start() => Settings = new GlobalSettingsModelMockup();
      #endregion

      #region - Full Properties

      #endregion
   }
}
