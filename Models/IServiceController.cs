using DownloadsManager.Models.Files;
using DownloadsManager.Models.Filters;
using DownloadsManager.Models.Settings.FilterSettings;
using DownloadsManager.Models.Settings.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models
{
   public interface IServiceController
   {
      void Start();
      void Stop();
   }
}
