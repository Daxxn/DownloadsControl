using DownloadsManager.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Settings.FilterSettings
{
   public class FilterSettingsModel : IFilterSettingsModel
   {
      #region - Fields & Properties
      public Filter[] Filters { get; set; }
      #endregion

      #region - Constructors
      public FilterSettingsModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
