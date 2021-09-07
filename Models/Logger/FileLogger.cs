using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Logger
{
   public class FileLogger : BaseLogger
   {
      #region - Fields & Properties
      private StreamWriter Writer { get; set; }
      #endregion

      #region - Constructors
      public FileLogger(string logFilePath) : base(LogLevel.File) => LogFilePath = logFilePath;
      public FileLogger(string logFilePath, LogLevel level) : base(level) => LogFilePath = logFilePath;
      #endregion

      #region - Methods
      protected override void HandleMessage(string message)
      {
         if (message.Length > 0 && Writer != null)
         {
            Writer.WriteLine(message);
            Writer.Flush();
         }
      }

      protected override void HandleStart()
      {
         try
         {
            Writer = new StreamWriter(LogFilePath, true);
         }
         catch (Exception)
         {
            throw;
         }
      }

      protected override void HandleStop()
      {
         try
         {
            if (Writer != null)
            {
               Writer.Flush();
               Writer.Close();
               Writer = null;
            }
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
