   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions'Microsoft.Expression.Interactivity.Core p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls G CMVVMSidekick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekickMVVMSidekick.Views F BToolset.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Toolset.WPF.ViewModelsToolset.WPF.ViewModels    Toolset.WPF.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U	 QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     	 R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  
   pcmd`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions  
   minputToolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  
   Gmvvm6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekick  
   3vm$clr-namespace:Toolset.WPF.ViewModels  
   -   $��ToolsetWindow��  � WindowState$  	Maximized=� � Title �� *DataContext.Title+ �� ElementName$
 grid�� � 	Resources -  'Toolset.WPF.ViewModels.MainWindow_Model 
  MainVM  WindowBrush �� Color��%.   &	        &	        �� $ 	#FF333333������  �� 
TargetType" �.���  �� Property � �� �� Value# [ .��� -    �Name$
 grid��	 � DataContext	 �� 
 �� Mode$
 OneWay=� �� Source# [   � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ modules��{�.  $	��200�� � ToolTip$ Selecting modules��$��0��$��0��$
��Left=�$	��Top=� �� SelectedItem �� *SelectedModule+$
 TwoWay=�����  �� Path$ Modules�$
 TwoWay=����� .R���  �� Orientation$ 
Horizontal=�.+��� ���� *DisplayName+�� -    ��Name$ textBox��$	��200��$ Autocomplete Box��$��0��$��1��$
��Left=�$	��Top=����� *Autocomplete+ �� UpdateSourceTrigger$ PropertyChanged=�.���� -    ��Name$ resourceList��$	��200��$ Selecting resource��$��0��$��2��$
��Left=�$	��Top=� �� *SelectedResource+$
 TwoWay=����� $ FilteredResources�$
 OneWay=�.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ MouseDoubleClick��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction     Command �� *CommandViewResource+���� .R��� $ 
Horizontal=�.+��� ���� *Name+�� -   $ 	statusBox��$	��200��$ Status��{�.  $��0��$��3��$
��Left=�$	��Top=����� *Status+$ PropertyChanged=�.���� $��2��$��1��  DefaultTabControlItem#��[   DefaultTabItem#��[  �� *SelectedTabItem+$
 TwoWay=����� *Tabs+$
 TwoWay=����� .R��� �� ���� *	TabName+ �� ContentTemplate �� .R��� ���� * TabContent.TabContentLayout[0]+