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
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Toolset.WPF.Core;
using Toolset.WPF.Models;
using System.IO;
using System.Xml.XPath;
using Microsoft.Win32;
using System.Windows.Input;
using Gibbed.Bioware.FileFormats;
using Toolset.WPF.TabView;

namespace Toolset.WPF.ViewModels
{

     public class MainWindow_Model : ViewModelBase<MainWindow_Model>
     {
          // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property propcmd for command
          private IModuleRepository _moduleRepository;
          private IResourceRepository _resourceRepository;
          public ObservableCollection<TabItem> Tabs { get; set; }
          
          //For now the resource is statically set to conversation type:cnv
          private string resourceType = "cnv";

          public MainWindow_Model()
          {
               if (IsInDesignMode)
               {
                    Title = "Title is a little different in Design mode";
               }

               //For future reference to be used by children/other view models
               MainWindow.parentMainModel = this;

               //Read XML settings
               ReadSettingsXML();

               //Refresh or update the module Repository
               RefreshModules();

               RefreshResources();

               Tabs = new ObservableCollection<TabItem>();
               
               //TO DO Create new module in database
          }

          public void ReadSettingsXML()
          {
               string settings = MainWindow.toolsetPath + "\\settings.xml";
               if (File.Exists(settings))
	          {
                    string path = null;
                    var doc = new XPathDocument(settings);
                    var nav = doc.CreateNavigator();
                    var locations = nav.Select("/settings/installPaths/installPath");
                    while (locations.MoveNext() == true)
                    {
                         bool failed = true;

                         var actions = locations.Current.Select("action");
                         while (actions.MoveNext() == true)
                         {
                              string type = actions.Current.GetAttribute("type", "");

                              switch (type)
                              {
                                   case "registry":
                                        {
                                             string key = actions.Current.GetAttribute("key", "");
                                             string value = actions.Current.GetAttribute("value", "");

                                             path = (string)Registry.GetValue(key, value, null);

                                             if (path != null)
                                             {
                                                  //Set the game path for future use
                                                  MainWindow.gamePath = path;
                                                  failed = false;
                                             }

                                             break;
                                        }

                                   default:
                                        {
                                             throw new InvalidOperationException("unhandled install location action type");
                                        }
                              }

                              if (failed == true)
                              {
                                   throw new ArgumentException("Game install path not found!", "failed");
                              }
                         }

                         if (failed == false && Directory.Exists(MainWindow.gamePath) == true)
                         {
                              Console.WriteLine("Settings XML parsed!");
                              break;
                         }
                    }
	          }
               else
               {
                    throw new ArgumentException("Settings XML not found!");
               }
          }

          public void RefreshModules()
          {
               _moduleRepository = new ModuleRepository();
               this.Modules = _moduleRepository.GetModules();
               this.SelectedModule = ModuleFunctions.GetModuleActive(this.Modules);
          }

          public void RefreshResources()
          {
               _resourceRepository = new ResourceRepository();
               //For now the resource is statically set to conversation type:cnv
               this.Resources = _resourceRepository.GetResources(resourceType, this.SelectedModule.DisplayName);
               this.Autocomplete = "";
               this.Status = "Ready";
          }

          public void UpdateDatabaseActive(string type)
          {
               switch (type)
               {
                    case "Module":
                         {
                              ModuleFunctions.SetModuleActiveInDatabase(this.SelectedModule); 
                              break;
                         }
                    case "Resource":
                         {
                              break;
                         }
                    default:
                         {
                              throw new InvalidOperationException("unhandled Database update action type");
                         }
               }
          }
          
