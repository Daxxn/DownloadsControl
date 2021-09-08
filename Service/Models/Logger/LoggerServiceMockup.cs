using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadsManager.Models.Settings.GlobalSettings;

namespace DownloadsManager.Models.Logger
{
   public class LoggerServiceMockup : ILoggerService
   {
      #region - Fields & Properties
      private IGlobalSettingsService GlobalSettings { get;}
      public LogLevel CurrentLogLevel { get; set; }
      public bool VerboseLogging { get; set; }
      private BaseLogger Loggers { get; set; }
      #endregion

      #region - Constructors
      public LoggerServiceMockup() =>
         GlobalSettings =
            Injector.InjectService<IGlobalSettingsService, GlobalSettingsServiceMockup>();
      #endregion

      #region - Methods
      public void Error(Exception error, string message = null)
      {
         StringBuilder builder = new StringBuilder($"Error{(message != null ? $" | Msg: {message}" : "")}");
         if (VerboseLogging)
         {
            builder.Append($" | ErrorMsg: {error.Message}");
            builder.Append($" | Source: {error.Source}");
            builder.Append($" | Type: {error.GetType().Name}");
            builder.Append($" | Target: {error.TargetSite}");
            builder.Append($" | Trace: {error.StackTrace}");

            Loggers.Log(builder.ToString(), CurrentLogLevel);
         }
         else
         {
            builder.Append($" | {error.Message}");
            builder.Append($" | Source: {error.Source}");
            builder.Append($" | Type: {error.GetType().Name}");

            Loggers.Log(builder.ToString(), CurrentLogLevel);
         }
      }
      public void Log(string message) => Loggers.Log(message, CurrentLogLevel);
      public void Log(string message, object obj)
      {
         StringBuilder builder = new StringBuilder($"Log{(message != null ? $" | Msg: {message}" : "")}");
         builder.Append($" | {obj.GetType().Name}");
         if (VerboseLogging)
         {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
               builder.Append($" | {prop.Name} : {prop.GetValue(obj)}");
            }
         }
         Loggers.Log(builder.ToString(), CurrentLogLevel);
      }
      public void Start()
      {
         Loggers = new ConsoleLogger();
         CurrentLogLevel = GlobalSettings.Settings.LogLevel;
         VerboseLogging = GlobalSettings.Settings.VerboseLogging;
         Loggers.Start(GlobalSettings.Settings.LogFilePath, VerboseLogging);
      }
      public void Stop() => Loggers.Stop();
      #endregion
   }
}
