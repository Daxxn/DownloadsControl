using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using DownloadsManagerClient.Models.ErrorModels;
using MVVMLibrary;

namespace DownloadsManagerClient.ViewModels
{
   public class ErrorDialogViewModel : Model
   {
      #region - Fields & Properties
      private Exception _error;
      private StackTrace _stackTrace;
      private StackTrace _innerStackTrace;

      private string _typeName;
      private bool _isInnerError;
      private bool _sTParseFailure;
      private bool _innerSTParseFailure;
      #endregion

      #region - Constructors
      public ErrorDialogViewModel(Exception error)
      {
         Error = error;
         TypeName = error.GetType().Name;
         IsInnerError = error.InnerException is not null;
         try
         {
            StackTrace = new(error.StackTrace);
            STparseFailure = false;
         }
         catch (Exception)
         {
            STparseFailure = true;
         }
         if (IsInnerError)
         {
            try
            {
               InnerStackTrace = new(error.InnerException.StackTrace);
               InnerSTparseFailure = false;
            }
            catch (Exception)
            {
               InnerSTparseFailure = true;
            }
         }
      }
      #endregion

      #region - Methods
      #endregion

      #region - Full Properties
      public Exception Error
      {
         get => _error;
         set
         {
            _error = value;
            OnPropertyChanged();
         }
      }

      public StackTrace StackTrace
      {
         get => _stackTrace;
         set
         {
            _stackTrace = value;
            OnPropertyChanged();
         }
      }

      public StackTrace InnerStackTrace
      {
         get => _innerStackTrace;
         set
         {
            _innerStackTrace = value;
            OnPropertyChanged();
         }
      }

      public string TypeName
      {
         get => _typeName;
         set
         {
            _typeName = value;
            OnPropertyChanged();
         }
      }

      public bool IsInnerError
      {
         get => _isInnerError;
         set
         {
            _isInnerError = value;
            OnPropertyChanged();
         }
      }

      public bool STparseFailure
      {
         get => _sTParseFailure;
         set
         {
            _sTParseFailure = value;
            OnPropertyChanged();
         }
      }

      public bool InnerSTparseFailure
      {
         get => _innerSTParseFailure;
         set
         {
            _innerSTParseFailure = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