          //propvm tab tab string tab Title
          public String Title
          {
               get { return _TitleLocator(this).Value; }
               set { _TitleLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property String Title Setup
          protected Property<String> _Title = new Property<String> { LocatorFunc = _TitleLocator };
          static Func<BindableBase, ValueContainer<String>> _TitleLocator = RegisterContainerLocator<String>("Title", model => model.Initialize("Title", ref model._Title, ref _TitleLocator, _TitleDefaultValueFactory));
          static Func<String> _TitleDefaultValueFactory = () => "Title is Here";
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

          public Module SelectedModule
          {
               get { return _SelectedModuleLocator(this).Value; }
               set 
               {
                    _SelectedModuleLocator(this).SetValueAndTryNotify(value); 
                    //New selected means new title And update/refresh the database
                    Title = value.DisplayName;
                    UpdateDatabaseActive("Module");
               }
          }

          #region Property Module SelectedModule Setup
          protected Property<Module> _SelectedModule = new Property<Module> { LocatorFunc = _SelectedModuleLocator };
          static Func<BindableBase, ValueContainer<Module>> _SelectedModuleLocator = RegisterContainerLocator<Module>("SelectedModule", model => model.Initialize("SelectedModule", ref model._SelectedModule, ref _SelectedModuleLocator, _SelectedModuleDefaultValueFactory));
          static Func<Module> _SelectedModuleDefaultValueFactory = null;
          #endregion

          public IEnumerable<Module> Modules
          {
               get { return _ModulesLocator(this).Value; }
               set { _ModulesLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property IEnumerable<Module> Modules Setup

          protected Property<IEnumerable<Module>> _Modules = new Property<IEnumerable<Module>> { LocatorFunc = _ModulesLocator };
          static Func<BindableBase, ValueContainer<IEnumerable<Module>>> _ModulesLocator = RegisterContainerLocator<IEnumerable<Module>>("Modules", model => model.Initialize("Modules", ref model._Modules, ref _ModulesLocator, _ModulesDefaultValueFactory));
          static Func<IEnumerable<Module>> _ModulesDefaultValueFactory = null;

          #endregion

          public Resource SelectedResource
          {
               get { return _SelectedResourceLocator(this).Value; }
               set { _SelectedResourceLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property Resource SelectedResource Setup
          protected Property<Resource> _SelectedResource = new Property<Resource> { LocatorFunc = _SelectedResourceLocator };
          static Func<BindableBase, ValueContainer<Resource>> _SelectedResourceLocator = RegisterContainerLocator<Resource>("SelectedResource", model => model.Initialize("SelectedResource", ref model._SelectedResource, ref _SelectedResourceLocator, _SelectedResourceDefaultValueFactory));
          static Func<Resource> _SelectedResourceDefaultValueFactory = null;
          #endregion

          public IEnumerable<Resource> Resources
          {
               get { return _ResourcesLocator(this).Value; }
               set { _ResourcesLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property IEnumerable<Resource> Resources Setup
          protected Property<IEnumerable<Resource>> _Resources = new Property<IEnumerable<Resource>> { LocatorFunc = _ResourcesLocator };
          static Func<BindableBase, ValueContainer<IEnumerable<Resource>>> _ResourcesLocator = RegisterContainerLocator<IEnumerable<Resource>>("Resources", model => model.Initialize("Resources", ref model._Resources, ref _ResourcesLocator, _ResourcesDefaultValueFactory));
          static Func<IEnumerable<Resource>> _ResourcesDefaultValueFactory = null;
          #endregion

          public IEnumerable<Resource> FilteredResources
          {
               get { return _FilteredResourcesLocator(this).Value; }
               set { _FilteredResourcesLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property IEnumerable<Resource> FilteredResources Setup
          protected Property<IEnumerable<Resource>> _FilteredResources = new Property<IEnumerable<Resource>> { LocatorFunc = _FilteredResourcesLocator };
          static Func<BindableBase, ValueContainer<IEnumerable<Resource>>> _FilteredResourcesLocator = RegisterContainerLocator<IEnumerable<Resource>>("FilteredResources", model => model.Initialize("FilteredResources", ref model._FilteredResources, ref _FilteredResourcesLocator, _FilteredResourcesDefaultValueFactory));
          static Func<IEnumerable<Resource>> _FilteredResourcesDefaultValueFactory = null;
          #endregion
          
          public string Autocomplete
          {
               get { return _AutocompleteLocator(this).Value; }
               set
               {
                    _AutocompleteLocator(this).SetValueAndTryNotify(value);
                    //Get filtered resources based on auto complete value
                    FilteredResources = GetFilteredResources(value);
               }
          }

          #region Property string Autocomplete Setup
          protected Property<string> _Autocomplete = new Property<string> { LocatorFunc = _AutocompleteLocator };
          static Func<BindableBase, ValueContainer<string>> _AutocompleteLocator = RegisterContainerLocator<string>("Autocomplete", model => model.Initialize("Autocomplete", ref model._Autocomplete, ref _AutocompleteLocator, _AutocompleteDefaultValueFactory));
          static Func<string> _AutocompleteDefaultValueFactory = null;
          #endregion

          public string Status
          {
               get { return _StatusLocator(this).Value; }
               set { Console.WriteLine("current status {0}", value); 
                    _StatusLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property string Status Setup
          protected Property<string> _Status = new Property<string> { LocatorFunc = _StatusLocator };
          static Func<BindableBase, ValueContainer<string>> _StatusLocator = RegisterContainerLocator<string>("Status", model => model.Initialize("Status", ref model._Status, ref _StatusLocator, _StatusDefaultValueFactory));
          static Func<string> _StatusDefaultValueFactory = null;
          #endregion

          public IEnumerable<Resource> GetFilteredResources(string autocomplete)
          {
               return from resources in this.Resources
                      where resources.Name.StartsWith(autocomplete) == true
                      select resources;
          }

          public TabItem SelectedTabItem
          {
               get { return _SelectedTabItemLocator(this).Value; }
               set { _SelectedTabItemLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property TabItem SelectedTabItem Setup
          protected Property<TabItem> _SelectedTabItem = new Property<TabItem> { LocatorFunc = _SelectedTabItemLocator };
          static Func<BindableBase, ValueContainer<TabItem>> _SelectedTabItemLocator = RegisterContainerLocator<TabItem>("SelectedTabItem", model => model.Initialize("SelectedTabItem", ref model._SelectedTabItem, ref _SelectedTabItemLocator, _SelectedTabItemDefaultValueFactory));
          static Func<TabItem> _SelectedTabItemDefaultValueFactory = null;
          #endregion

          //Handle commands
          public CommandModel<ReactiveCommand, String> CommandViewResource
          {
               get { return _CommandViewResourceLocator(this).Value; }
               set { _CommandViewResourceLocator(this).SetValueAndTryNotify(value); }
          }

          #region Property CommandModel<ReactiveCommand, String> CommandViewResource Setup

          protected Property<CommandModel<ReactiveCommand, String>> _CommandViewResource = new Property<CommandModel<ReactiveCommand, String>> { LocatorFunc = _CommandViewResourceLocator };
          static Func<BindableBase, ValueContainer<CommandModel<ReactiveCommand, String>>> _CommandViewResourceLocator = RegisterContainerLocator<CommandModel<ReactiveCommand, String>>("CommandViewResource", model => model.Initialize("CommandViewResource", ref model._CommandViewResource, ref _CommandViewResourceLocator, _CommandViewResourceDefaultValueFactory));
          static Func<BindableBase, CommandModel<ReactiveCommand, String>> _CommandViewResourceDefaultValueFactory =
              model =>
              {
                   var cmd = new ReactiveCommand(canExecute: true) { ViewModel = model };
                   var vm = CastToCurrentType(model);
                   cmd.Subscribe(_ =>
                   {
                        vm.PrepareResource(vm.SelectedResource);
                   }).DisposeWith(model);
                   return cmd.CreateCommandModel("ViewResource");
              };

          #endregion

          //TO DO if resource handling is successful, update the Tab Item view
          public void PrepareResource(Resource selectedResource)
          {
               //Add couple of spaces so the tab name displays nicer
               string name = "  " + selectedResource.Name;

               //But first let's check to see if the tab item is already created, 
               //and if yes we will select It
               var result = Tabs.SingleOrDefault(x => x.TabName == name);
               if (result != null)
               {
                    this.SelectedTabItem = result;
               }
               else
               {
                    //Update the status
                    //this.Status = "PLEASE WAIT: Processing…";

                    //Check for multiple parents And extrapolate the preferred one
                    string preferred = selectedResource.Parent;
                    if (preferred.IndexOf(";") != -1)
                    {
                         preferred = ResourceFunctions.GetPreferredParent(preferred);
                    }
                    //Now that we have a preferred parent name, we need to identify its path
                    string path = ResourceFunctions.GetPath(preferred);

                    //And create its equivalent in the user documents folder for further processing
                    string processing = MainWindow.da2UserPath + "toolset" + path;
                    Directory.CreateDirectory(processing);

                    //Extract the selected resource into the processing folder for further processing
                    //this step uses an external program erfextract
                    //Create an array of arguments for this command
                    var listArg = new List<string>();
                    listArg.Add(MainWindow.gamePath + path);
                    listArg.Add(selectedResource.FullName);
                    listArg.Add(processing + @"\" + selectedResource.FullName);
                    string[] arguments = listArg.ToArray();
                    ResourceFunctions.LaunchExternalCommand("erfextract", arguments);

                    //Read/Deserialize the extracted GFF
                    //TO DO As a workaround we use a public static reference in the main window
                    //we reinitialize it every time we process in your resource
                    //maybe there is a better way to do this, But this is how I made it workΓÇª
                    MainWindow.gffType = new GenericFile_Type();
                    using (var input = File.OpenRead(processing + @"\" + selectedResource.FullName))
                    {
                         MainWindow.gffType.Deserialize(input);
                    }

                    //Now that we have everything ready,Initialize the tab content
                    TabItem _tab = new TabItem
                    {
                         TabName = name,
                         TabContent = new TabContent(selectedResource.Type)
                    };
                    this.SelectedTabItem = _tab;
                    Tabs.Add(_tab);
               }
          }
     }
}
