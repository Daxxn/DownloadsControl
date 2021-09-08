using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManagerClient.Exceptions
{
   [DebuggerDisplay("PathFinderException : " + nameof(GetDebuggerDisplay))]
   public class PathFinderException : Exception
   {
      public string PathResult { get; }
      public PathFinderException() { }
      public PathFinderException(string message, string pathResult) : base(message) => PathResult = pathResult;
      public PathFinderException(string message, Exception innerException) : base(message, innerException) { }
      public PathFinderException(string message, string pathResult, Exception innerException) : base(message, innerException) => PathResult = pathResult;

      private string GetDebuggerDisplay() => $"PathFinderException : {HResult}{(InnerException is null ? "" : $" : {InnerException}")}";
   }
}
