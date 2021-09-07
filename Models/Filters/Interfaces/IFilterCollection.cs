using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadsManager.Models.Filters
{
   public interface IFilterCollection : IService
   {
      IFilter[] Filters { get; set; }
   }
}
