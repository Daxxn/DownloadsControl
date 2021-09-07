using DownloadsManager.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public interface IFilterSettingsModel : IService
   {
      Filter[] Filters { get; set; }
   }
}
