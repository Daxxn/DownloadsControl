using DownloadsManager.Models.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Files
{
   public interface IFileContainer
   {
      IFilter Filter { get; set; }
      List<FileInfo> Files { get; set; }
      void AddFile(string path);
      void MoveFiles();
   }
}
