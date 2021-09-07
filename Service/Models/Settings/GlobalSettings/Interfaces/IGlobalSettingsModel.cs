using DownloadsManager.Models.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public interface IGlobalSettings
   {
      int TimerInterval { get; set; }
      string FilterSettingsPath { get; set; }
      string LogFilePath { get; set; }
      LogLevel LogLevel { get; set; }
      bool VerboseLogging { get; set; }
   }
}
