using MVVMSidekick;
using MVVMSidekick.Patterns.Tree;
using MVVMSidekick.Reactive;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMSidekick.Collections;
using Gibbed.Bioware.FileFormats;
using Toolset.WPF.Core;

namespace Toolset.WPF.TabView
{

    public class Conversation_Model : ViewModelBase<Conversation_Model>
    {

        public Conversation_Model()
        {
             ParseConversation();
        }

        public void ParseConversation()
        {
             int counter = 0;

             CONV gffConversation = MainWindow.gffType.ExportType<CONV>();
             
             //Have an array ready with the main branches index ID
             int[] mainBranches = new int[gffConversation.EntriesLinks.Count];
             foreach (var branch in gffConversation.EntriesLinks)
             {
                  mainBranches[counter] = gffConversation.EntriesLinks[counter].index;
                  counter++;
             }
             
             //Create an array to throw the lines in
             CONV.LINE[] lines = new CONV.LINE[gffConversation.Lines.Count];
             
             //Create an empty linear node array
             Node[] nodes = new Node[gffConversation.Lines.Count];
             counter = 0;//reset the counter for future use

             //Populate the lines array
             foreach (var line in gffConversation.Lines)
             {
                  lines[counter] = line;
                  counter++;
             }

             counter = 0;//reset the counter for future use

             //Populate the nodes array
             for (var i = 0; i < lines.Length; i++ )
             {
                  CONV.LINE line = lines[i];
                  Node node = GetNodeFromLine(line);
                  nodes[i] = node;
             }

             //Populate nodes With children
             for (var i = 0; i < lines.Length; i++ )
             {
                  CONV.LINE line = lines[i];
                  if ( line.repliesList.Count > 0)
                  {
                       foreach (var reply in line.repliesList)
                       {
                            nodes[i].Children.Add(nodes[reply.index]);
                       }
                  }
             }

             //Add the root nodes
             for (var i = 0; i < nodes.Length; i++)
             {
                  for (var j = 0; j < mainBranches.Length; j++)
                  {
                       if (i == mainBranches[j])
                       {
                            RootNodes.Add(nodes[i]);
                       }
                  }
             }

             Console.WriteLine("root nodes length {0}", RootNodes.Count);

             //Reset the status
            //MainWindow.parentMainModel.Status = "Ready";
        }

        public Node GetNodeFromLine( CONV.LINE line)
        {
             Node result = new Node();
             
             if (line.lineTalk.Id != 4294967295)//FFFFFFFF a.k.a. -1
             {
                  string talkString = ResourceFunctions.GetTalkString(Convert.ToInt32(line.lineTalk.Id));
                  if (talkString == "")
                  {
                       if (line.repliesList.Count == 0)
                       {
                            result.Value = "[[END DIALOG]]";
                       }
                       else
                       {
                            result.Value = "[[CONTINUE]]";
                       }
                  }
                  else
                  {
                       result.Value = talkString;
                  }
             }
             else
             {
                  throw new ArgumentException("Line Talk ID cannot be -1/4294967295", "line.lineTalk.Id");
             }

             //Set the flag type: condition, action, both, none
             //To be used to display the image
             bool conditionPlotFound = false;
             bool actionPlotFound = false;
             if (line.plotCondition.uuid != "")
             {
                  result.ConditionPlotName = ResourceFunctions.GetPlotName(line.plotCondition.uuid);
                  result.ConditionPlotFlagIndex = line.plotCondition.flagIndex.ToString();
                  conditionPlotFound = true;
             }
             if (line.plotAction.uuid != "")
             {
                  result.ActionPlotName = ResourceFunctions.GetPlotName(line.plotAction.uuid);
                  result.ActionPlotFlagIndex = line.plotAction.flagIndex.ToString();
                  actionPlotFound = true;
             }

             if ( conditionPlotFound && actionPlotFound)
             {
                  result.IsNodeFlag = "BOTH";
             }
             else if ( conditionPlotFound && !actionPlotFound)
             {
                  result.IsNodeFlag = "CONDITION";
             }
             else if (!conditionPlotFound && actionPlotFound)
             {
                  result.IsNodeFlag = "ACTION";
             }
             else
             {
                  result.IsNodeFlag = "NONE";
             }
             
             return result;
        }

