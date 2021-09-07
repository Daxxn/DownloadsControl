using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Logger
{
   public abstract class BaseLogger
   {
      #region - Fields & Properties
      protected BaseLogger NextLogger { get; set; }
      protected LogLevel Level { get; set; }
      protected string LogFilePath { get; set; }
      protected bool VerboseLogging { get; set; }
      #endregion

      #region - Constructors
      public BaseLogger(LogLevel level) => Level = level;
      #endregion

      #region - Methods
      protected abstract void HandleMessage(string message);
      protected abstract void HandleStart();
      protected abstract void HandleStop();

      public void Start(string logFilepath, bool verbose)
      {
         LogFilePath = logFilepath;
         VerboseLogging = verbose;
         HandleStart();
         if (NextLogger != null)
         {
            NextLogger.Start(logFilepath, verbose);
         }
      }

      public void Stop()
      {
         HandleStop();
         if (NextLogger != null)
         {
            NextLogger.Stop();
         }
      }

      public void Log(string message, LogLevel level)
      {
         if ((int)Level <= (int)level)
         {
            HandleMessage(message);
         }
         if (NextLogger != null)
         {
            NextLogger.Log(message, level);
         }
      }

      public void Log(string message, object obj, LogLevel level) => Log($"{message} : {obj}", level);

      public BaseLogger SetNext(BaseLogger next)
      {
         var thisLogger = this;
         while (thisLogger.NextLogger != null)
         {
            thisLogger = thisLogger.NextLogger;
         }
         thisLogger.NextLogger = next;
         return this;
      }
      #endregion
   }
}
