using System.Collections.ObjectModel;
using MVVMLibrary;

namespace DownloadsManagerClient.Models.Filters
{
   public class Filter : Model
   {
      #region - Fields & Properties
      private string _type;
      private string _description;
      private string _destination;
      private ObservableCollection<ExtModel> _extensions = new();
      #endregion

      #region - Constructors
      public Filter() { }
      #endregion

      #region - Methods
      public void AddExtension(ExtModel ext)
      {
         if (!Extensions.Contains(ext))
         {
            Extensions.Add(ext);
         }
      }

      public void RemoveExtension(ExtModel ext)
      {
         if (Extensions is not null)
         {
            Extensions.Remove(ext);
         }
      }
      #endregion

      #region - Full Properties
      public string Type
      {
         get => _type;
         set
         {
            _type = value;
            OnPropertyChanged();
         }
      }
      public string Description
      {
         get => _description;
         set
         {
            _description = value;
            OnPropertyChanged();
         }
      }
      public string Destination
      {
         get => _destination;
         set
         {
            _destination = value;
            OnPropertyChanged();
         }
      }
      public ObservableCollection<ExtModel> Extensions
      {
         get => _extensions;
         set
         {
            _extensions = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
