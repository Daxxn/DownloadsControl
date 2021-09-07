using System.Diagnostics;
using MVVMLibrary;

namespace DownloadsManagerClient.Models.Settings
{
   [DebuggerDisplay(nameof(GetDebuggerDisplay))]
   public class GlobalSettingsModel : Model
   {
      #region - Fields & Properties
      private int _timerInterval;
      private string _filterSettingsPath;
      private string _logFilepath;
      private LogLevel _logLevel;
      private bool _verboseLogging;
      #endregion

      #region - Constructors
      public GlobalSettingsModel() { }
      #endregion

      #region - Methods
      private static string GetDebuggerDisplay() => ":Global Settings Model:";
      #endregion

      #region - Full Properties
      public int TimerInterval
      {
         get => _timerInterval;
         set
         {
            _timerInterval = value;
            OnPropertyChanged();
         }
      }
      public string FilterSettingsPath
      {
         get => _filterSettingsPath;
         set
         {
            _filterSettingsPath = value;
            OnPropertyChanged();
         }
      }
      public string LogFilepath
      {
         get => _logFilepath;
         set
         {
            _logFilepath = value;
            OnPropertyChanged();
         }
      }
      public LogLevel LogLevel
      {
         get => _logLevel;
         set
         {
            _logLevel = value;
            OnPropertyChanged();
         }
      }
      public bool VerboseLogging
      {
         get => _verboseLogging;
         set
         {
            _verboseLogging = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
