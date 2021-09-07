using DownloadsManager.Models.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public class GlobalSettingsModel : IGlobalSettings
   {
      #region - Fields & Properties
      public int TimerInterval { get; set; }
      public string FilterSettingsPath { get; set; }
      public string LogFilePath { get; set; }
      public LogLevel LogLevel { get; set; }
      public bool VerboseLogging { get; set; }
      #endregion

      #region - Constructors
      public GlobalSettingsModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
