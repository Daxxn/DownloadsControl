using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadsManager.Models.Filters;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public class FilterSettingsModelMockup : IFilterSettingsModel
   {
      #region - Fields & Properties
      public Filter[] Filters { get; set; }
      #endregion

      #region - Constructors
      public FilterSettingsModelMockup()
      {
         Filters = new Filter[]
         {
            new Filter()
            {
               Type = "image-test",
               Description = "Test - Images, such as JPEG and PNG files.",
               Destination = "C:\\Users\\Cody\\Desktop\\DownloadsManager\\DestinationTest\\Images",
               Extensions = new string[]
               {
                  ".jpeg",
                  ".jpg",
                  ".jpe",
                  ".jfif",
                  ".png",
                  ".bmp",
                  ".dib",
                  ".gif",
                  ".tif",
                  ".tiff",
                  ".heic"
               }
            },
            new Filter()
            {
               Type = "executable-test",
               Description = "Test - Applications and installers",
               Destination = "C:\\Users\\Cody\\Desktop\\DownloadsManager\\DestinationTest\\executables",
               Extensions = new string[]
               {
                  ".exe",
                  ".msi"
               }
            }
         };
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
