﻿using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Toolset.WPF
{
     /// <summary>
     /// Interaction logic for App.xaml
     /// </summary>
     public partial class App : Application
     {
          public static void InitNavigationConfigurationInThisAssembly()
          {
               MVVMSidekick.Startups.StartupFunctions.RunAllConfig();
          }

          private void Application_Startup(object sender, StartupEventArgs e)
          {
               InitNavigationConfigurationInThisAssembly();
          }
     }
}
