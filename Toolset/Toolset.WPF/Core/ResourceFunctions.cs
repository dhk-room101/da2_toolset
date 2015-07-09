using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolset.WPF.Core
{
     static class ResourceFunctions
     {
          public static string[] GetResourceBase(string resourceFullName)
          {
               string result = null;
               string[] results = new string[2];//Statically set to only two elements: Name and type
               string name = null;
               string type = null;

               //first look for '\' After that look for '.'
               char backslash = '\\';
               string[] backslashes = resourceFullName.Split(backslash);

               char dot = '.';
               string[] dots = null;

               if (backslashes.Length == 1)
               {
                    result = resourceFullName;
               }
               else
               {
                    result = backslashes[backslashes.Length - 1];
               }

               dots = resourceFullName.Split(dot);

               if (dots.Length < 2)
               {
                    throw new ArgumentException("This resource doesn't have a name and a type", "dots.Length");
               }
               if (dots.Length == 2)
               {
                    name = dots[0];
                    type = dots[1];
               }
               if (dots.Length > 2)
               {
                    for (uint i = 0;i<dots.Length-2;i++)
                    {
                         name += dots[i];
                    }
                    type = dots[dots.Length - 1];
               }

               results[0] = name;
               results[1] = type;

               return results;
          }

          public static string GetPreferredParent(string selectedResourceParent)
          {
               string preferred = null;
               bool found = false;
               char c = ';';
               string[] a = selectedResourceParent.Split(c);
               foreach (var s in a)
               {
                    if (s.IndexOf(".rim") != -1 && found == false)
                    {
                         found = true;
                         preferred = s;
                    }
               }
               return preferred;
          }

          public static string GetPath(string preferred)
          {
               var pathQuery = from paths in MainWindow.toolsetDataContext.t_ResourcePathTables
                               where paths.ResourceName == preferred
                               select paths;

               string _path = null;

               //Create a counter to make sure it is always one = 1
               int counter = 0;

               foreach (var path in pathQuery)
               {
                    _path = path.FullRelativePath;
                    counter++;
               }

               if (counter != 1)
               {
                    throw new ArgumentException("Cannot be more or less than one Path", "counter");
               }

               return _path;
          }

          /// <summary>
          /// Launch the External application with some options set.
          /// </summary>
          public static void LaunchExternalCommand(string externalCommand, string[] arguments)
          {
               bool movingFile = false;
               // Use ProcessStartInfo class
               ProcessStartInfo processInfo = new ProcessStartInfo();
               processInfo.CreateNoWindow = false;
               processInfo.UseShellExecute = false;
               processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                              
               switch (externalCommand)
               {
                    case "erfextract":
                         {
                              processInfo.FileName = MainWindow.toolsetPath + @"\external" + @"\" + externalCommand + @"\" + externalCommand + ".exe";
                              processInfo.WorkingDirectory = MainWindow.toolsetPath + @"\external" + @"\" + externalCommand;
                              //Add the Quote ascii hexadecimal to handle spaces in path
                              processInfo.Arguments = '\u0022' + arguments[0] + '\u0022' + " " + arguments[1] + " " + arguments[1];
                              movingFile = true;
                              break;
                         }
                    default:
                         {
                              break;
                         }
               }
               
               try
               {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(processInfo))
                    {
                         exeProcess.WaitForExit();
                    }
               }
               catch
               {
                    // Log error.
                    Console.WriteLine("something went wrong");
               }

               //If moving a file is required
               if(movingFile)
               {
                    string source = processInfo.WorkingDirectory + @"\" + arguments[1];
                    string destination = arguments[2];
                    // Ensure that the target does not exist. 
                    if (File.Exists(destination))
                         File.Delete(destination);

                    // Move the file.
                    File.Move(source, destination);
               }
          }

          public static string GetPlotName(string uuid)
          {
               var plotQuery = from plots in MainWindow.toolsetDataContext.t_PlotsTables
                               where plots.UUID == uuid
                               select plots;

               string _plot = null;

               //Create a counter to make sure it is always one = 1
               int counter = 0;

               foreach (var plot in plotQuery)
               {
                    _plot = plot.Name;
                    counter++;
               }

               if (counter != 1)
               {
                    throw new ArgumentException("Cannot be more or less than one Plot", "counter");
               }

               return _plot;
          }

          public static string GetTalkString(int talkID)
          {
               var talkStringQuery = from talkStrings in MainWindow.toolsetDataContext.t_TalkTables
                                     where talkStrings.ID == talkID
                                     select talkStrings;

               string _talkString = null;

               //Create a counter to make sure it is always one = 1
               int counter = 0;

               foreach (var talkString in talkStringQuery)
               {
                    _talkString = talkString.String;
                    counter++;
               }

               //Handle empty talk string
               if (!talkStringQuery.Any())
               {
                    _talkString = "";
                    counter++;
               }

               if (counter != 1)
               {
                    throw new ArgumentException("Cannot be more or less than one TalkString", "counter");
               }

               return _talkString;
          }
     }
}
