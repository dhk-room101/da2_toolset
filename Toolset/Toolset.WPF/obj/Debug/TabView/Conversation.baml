   M S B A M L   `   `   `  ����G  CMVVMSidekick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekickMVVMSidekick.Views  5   	   F BToolset.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Toolset.WPF.Core.ConvertersToolset.WPF.Core.Converters 5   	   9!clr-namespace:Toolset.WPF.TabViewToolset.WPF.TabView 5   	   ]>clr-namespace:MVVMSidekick.Patterns.Tree;assembly=MVVMSidekickMVVMSidekick.Patterns.Tree  5   	   &    Toolset.WPF.TabView.Conversation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Gmvvm6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekick     5   	   @
converters)clr-namespace:Toolset.WPF.Core.Converters     5   	   0vm!clr-namespace:Toolset.WPF.TabView     5   	   Spatterns>clr-namespace:MVVMSidekick.Patterns.Tree;assembly=MVVMSidekick     5   	     � 	Resources  5      ,  &Toolset.WPF.TabView.Conversation_Model   ConversationVM5  /Toolset.WPF.Core.Converters.PercentageConverter  PercentageConverterG  AToolset.WPF.Core.Converters.ConversationNodeStateToBrushConverter ) %ConversationNodeStateToBrushConverterF  @Toolset.WPF.Core.Converters.ConversationNodeFlagToImageConverter ( $ConversationNodeFlagToImageConverter��%t   &	        &	      &	 &     &	 9       5	   
   6      5
   
   6)     5   
   6;     5   
   6:   5      .��5      � -   5         �Name$
 grid��5       � DataContext# [  6   ��5      ��  �� 	Converter# [  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� Path$ ActualWidth� �� ConverterParameter$ 0.9925�� � RowDefinitions 5      �� 5      ��6   �� # [  �� *FindAncestor+" ��$ ActualHeight�$
 0.66���� 5      $��* �6   .+�5      R� -   5        $��0��5      $��0��6%   ��5      �� *	RootNodes+��5!      �� 5"      	 �� 
TargetType"	 Q�6   .�5#      �� 
 �� Property
 �@Q�
IsExpanded �� Value 68   �� *State.IsExpanded+ �� Mode$ TwoWay=��� 5$      
 �@Q�
IsSelected 68   �� *State.IsSelected+$ TwoWay=��� 5%      
 � ��$ 16(�66   �� 5&      
 � ��$ Segoe UI)�68   �� 5'      
 � �� �	#FF99999968   �� 5(      
 � ��$ Normal"�68    �� Triggers 5)      P� 5*        P� Property �@Q�
IsSelected P� Value . . �5+   %   �� 
 � ��$
 Bold"�6B   5,   !   5.        50       �� DataType  Toolset.WPF.TabView.Node �� ItemsSource �� Orientation��%L  (��       51   +   *, +)7  7  �� 6   "  6+    6G   �� *
Children+.R�52      �� $ 
Horizontal=�6&   .+�53       �� $��16��6&   $��16��54   &   $	��3,0q�55   &   ��56   &   �� *
IsNodeFlag+8   �� 58       ��6*   �� *Value+$ OneWay=���59       �� *
IsNodeType+8  5;      5<      5=      5>      �� 5?      $��0��6   $��1��6'   .+�5@      � -   5        $ flags��5@       5A      �� 5B      $��40 �6)   �� 5C      $��* �6)   �� 5D      $��* �6)    � ColumnDefinitions 5F      �� 5G      ��6,   �� # [  �� *FindAncestor+" ��$ ActualWidth�$
 0.50���� 5M      $��* �6,   .+�5O      �� $��5q�6    $��0��6+   $��0��6;   $��	Condition��6H   �� 5P      $��5q�6    $��0��6+   $��1��6;   ��6H   �� *SelectedNodeConditionPlotName+�� 5Q      $��5q�6    $��0��6+   $��2��6;   ��6H   �� *$"SelectedNodeConditionPlotFlagIndex+�� 5R      $��5q�6    $��1��6+   $��0��6;   $��Action��6H   �� 5S      $��5q�6    $��1��6+   $��1��6;   ��6H   �� *SelectedNodeActionPlotName+�� 5T      $��5q�6    $��1��6+   $��2��6;   ��6H   �� *!SelectedNodeActionPlotFlagIndex+5U      5V      5W      5X      