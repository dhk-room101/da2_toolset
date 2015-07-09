using System;
using System.Collections.Generic;
using System.Linq;
using Toolset.WPF.Models;

namespace Toolset.WPF.Core
{
     public class ResourceRepository : IResourceRepository
     {
          public IEnumerable<Resource> GetResources(string resourceType, string selectedModuleDisplayName)
          {
               //TO DO handle empty queries if returned
               var resourceList = new List<Resource>();

               var resourceQuery =
                   from resources in MainWindow.toolsetDataContext.t_HashesTables
                   where resources.FileType == resourceType && resources.Project == selectedModuleDisplayName
                   select resources;

               foreach (var resourceObj in resourceQuery)
               {
                    string[] info = ResourceFunctions.GetResourceBase(resourceObj.FullName);

                    var _resource = new Resource(resourceObj.FullName)
                    {
                         Name = info[0],
                         Type = info[1],
                         Parent = resourceObj.Parent
                    };
                    resourceList.Add(_resource);
               }

               return resourceList;
          }
     }
}