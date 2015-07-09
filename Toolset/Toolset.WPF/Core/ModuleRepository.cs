using System;
using System.Collections.Generic;
using System.Linq;
using Toolset.WPF.Models;

namespace Toolset.WPF.Core
{
     public class ModuleRepository : IModuleRepository
     {
          public IEnumerable<Module> GetModules()
          {
               var moduleList = new List<Module>();
               
               var moduleQuery =
                   from modules in MainWindow.toolsetDataContext.t_ModulesTables
                   select modules;

               foreach (var moduleObj in moduleQuery)
               {
                    var _module = new Module(Convert.ToInt32(moduleObj.ModuleID.ToString()))
                    {
                         DisplayName = moduleObj.DisplayName,
                         Name = moduleObj.Name,
                         UUID = moduleObj.UUID,
                         LanguageID = moduleObj.LanguageID,
                         Details = moduleObj.Details,
                         ProjectType = moduleObj.ProjectType,
                         IsActive = Convert.ToBoolean(moduleObj.IsActive.ToString())
                    };
                    moduleList.Add(_module);
               }

               return moduleList;
          }
     }
}