using DownloadsManager.Models.Settings.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Logger
{
   public interface ILoggerService : IService
   {
      LogLevel CurrentLogLevel { get; set; }
      bool VerboseLogging { get; set; }
      void Log(string message);
      void Log(string message, object obj);
      void Error(Exception error, string message = null);
      void Start();
      void Stop();
   }
}
