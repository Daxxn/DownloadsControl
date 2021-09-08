using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLibrary;

namespace DownloadsManagerClient.Models.ErrorModels
{
   public class StackTrace : Model
   {
      #region - Fields & Properties
      private ObservableCollection<StackTraceItem> _traceList;
      #endregion

      #region - Constructors
      public StackTrace(string stackTrace) => ParseStackTrace(stackTrace);
      #endregion

      #region - Methods
      public void ParseStackTrace(string stackTrace)
      {
         try
         {
            TraceList = new();
            if (!String.IsNullOrWhiteSpace(stackTrace))
            {
               string[] traces = stackTrace.Split(new string[] { " at " }, StringSplitOptions.RemoveEmptyEntries);

               if (traces.Length > 0)
               {
                  foreach (string trace in traces)
                  {
                     var st = StackTraceItem.ParseStackTrace(trace);
                     if (st is not null)
                     {
                        TraceList.Add(st);
                     }
                  }
                  if (TraceList.Count == 0)
                  {
                     throw new Exception("Parse Failure. All traces are null");
                  }
                  return;
               }
               throw new Exception("Parse Failure. Unable to parse Stack Trace");
            }
            throw new Exception("Parse Failure. Unable to parse Stack Trace");
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion

      #region - Full Properties
      public ObservableCollection<StackTraceItem> TraceList
      {
         get => _traceList;
         set
         {
            _traceList = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
