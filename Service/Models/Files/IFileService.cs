using DownloadsManager.Models.Settings.FilterSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Files
{
   public interface IFileService
   {
      List<IFileContainer> FileContainers { get; }
      void Run();
      void Start();
      void Stop();
   }
}
