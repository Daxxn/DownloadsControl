using DownloadsManager.Models.Settings.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public interface IFilterSettingsService : IService
   {
      IFilterSettingsModel Settings { get; set; }
      void Start();
   }
}
