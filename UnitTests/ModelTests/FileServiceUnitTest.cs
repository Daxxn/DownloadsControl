using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DownloadsManager.Models;
using DownloadsManager.Models.Files;
using DownloadsManager.Models.Settings.FilterSettings;
using DownloadsManager.Models.Settings.GlobalSettings;
using DownloadsManager.Models.Logger;

namespace UnitTests.ModelTests
{
   public class FileServiceUnitTest
   {
      private static ServiceController Controller { get; set; }

      [Fact(DisplayName = "Test DI Mockup")]
      public void TestMockupInjection()
      {
         Assert.True(BuildServiceController());
         Assert.NotNull(Controller);
      }

      [Fact(DisplayName = "Test Start Exceptions")]
      public void TestStartException()
      {
         Assert.True(BuildServiceController());
         var fileService = new FileService();
         Assert.Throws<NullReferenceException>(() => fileService.Start());
      }

      [Fact(DisplayName = "Test Start Functions")]
      public void TestStartFunction()
      {
         Assert.True(BuildServiceController());
         Func<bool> runStart = () =>
         {
            Controller.Start();
            return true;
         };
         Assert.True(runStart(), "Service.Start() Test Failed.");
      }

      [Fact(DisplayName = "Test FileService.Run Functions")]
      public void TestFileRunFunction()
      {
         Func<bool> runFunc = () =>
         {
            Controller.ElapsedTest();
            return true;
         };
         Assert.True(runFunc());
      }

      private bool BuildServiceController()
      {
         Controller = new ServiceController(
            Injector.InjectService<IGlobalSettingsService, GlobalSettingsServiceMockup>(),
            Injector.InjectService<IFilterSettingsService, FilterSettingsServiceMockup>(),
            Injector.InjectService<ILoggerService, LoggerServiceMockup>(),
            Injector.InjectService<IFileService, FileServiceMockup>()
         );
         return true;
      }
   }
}
