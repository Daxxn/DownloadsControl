using System.ComponentModel;
using DownloadsManagerClient.TypeConverters;

namespace DownloadsManagerClient.Models
{
   [TypeConverter(typeof(EnumDescriptionConverter))]
   public enum LogLevel
   {
      [Description("Client Only Logging")]
      Client,
      [Description("File Logging")]
      File,
   };
}
