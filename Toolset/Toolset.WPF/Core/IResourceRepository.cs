using System.Collections.Generic;
using Toolset.WPF.Models;

namespace Toolset.WPF.Core
{
     public interface IResourceRepository
     {
          IEnumerable<Resource> GetResources(string resourceType, string selectedModuleDisplayName);
     }
}