using DownloadsManager.Models.Settings.FilterSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Filters
{
   public class Filter : IFilter
   {
      #region - Fields & Properties
      public string Type { get; set; }
      public string Description { get; set; }
      public string Destination { get; set; }
      public string[] Extensions { get; set; }
      #endregion

      #region - Constructors
      public Filter() { }
      #endregion

      #region - Methods
      #endregion

      #region - Full Properties

      #endregion
   }
}
