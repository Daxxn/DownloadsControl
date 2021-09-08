using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Diagnostics;
using System.Collections.ObjectModel;
using DownloadsManagerClient.Properties;
using DownloadsManagerClient.Exceptions;

namespace DownloadsManagerClient.Models
{
   public class ServiceManager
   {
      #region - Fields & Properties
      public delegate void ExitedCallback(int exitCode);
      private static ServiceManager _inst;
      private ServiceController Service { get; set; }
      #endregion

      #region Constructors
      private ServiceManager() { }
      #endregion

      #region - Methods
      public void FindDirectories(bool overwrite)
      {
         try
         {
            if (overwrite || String.IsNullOrEmpty(Properties.Settings.Default.RootDir))
            {
               Properties.Settings.Default.RootDir = SearchForRootDir();

               Properties.Settings.Default.Save();
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      private string SearchForRootDir() => SearchParent(Directory.GetCurrentDirectory());

      private string SearchParent(string path)
      {
         var parentInfo = new DirectoryInfo(path).Parent;
         return
            parentInfo.Name != Properties.Settings.Default.RootDirName
            ? SearchParent(parentInfo.FullName)
            : parentInfo.FullName;
      }

      #region Service Control
      public void FindService()
      {
         try
         {
            Service = new ServiceController("DownloadsManager");
         }
         catch (Exception)
         {
            throw;
         }
      }

      public void InstallService(ExitedCallback callback)
      {
         try
         {
            //if (Service != null && File.Exists(Properties.Settings.Default.ServiceDir))
            //{
            //   var processInfo = new ProcessStartInfo
            //   {
            //      FileName = "cmd.exe",
            //      Arguments = $"{Properties.Settings.Default.ServiceDir} install start",
            //      CreateNoWindow = !Properties.Settings.Default.ShowServiceShell,
            //      UseShellExecute = Properties.Settings.Default.ShowServiceShell,
            //   };
            //   var process = Process.Start(processInfo);
            //   if (!process.HasExited)
            //   {
            //      process.Exited += (object sender, EventArgs e) => callback(process.ExitCode);
            //   }
            //}
            ProcessStartInfo processInfoTest = new()
            {
               ErrorDialog = false,
               Arguments = "cd ..",
               CreateNoWindow = false,
               FileName = "windowsterminal.exe",
            };
            var process = Process.Start(processInfoTest);
            if (!process.HasExited)
            {
               process.Exited += (object sender, EventArgs e) => callback(process.ExitCode);
            }
         }
         catch (Exception e)
         {
            throw new ServiceManagerException("Service Installer Failed", e);
         }
      }

      public void Start()
      {
         try
         {
            if (Service is not null)
            {
               if (Service.Status != ServiceControllerStatus.Running
                  && Service.Status != ServiceControllerStatus.StartPending
                  && Service.Status != ServiceControllerStatus.ContinuePending)
               {
                  Service.Start();
               }
            }
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion
      #endregion

      #region - Full Properties
      public static ServiceManager Instance
      {
         get
         {
            if (_inst is null)
            {
               _inst = new();
            }
            return _inst;
         }
      }
      #endregion
   }
}
