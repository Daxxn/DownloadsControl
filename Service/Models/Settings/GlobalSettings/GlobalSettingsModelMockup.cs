using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadsManager.Models.Logger;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public class GlobalSettingsModelMockup : IGlobalSettings
   {
      #region - Fields & Properties
      public int TimerInterval { get; set; }
      public string FilterSettingsPath { get; set; }
      public string LogFilePath { get; set; }
      public LogLevel LogLevel { get; set; }
      public bool VerboseLogging { get; set; }
      #endregion

      #region - Constructors
      public GlobalSettingsModelMockup()
      {
         TimerInterval = 10;
         FilterSettingsPath = "";
         LogFilePath = "";
         LogLevel = LogLevel.Console;
         VerboseLogging = true;
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
