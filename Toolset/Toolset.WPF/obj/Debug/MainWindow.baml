   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions'Microsoft.Expression.Interactivity.Core 5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	   G CMVVMSidekick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekickMVVMSidekick.Views 5	   	   F BToolset.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Toolset.WPF.ViewModelsToolset.WPF.ViewModels 5
   	      Toolset.WPF.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U	 QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
   5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  
   5   	   pcmd`clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions  
   5   	   minputToolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  
   5   	   Gmvvm6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekick  
   5	   	   3vm$clr-namespace:Toolset.WPF.ViewModels  
   5
   	   -   5        $��ToolsetWindow��5   3     � WindowState$  	Maximized=�5   	    � Title 5   	   �� *DataContext.Title+ �� ElementName$
 grid�� � 	Resources 5      -  'Toolset.WPF.ViewModels.MainWindow_Model 
  MainVM  WindowBrush �� Color��%J   &	        &	        5   
   6   �� 5   
   $ 	#FF333333��6.   5      ��5      �� 5       �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value# [ 6.   5      .��5      � -   5         �Name$
 grid��5      	 � DataContext	 6   �� 
 �� Mode$
 OneWay=� �� Source# [   � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5      $
��Auto �6"   �� 5       $��* �6"   .+�5"      �� -   5         ��Name$ modules��5"   '   {�.  $	��200��68    � ToolTip$ Selecting modules��6D   $��0��5#      $��0��6%   $
��Left=�62   $	��Top=�6M    �� SelectedItem 5$      �� *SelectedModule+$
 TwoWay=���5%      ��  �� Path$ Modules�$
 TwoWay=���5&      �� 5'      .R�5(      ��  �� Orientation$ 
Horizontal=�6&   .+�5)       �� ��6*   �� *DisplayName+5*      5+      5-      �� 5.      -   5         ��Name$ textBox��5.      $	��200��6%   $ Autocomplete Box��61   $��0��5/      $��1��6$   $
��Left=�61   $	��Top=�6L   ��50      �� *Autocomplete+ �� UpdateSourceTrigger$ PropertyChanged=�.��6W   51      �� 52      -   5         ��Name$ resourceList��52      $	��200��6*   $ Selecting resource��66   $��0��53      $��2��6%   $
��Left=�62   $	��Top=�6M    54      �� *SelectedResource+$
 TwoWay=���55      �� $ FilteredResources�$
 OneWay=�.   (System.Windows.Interactivity.Interaction   Triggers 56      /   )System.Windows.Interactivity.EventTrigger  57         	EventName$ MouseDoubleClick��6%   .   (System.Windows.Interactivity.TriggerBase   Actions. 58      6   0System.Windows.Interactivity.InvokeCommandAction     Command 61   �� *CommandViewResource+59      ��5;      �� 5<      .R�5=      �� $ 
Horizontal=�6&   .+�5>       �� ��6*   �� *Name+5?      5@      5B      �� 5C      -   5        $ 	statusBox��5C      $	��200��6'   $ Status��63   {�.  $��0��5D      $��3��6$   $
��Left=�61   $	��Top=�6L   ��5E      �� *Status+$ PropertyChanged=�.��6Q   5F      �� 5G      $��2��5H      $��1��6"     DefaultTabControlItem#��[ 5I        DefaultTabItem#��[ 5J       5K      �� *SelectedTabItem+$
 TwoWay=���5L      �� *Tabs+$
 TwoWay=���5M      �� 5N      .R�5O      �� �� 5P       ��6*   �� *	TabName+5Q      5R       �� ContentTemplate 5T      �� 5U      .R�5[      �� ��6*   �� * TabContent.TabContentLayout[0]+5\      5^      5_      5`      