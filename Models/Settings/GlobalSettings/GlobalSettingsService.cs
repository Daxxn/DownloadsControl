﻿using DownloadsManager.Models.Logger;
using JsonReaderLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public class GlobalSettingsService : IGlobalSettingsService
   {
      #region - Fields & Properties
      public IGlobalSettings Settings { get; set; }
      #endregion

      #region - Constructors
      public GlobalSettingsService() => Settings = Injector.InjectService<IGlobalSettings, GlobalSettingsModel>();
      #endregion

      #region - Methods
      public void Start()
      {
         try
         {
            // ToDo: fix hard-coded path.
            Settings = JsonReader.OpenJsonFile<GlobalSettingsModel>(@"C:\Users\Cody\Desktop\DownloadsManager\GlobalSettings.json");
#if Mockup
            Settings.VerboseLogging = true;
            Settings.LogLevel = LogLevel.File;
#endif
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
