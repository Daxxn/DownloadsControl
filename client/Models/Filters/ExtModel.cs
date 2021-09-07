using MVVMLibrary;

namespace DownloadsManagerClient.Models.Filters
{
   public class ExtModel : Model
   {
      #region - Fields & Properties
      private string _value;
      #endregion

      #region - Constructors
      public ExtModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties
      public string Value
      {
         get => _value;
         set
         {
            _value = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