        public ObservableCollection<TreeViewItemModel<string>> RootNodes
        {
            get { return _RootNodesLocator(this).Value; }
            set { _RootNodesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<TreeViewItemModel<string >>  RootNodes Setup
        protected Property<ObservableCollection<TreeViewItemModel<string>>> _RootNodes = new Property<ObservableCollection<TreeViewItemModel<string>>> { LocatorFunc = _RootNodesLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<TreeViewItemModel<string>>>> _RootNodesLocator = RegisterContainerLocator<ObservableCollection<TreeViewItemModel<string>>>("RootNodes", model => model.Initialize("RootNodes", ref model._RootNodes, ref _RootNodesLocator, _RootNodesDefaultValueFactory));
        static Func<ObservableCollection<TreeViewItemModel<string>>> _RootNodesDefaultValueFactory = () => new ObservableCollection<TreeViewItemModel<string>>();
        #endregion

        public string SelectedNodeConditionPlotName
        {
             get { return _SelectedNodeConditionPlotNameLocator(this).Value; }
             set { _SelectedNodeConditionPlotNameLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property string SelectedNodeConditionPlotName Setup
        protected Property<string> _SelectedNodeConditionPlotName = new Property<string> { LocatorFunc = _SelectedNodeConditionPlotNameLocator };
        static Func<BindableBase, ValueContainer<string>> _SelectedNodeConditionPlotNameLocator = RegisterContainerLocator<string>("SelectedNodeConditionPlotName", model => model.Initialize("SelectedNodeConditionPlotName", ref model._SelectedNodeConditionPlotName, ref _SelectedNodeConditionPlotNameLocator, _SelectedNodeConditionPlotNameDefaultValueFactory));
        static Func<string> _SelectedNodeConditionPlotNameDefaultValueFactory = null;
        #endregion

        public string SelectedNodeConditionPlotFlagIndex
        {
             get { return _SelectedNodeConditionPlotFlagIndexLocator(this).Value; }
             set { _SelectedNodeConditionPlotFlagIndexLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property string SelectedNodeConditionPlotFlagIndex Setup
        protected Property<string> _SelectedNodeConditionPlotFlagIndex = new Property<string> { LocatorFunc = _SelectedNodeConditionPlotFlagIndexLocator };
        static Func<BindableBase, ValueContainer<string>> _SelectedNodeConditionPlotFlagIndexLocator = RegisterContainerLocator<string>("SelectedNodeConditionPlotFlagIndex", model => model.Initialize("SelectedNodeConditionPlotFlagIndex", ref model._SelectedNodeConditionPlotFlagIndex, ref _SelectedNodeConditionPlotFlagIndexLocator, _SelectedNodeConditionPlotFlagIndexDefaultValueFactory));
        static Func<string> _SelectedNodeConditionPlotFlagIndexDefaultValueFactory = null;
        #endregion

        public string SelectedNodeActionPlotName
        {
             get { return _SelectedNodeActionPlotNameLocator(this).Value; }
             set { _SelectedNodeActionPlotNameLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property string SelectedNodeActionPlotName Setup
        protected Property<string> _SelectedNodeActionPlotName = new Property<string> { LocatorFunc = _SelectedNodeActionPlotNameLocator };
        static Func<BindableBase, ValueContainer<string>> _SelectedNodeActionPlotNameLocator = RegisterContainerLocator<string>("SelectedNodeActionPlotName", model => model.Initialize("SelectedNodeActionPlotName", ref model._SelectedNodeActionPlotName, ref _SelectedNodeActionPlotNameLocator, _SelectedNodeActionPlotNameDefaultValueFactory));
        static Func<string> _SelectedNodeActionPlotNameDefaultValueFactory = null;
        #endregion

        public string SelectedNodeActionPlotFlagIndex
        {
             get { return _SelectedNodeActionPlotFlagIndexLocator(this).Value; }
             set { _SelectedNodeActionPlotFlagIndexLocator(this).SetValueAndTryNotify(value); }
        }

        #region Property string SelectedNodeActionPlotFlagIndex Setup
        protected Property<string> _SelectedNodeActionPlotFlagIndex = new Property<string> { LocatorFunc = _SelectedNodeActionPlotFlagIndexLocator };
        static Func<BindableBase, ValueContainer<string>> _SelectedNodeActionPlotFlagIndexLocator = RegisterContainerLocator<string>("SelectedNodeActionPlotFlagIndex", model => model.Initialize("SelectedNodeActionPlotFlagIndex", ref model._SelectedNodeActionPlotFlagIndex, ref _SelectedNodeActionPlotFlagIndexLocator, _SelectedNodeActionPlotFlagIndexDefaultValueFactory));
        static Func<string> _SelectedNodeActionPlotFlagIndexDefaultValueFactory = null;
        #endregion

        #region Life Time Event Handling
    
        ///// <summary>
        ///// This will be invoked by view when this viewmodel instance is set to view's ViewModel property. 
        ///// </summary>
        ///// <param name="view">Set target</param>
        ///// <param name="oldValue">Value before set.</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedToView(MVVMSidekick.Views.IView view, IViewModel oldValue)
        //{
        //    return base.OnBindedToView(view, oldValue);
        //}

        ///// <summary>
        ///// This will be invoked by view when this instance of viewmodel in ViewModel property is overwritten.
        ///// </summary>
        ///// <param name="view">Overwrite target view.</param>
        ///// <param name="newValue">The value replacing </param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnUnbindedFromView(MVVMSidekick.Views.IView view, IViewModel newValue)
        //{
        //    return base.OnUnbindedFromView(view, newValue);
        //}

        ///// <summary>
        ///// This will be invoked by view when the view fires Load event and this viewmodel instance is already in view's ViewModel property
        ///// </summary>
        ///// <param name="view">View that firing Load event</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedViewLoad(MVVMSidekick.Views.IView view)
        //{
        //    return base.OnBindedViewLoad(view);
        //}

        ///// <summary>
        ///// This will be invoked by view when the view fires Unload event and this viewmodel instance is still in view's  ViewModel property
        ///// </summary>
        ///// <param name="view">View that firing Unload event</param>
        ///// <returns>Task awaiter</returns>
        //protected override Task OnBindedViewUnload(MVVMSidekick.Views.IView view)
        //{
        //    return base.OnBindedViewUnload(view);
        //}

        ///// <summary>
        ///// <para>If dispose actions got exceptions, will handled here. </para>
        ///// </summary>
        ///// <param name="exceptions">
        ///// <para>The exception and dispose infomation</para>
        ///// </param>
        //protected override async void OnDisposeExceptions(IList<DisposeInfo> exceptions)
        //{
        //    base.OnDisposeExceptions(exceptions);
        //    await TaskExHelper.Yield();
        //}

        #endregion
    }

    public class Node : TreeViewItemModel<string>
    {
         public string IsNodeType { get; set; }
         public string IsNodeFlag { get; set; }
         public string ConditionPlotName { get; set; }
         public string ConditionPlotFlagIndex { get; set; }
         public string ActionPlotName { get; set; }
         public string ActionPlotFlagIndex { get; set; }
    }
} 
