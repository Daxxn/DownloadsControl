using System;
using System.Collections.Generic;

namespace DownloadsManager.Models
{
   public static class Injector
   {
      #region - Fields & Properties
      public static Dictionary<Type, object> Dependencies { get; set; } = new Dictionary<Type, object>();
      #endregion

      #region - Methods
      public static Model InjectService<Interface, Model>() where Model : class, Interface, new()
      {
         if (!Dependencies.ContainsKey(typeof(Interface)))
         {
            Dependencies.Add(typeof(Interface), new Model());
         }
         return Dependencies[typeof(Interface)] as Model;
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
