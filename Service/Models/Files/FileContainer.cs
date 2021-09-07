using DownloadsManager.Models.Exceptions;
using DownloadsManager.Models.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Files
{
   public class FileContainer : IFileContainer
   {
      #region - Fields & Properties
      public IFilter Filter { get; set; }
      public List<FileInfo> Files { get; set; }
      #endregion

      #region - Constructors
      public FileContainer(IFilter filter)
      {
         Filter = filter;
         Files = new List<FileInfo>();
      }
      #endregion

      #region - Methods
      public void AddFile(string path)
      {
         try
         {
            Files.Add(new FileInfo(path));
         }
         catch (Exception)
         {
            throw;
         }
      }

      public void MoveFiles()
      {
         try
         {
            if (Files.Count > 0)
            {
               var errors = new List<Exception>();
               foreach (var file in Files)
               {
                  try
                  {
                     file.MoveTo(Path.Combine(Filter.Destination, file.Name));
                  }
                  catch (Exception e)
                  {
                     errors.Add(e);
                  }
               }

               if (errors.Count > 0)
               {
                  throw new MoveAggregateException(errors);
               }
            }
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion
   }
}
