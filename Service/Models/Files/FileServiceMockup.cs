using DownloadsManager.Models.Exceptions;
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
   public class FileServiceMockup : IFileService
   {
      #region - Fields & Properties
      private IFilterSettingsService FilterSettingsService { get; }
      private ILoggerService LoggerService { get; }

      public List<IFileContainer> FileContainers { get; private set; }
      #endregion

      #region - Constructors
      public FileServiceMockup()
      {
         FileContainers = new List<IFileContainer>();
         FilterSettingsService = Injector.InjectService<IFilterSettingsService, FilterSettingsServiceMockup>();
         LoggerService = Injector.InjectService<ILoggerService, LoggerServiceMockup>();
      }
      #endregion

      #region - Methods
      public void Run()
      {
         try
         {
            LoggerService.Log("Starting File Search");
            string[] AllFiles = Directory.GetFiles(
               Path.Combine(
                  Environment.GetFolderPath(
                     Environment.SpecialFolder.UserProfile
                  ),
                  "Downloads"
               )
            );

            LoggerService.Log("File Search Complete", new { FileCount = AllFiles.Length });

            foreach (var container in FileContainers)
            {
               foreach (var file in AllFiles)
               {
                  if (container.Filter.Extensions.Contains(Path.GetExtension(file)))
                  {
                     container.AddFile(file);
                  }
               }

               LoggerService.Log("Move File Mockup", new { Filter = container.Filter.Type, FileCount = container.Files.Count });
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
   }
}
