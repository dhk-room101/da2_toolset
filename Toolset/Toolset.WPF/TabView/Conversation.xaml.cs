using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Toolset.WPF.ViewModels;

namespace Toolset.WPF.TabView
{
    /// <summary>
    /// Interaction logic for Conversation.xaml
    /// </summary>
    public partial class Conversation : MVVMControl
    {
        public Conversation()
            : base(null)
        {
            InitializeComponent();
        }

        public Conversation(Conversation_Model model)
            : base(model)
        {
            InitializeComponent();
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
             //Multiple individual casting for ease of viewing
             Conversation_Model conversation_Model = (Conversation_Model)base.ViewModel;
             TreeView treeView = (TreeView)sender;
             Node selectedNode = (Node)treeView.SelectedItem;
             
             //Update view/view model properties for binding
             conversation_Model.SelectedNodeActionPlotName = selectedNode.ActionPlotName;
             conversation_Model.SelectedNodeActionPlotFlagIndex = selectedNode.ActionPlotFlagIndex;

             conversation_Model.SelectedNodeConditionPlotName = selectedNode.ConditionPlotName;
             conversation_Model.SelectedNodeConditionPlotFlagIndex = selectedNode.ConditionPlotFlagIndex;
        }
    }
}
 