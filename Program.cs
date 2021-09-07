using System;
using Topshelf;
using DownloadsManager.Models;
using DownloadsManager.Models.Settings.GlobalSettings;
using DownloadsManager.Models.Settings.FilterSettings;
using DownloadsManager.Models.Files;
using DownloadsManager.Models.Logger;

namespace DownloadsManager
{
   class Program
   {
      static void Main(string[] args)
      {
#if !SimplifiedTest
            var exitCode = HostFactory.Run(x =>
            {
               x.Service<IServiceController>(s =>
               {
                  s.ConstructUsing(service =>
                  {
                     return new ServiceController(
                        Injector.InjectService<IGlobalSettingsService, GlobalSettingsService>(),
                        Injector.InjectService<IFilterSettingsService, FilterSettingsService>(),
                        Injector.InjectService<ILoggerService, LoggerService>(),
#if Mockup
                        Injector.InjectService<IFileService, FileServiceMockup>()
#else
                        Injector.InjectService<IFileService, FileService>()
#endif
                        );
                  });

                  s.WhenStarted(service => service.Start());
                  s.WhenStopped(service => service.Stop());
               });

               x.RunAsLocalSystem();

               x.SetServiceName("DownloadsManager");
               x.SetDisplayName("Downloads Manager");
               x.SetDescription("Moves downloads from the downloads folder to the destination specified by a settings file.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
#else
            var serviceController = new ServiceController(
               Injector.InjectService<IGlobalSettingsService, GlobalSettingsService>(),
               Injector.InjectService<IFilterSettingsService, FilterSettingsService>(),
               Injector.InjectService<ILoggerService, LoggerService>(),
               Injector.InjectService<IFileService, FileService>()
               );

            serviceController.Start();

            serviceController.ElapsedTest();

            serviceController.Stop();
#endif
      }
   }
}
