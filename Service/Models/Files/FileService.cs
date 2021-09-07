using DownloadsManager.Models.Exceptions;
using DownloadsManager.Models.Filters;
using DownloadsManager.Models.Logger;
using DownloadsManager.Models.Settings.FilterSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Files
{
   public class FileService : IFileService
   {
      #region - Fields & Properties
      private IFilterSettingsService FilterSettingsService { get; }
      private ILoggerService LoggerService { get; }

      public List<IFileContainer> FileContainers { get; private set; }
      #endregion

      #region - Constructors
      public FileService()
      {
         FileContainers = new List<IFileContainer>();
         FilterSettingsService = Injector.InjectService<IFilterSettingsService, FilterSettingsService>();
         LoggerService = Injector.InjectService<ILoggerService, LoggerService>();
      }
      #endregion

      #region - Methods
      public void Run()
      {
         try
         {
            string[] AllFiles = Directory.GetFiles(
               Path.Combine(
                  Environment.GetFolderPath(
                     Environment.SpecialFolder.UserProfile
                  ),
                  "Downloads"
               )
            );

            foreach (var container in FileContainers)
            {
               foreach (var file in AllFiles)
               {
                  if (container.Filter.Extensions.Contains(Path.GetExtension(file)))
                  {
                     container.AddFile(file);
                  }
               }

               container.MoveFiles();
            }
         }
         catch (MoveAggregateException e)
         {
            foreach (var error in e.ExceptionList)
            {
               LoggerService.Error(error);
            }
         }
         catch (Exception e)
         {
            LoggerService.Error(e, "File Move Error");
         }
      }

      public void Start()
      {
         foreach (var filter in FilterSettingsService.Settings.Filters)
         {
            FileContainers.Add(new FileContainer(filter));
            LoggerService.Log("Filter Found", filter);
         }
      }

      public void Stop()
      {
         if (LoggerService.VerboseLogging)
         {
            LoggerService.Log("FileService Stopped");
         }
         FileContainers = null;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
