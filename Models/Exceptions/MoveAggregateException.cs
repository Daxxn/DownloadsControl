using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Exceptions
{
   public class MoveAggregateException : Exception
   {
      public IEnumerable<Exception> ExceptionList { get; private set; }

      public MoveAggregateException(
         IEnumerable<Exception> exceptions
      ) => ExceptionList = exceptions;

      public MoveAggregateException(
         string message,
         IEnumerable<Exception> exceptions
      ) : base(message) => ExceptionList = exceptions;
   }
}
