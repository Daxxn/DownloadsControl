using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManagerClient.Exceptions
{
   public class ServiceManagerException : Exception
   {
      public ServiceManagerException() { }
      public ServiceManagerException(string message) : base(message) { }
      public ServiceManagerException(string message, Exception innerException) : base(message, innerException) { }
   }
}
