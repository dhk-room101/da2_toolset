using MVVMSidekick.ViewModels;

namespace Toolset.WPF.Models
{
    public class TabItem
    {
        public string TabName { get; set; }
        public ViewModelBase<TabContent> TabContent { get; set; }
    }
}