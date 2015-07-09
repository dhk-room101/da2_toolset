using System.Collections.Generic;
using Toolset.WPF.Models;

namespace Toolset.WPF.Core
{
     public interface IModuleRepository
     {
          IEnumerable<Module> GetModules();
     }
}