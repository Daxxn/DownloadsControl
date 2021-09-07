using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.GlobalSettings
{
   public interface IGlobalSettingsService : IService
   {
      IGlobalSettings Settings { get; set; }
      void Start();
   }
}
