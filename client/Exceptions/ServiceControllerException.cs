using System;

namespace DownloadsManagerClient.Exceptions
{
   public class ServiceControllerException : Exception
   {
      public int ErrorCode { get; }
      public ServiceControllerException() { }
      public ServiceControllerException(int errorCode) => ErrorCode = errorCode;
      public ServiceControllerException(string message) : base(message) { }
      public ServiceControllerException(string message, int errorCode) : base(message) => ErrorCode = errorCode;
      public ServiceControllerException(string message, int errorCode, Exception innerException) : base(message, innerException) => ErrorCode = errorCode;
   }
}
