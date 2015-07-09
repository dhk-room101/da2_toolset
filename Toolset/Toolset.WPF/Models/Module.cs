namespace Toolset.WPF.Models
{
     public class Module
     {
          public Module(int moduleID)
          {
               this.ModuleID = moduleID;
          }
          public int ModuleID { get; set; }
          public string DisplayName { get; set; }
          public string Name { get; set; }
          public string UUID { get; set; }
          public string LanguageID { get; set; }
          public string Details { get; set; }
          public string ProjectType { get; set; }
          public bool IsActive { get; set; }
     }
}