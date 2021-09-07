using DownloadsManager.Models.Settings.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Logger
{
   public enum LogLevel
   {
      Console = 0,
      File = 1,
   };

   public class LoggerService : ILoggerService
   {
      #region - Fields & Properties
      private IGlobalSettingsService GlobalSettings { get; }
      public BaseLogger Loggers { get; set; }
      public LogLevel CurrentLogLevel { get; set; }
      public bool VerboseLogging { get; set; }
      #endregion

      #region - Constructors
      public LoggerService() => GlobalSettings =
         Injector.InjectService<IGlobalSettingsService, GlobalSettingsService>();
      #endregion

      #region - Methods
      public void Start()
      {
         Loggers = new ConsoleLogger()
            .SetNext(new FileLogger(GlobalSettings.Settings.LogFilePath));
         CurrentLogLevel = GlobalSettings.Settings.LogLevel;
         VerboseLogging = GlobalSettings.Settings.VerboseLogging;
         Loggers.Start(GlobalSettings.Settings.LogFilePath, VerboseLogging);
      }

      public void Stop() => Loggers.Stop();

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
#endregion

#region - Full Properties

#endregion
   }
}
