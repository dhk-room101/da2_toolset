using Toolset.WPF.Core;
namespace Toolset.WPF.Models
{
     public class Resource
     {
          public Resource(string fullName)
          {
               this.FullName = fullName;
          }

          public string FullName { get; set; }
          public string Name { get; set; }
          public string Type { get; set; }
          public string Parent { get; set; }
     }
}