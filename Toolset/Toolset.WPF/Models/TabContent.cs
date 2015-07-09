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
using Toolset.WPF.TabView;
using Toolset.WPF.ViewModels;

namespace Toolset.WPF.Models
{
     public class TabContent : ViewModelBase<TabContent>
     {
          public TabContent(string type)
          {
               TabContentLayout = new ObservableCollection<object>();
                              
               switch(type)
               {
                    case "cnv":
                         {
                              //Conversation_Model _conversation_Model = new Conversation_Model();
                              Conversation _conversation = new Conversation();
                              TabContentLayout.Add(_conversation);
                              break;
                         }
                    default:
                         {
                              throw new ArgumentException("Cannot be more or less than one type", "type");
                         }
               }
          }

          public ObservableCollection<Object> TabContentLayout
          {
               get { return _TabContentLayoutLocator(this).Value; }
               set { _TabContentLayoutLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property Object TabContentLayout Setup

          protected Property<ObservableCollection<Object>> _TabContentLayout = new Property<ObservableCollection<Object>> { LocatorFunc = _TabContentLayoutLocator };
          private static Func<BindableBase, ValueContainer<ObservableCollection<Object>>> _TabContentLayoutLocator = RegisterContainerLocator<ObservableCollection<Object>>("TabContentLayout", model => model.Initialize("TabContentLayout", ref model._TabContentLayout, ref _TabContentLayoutLocator, _TabContentLayoutDefaultValueFactory));
          private static Func<ObservableCollection<Object>> _TabContentLayoutDefaultValueFactory = null;

          #endregion Property Object TabContentLayout Setup
     }
}