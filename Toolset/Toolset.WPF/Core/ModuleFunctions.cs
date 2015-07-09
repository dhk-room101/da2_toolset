using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolset.WPF.Models;

namespace Toolset.WPF.Core
{
     static class ModuleFunctions
     {
          public static Module GetModuleActive(IEnumerable <Module> moduleList)
          {
               //Create a new bogus module
               Module selected = new Module(-1);
               
               //Create a counter to make sure it is always one = 1
               int counter = 0;

               foreach (var module in moduleList)
               {
                    if (module.IsActive == true)
                    {
                         selected = module;
                         counter++;
                    }
               }

               if (counter != 1)
               {
                    throw new ArgumentException("Cannot be more or less than one active module", "counter");
               }

               return selected;
          }

          public static void SetModuleActiveInDatabase(Module module)
          {
               var moduleQuery =
                   from modules in MainWindow.toolsetDataContext.t_ModulesTables
                   select modules;

               foreach (var moduleObj in moduleQuery)
               {
                    t_ModulesTable objModuleInactive = MainWindow.toolsetDataContext.t_ModulesTables.Single(_module => _module.ModuleID == moduleObj.ModuleID);
                    objModuleInactive.IsActive = false;
                    MainWindow.toolsetDataContext.SubmitChanges();
               }

               t_ModulesTable objModuleActive = MainWindow.toolsetDataContext.t_ModulesTables.Single(_module => _module.ModuleID == module.ModuleID);
               objModuleActive.IsActive = true;
               MainWindow.toolsetDataContext.SubmitChanges();
          }
     }
}
