using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Logger
{
   public class ConsoleLogger : BaseLogger
   {
      #region - Fields & Properties

      #endregion

      #region - Constructors
      public ConsoleLogger() : base(LogLevel.Console) { }
      public ConsoleLogger(LogLevel level) : base(level) { }
      #endregion

      #region - Methods
      protected override void HandleMessage(string message) => Console.WriteLine(message);

      protected override void HandleStart() { }

      protected override void HandleStop() { }
      #endregion

      #region - Full Properties

      #endregion
   }
}
