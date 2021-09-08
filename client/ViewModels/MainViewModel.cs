using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows;
using DownloadsManagerClient.Models;
using DownloadsManagerClient.Models.Filters;
using DownloadsManagerClient.Models.Settings;
using Microsoft.Win32;
using MVVMLibrary;

namespace DownloadsManagerClient.ViewModels
{
   public class MainViewModel : Model
   {
      #region - Fields & Properties
      public event EventHandler<Exception> OpenErrorDialog;
      private readonly ServiceManager _serviceManager;
      private GlobalSettingsModel _globalSettings;
      private FilterSettingsModel _filterSettings;
      private Filter _selectedFilter;

      private bool _filtersOnlyMode;

      private string _globalSettingsPath;
      private string _filterSettingsPath;

      #region - Commands
      public Command AddFilterCmd { get; init; }
      public Command RemoveFilterCmd { get; init; }
      public Command OpenFilesCmd { get; init; }
      public Command SaveFilesCmd { get; init; }
      public Command TestCmd { get; init; }
      #endregion
      #endregion

      #region - Constructors
      public MainViewModel()
      {
         _serviceManager = ServiceManager.Instance;
         GlobalSettings = new();
         FilterSettings = new();

         AddFilterCmd = new(o => AddFilter());
         RemoveFilterCmd = new(o => RemoveFilter());
         TestCmd = new(o => Test());
      }
      #endregion

      #region - Methods

      #region - Command Methods
      public void AddFilter()
      {
         if (FilterSettings != null)
         {
            FilterSettings.Filters.Add(new());
         }
      }

      public void RemoveFilter() => FilterSettings.Filters.Remove(SelectedFilter);

      public void OpenFiles()
      {
         try
         {
            var dialog = new OpenFileDialog()
            {
               Multiselect = true,
               Title = "Open Settings Files"
            };

            if (dialog.ShowDialog() == true)
            {
               string[] files = dialog.FileNames;
               if (files.Length is 1 or 2)
               {
                  foreach (string file in files)
                  {
                     if (Path.GetFileName(file) == "FilterSettings.json")
                     {
                        FilterSettingsPath = file;
                     }
                     else if (Path.GetFileName(file) == "GlobalSettings.json")
                     {
                        GlobalSettingsPath = file;
                     }
                  }
               }
            }
         }
         catch (Exception e)
         {
            OpenErrorDialog?.Invoke(this, e);
         }
      }

      public void SaveFiles()
      {
         try
         {

         }
         catch (Exception e)
         {
            OpenErrorDialog?.Invoke(this, e);
         }
      }

      public void Test()
      {
         try
         {
            //OpenErrorDialog?.Invoke(
            //   this,
            //   new TestException(
            //      "This is a testing error only.",
            //      new TestException("This is an inner exception test.")
            //   )
            //);

            //ServiceManager.FindDirectories(true);
            _serviceManager.InstallService((errorCode) =>
            {
               if (errorCode is not -1)
               {
                  OpenErrorDialog?.Invoke(this, new($"Service install failed with error code: {errorCode}"));
               }
               else
               {
                  _ = MessageBox.Show("Exited Event Trigger");
               }
            });
         }
         catch (Exception e)
         {
            OpenErrorDialog?.Invoke(this, e);
         }
      }
      #endregion
      #endregion

      #region - Full Properties
      public GlobalSettingsModel GlobalSettings
      {
         get => _globalSettings;
         set
         {
            _globalSettings = value;
            OnPropertyChanged();
         }
      }

      public FilterSettingsModel FilterSettings
      {
         get => _filterSettings;
         set
         {
            _filterSettings = value;
            OnPropertyChanged();
         }
      }

      public string GlobalSettingsPath
      {
         get => _globalSettingsPath;
         set
         {
            _globalSettingsPath = value;
            OnPropertyChanged();
         }
      }

      public string FilterSettingsPath
      {
         get => _filterSettingsPath;
         set
         {
            _filterSettingsPath = value;
            OnPropertyChanged();
         }
      }

      public Filter SelectedFilter
      {
         get => _selectedFilter;
         set
         {
            _selectedFilter = value;
            OnPropertyChanged();
         }
      }

      public bool FiltersOnlyMode
      {
         get => _filtersOnlyMode;
         set
         {
            _filtersOnlyMode = value;
            OnPropertyChanged();
         }
      }
      #endregion
   }

   /// <summary>
   /// Remove when finished with ErrorDialogTemplate.xaml
   /// </summary>
   public class TestException : Exception
   {
      public TestException() { }
      public TestException(string message) : base(message) { }
      public TestException(string message, Exception innerException) : base(message, innerException) { }
   }
}
