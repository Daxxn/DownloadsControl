using DownloadsManager.Models.Settings.FilterSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Filters
{
   public interface IFilter
   {
      string Type { get; set; }
      string Description { get; set; }
      string Destination { get; set; }
      string[] Extensions { get; set; }
   }
}
