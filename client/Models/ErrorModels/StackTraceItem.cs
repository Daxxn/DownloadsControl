using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLibrary;

namespace DownloadsManagerClient.Models.ErrorModels
{
   public class StackTraceItem : Model
   {
      #region - Fields & Properties
      private string _line;
      private string _objectName;
      private string _objectPath;
      private string _lineNumber;
      #endregion

      #region - Constructors
      public StackTraceItem(string trace) => Line = trace;
      #endregion

      #region - Methods
      public static StackTraceItem ParseStackTrace(string input)
      {
         try
         {
            if (!String.IsNullOrWhiteSpace(input))
            {
               var newItem = new StackTraceItem(input);
               string[] vars = input.Split(new string[] { ":line " }, StringSplitOptions.RemoveEmptyEntries);

               if (vars.Length == 2)
               {
                  newItem.LineNumber = vars[1];
                  newItem.LineNumber = newItem.LineNumber.Trim();
                  newItem.Line = vars[0];
                  ParseLine(newItem);
               }
               else if (vars.Length == 1)
               {
                  newItem.Line = vars[0];
                  newItem.LineNumber = "N/A";
                  ParseLine(newItem);
               }
               else
               {
                  return null;
               }
               return newItem;
            }
            return null;
         }
         catch (Exception)
         {
            throw;
         }
      }

      private static void ParseLine(StackTraceItem item)
      {
         try
         {
            string[] lineSplit = item.Line.Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);

            if (lineSplit.Length == 2)
            {
               item.ObjectName = lineSplit[0].Trim();
               item.ObjectPath = lineSplit[1].Trim();
            }
            else if (lineSplit.Length == 1)
            {
               item.ObjectName = lineSplit[0].Trim();
               item.ObjectPath = "N/A";
            }
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion

      #region - Full Properties
      public string Line
      {
         get => _line;
         set
         {
            _line = value;
            OnPropertyChanged();
         }
      }

      public string LineNumber
      {
         get => _lineNumber;
         set
         {
            _lineNumber = value;
            OnPropertyChanged();
         }
      }

      public string ObjectName
      {
         get => _objectName;
         set
         {
            _objectName = value;
            OnPropertyChanged();
         }
      }

      public string ObjectPath
      {
         get => _objectPath;
         set
         {
            _objectPath = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }
}
