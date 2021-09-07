using DownloadsManager.Models.Files;
using DownloadsManager.Models.Logger;
using DownloadsManager.Models.Settings.FilterSettings;
using DownloadsManager.Models.Settings.GlobalSettings;
using System;
using System.Timers;

namespace DownloadsManager.Models
{
   class ServiceController : IServiceController
   {
      #region - Fields & Properties
      private IGlobalSettingsService GlobalSettingsService { get; }
      private IFilterSettingsService FilterSettingsService { get; }
      private ILoggerService LoggerService { get; }
      private IFileService FileService { get; }
      private Timer Timer { get; set; }
      private bool IsRunning { get; set; }
      #endregion

      #region - Constructors
      public ServiceController(
         IGlobalSettingsService globalSettingsService,
         IFilterSettingsService filterSettingsService,
         ILoggerService loggerService,
         IFileService fileService
      )
      {
         GlobalSettingsService = globalSettingsService;
         FilterSettingsService = filterSettingsService;
         LoggerService = loggerService;
         FileService = fileService;
      }
      #endregion

      #region - Methods
      private void Elapsed(object sender, ElapsedEventArgs e)
      {
         if (!IsRunning)
         {
            IsRunning = true;
            FilterSettingsService.Start();
            FileService.Run();
            IsRunning = false;
         }
      }

      public void ElapsedTest()
      {
         if (!IsRunning)
         {
            IsRunning = true;
            FilterSettingsService.Start();
            FileService.Run();
            IsRunning = false;
         }
      }

      public void Start()
      {
         try
         {
            GlobalSettingsService.Start();
            FilterSettingsService.Start();
            LoggerService.Start();
            FileService.Start();
            LoggerService.Log("Settings Load Successful");

            Timer = new Timer
            {
               Interval = 1000 * GlobalSettingsService.Settings.TimerInterval,
               AutoReset = true,
               Enabled = true,
            };
            Timer.Elapsed += Elapsed;
            Timer.Start();
            LoggerService.Log("Startup Successful");
         }
         catch (Exception)
         {
            throw;
         }
      }

      public void Stop()
      {
         Timer.Stop();
         LoggerService.Log("Shutdown Successful");
         LoggerService.Stop();
         FileService.Stop();
         // probably not a good idea...
         Timer = null;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
