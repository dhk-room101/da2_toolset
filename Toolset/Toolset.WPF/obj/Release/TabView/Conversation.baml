   M S B A M L   `   `   `  ���� G  CMVVMSidekick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekickMVVMSidekick.Views  F BToolset.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Toolset.WPF.Core.ConvertersToolset.WPF.Core.Converters 9!clr-namespace:Toolset.WPF.TabViewToolset.WPF.TabView ]>clr-namespace:MVVMSidekick.Patterns.Tree;assembly=MVVMSidekickMVVMSidekick.Patterns.Tree  &    Toolset.WPF.TabView.Conversation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Gmvvm6clr-namespace:MVVMSidekick.Views;assembly=MVVMSidekick     @
converters)clr-namespace:Toolset.WPF.Core.Converters     0vm!clr-namespace:Toolset.WPF.TabView     Spatterns>clr-namespace:MVVMSidekick.Patterns.Tree;assembly=MVVMSidekick       � 	Resources  ,  &Toolset.WPF.TabView.Conversation_Model   ConversationVM5  /Toolset.WPF.Core.Converters.PercentageConverter  PercentageConverterG  AToolset.WPF.Core.Converters.ConversationNodeStateToBrushConverter ) %ConversationNodeStateToBrushConverterF  @Toolset.WPF.Core.Converters.ConversationNodeFlagToImageConverter ( $ConversationNodeFlagToImageConverter��%<   &	        &	      &	 
     &	              .��� -    �Name$
 grid�� � DataContext# [  ����  �� 	Converter# [  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� Path$ ActualWidth� �� ConverterParameter$ 0.9925�� � RowDefinitions �� ���� # [  �� *FindAncestor+" ��$ ActualHeight�$
 0.66���� $��* �.+�R� -   $��0��$��0������ *	RootNodes+���� 	 �� 
TargetType"	 Q�.��� 
 �� Property
 �@Q�
IsExpanded �� Value �� *State.IsExpanded+ �� Mode$ TwoWay=��� 
 �@Q�
IsSelected �� *State.IsSelected+$ TwoWay=��� 
 � ��$ 16(��� 
 � ��$ Segoe UI)��� 
 � �� �	#FF999999�� 
 � ��$ Normal"� �� Triggers P�  P� Property �@Q�
IsSelected P� Value . . ��� 
 � ��$
 Bold"�   �� DataType  Toolset.WPF.TabView.Node �� ItemsSource �� Orientation��%�   (��       *, +)7  7  �� "   �� *
Children+.R��� $ 
Horizontal=�.+��� $��16��$��16��$	��3,0q����� *
IsNodeFlag+8   �� ���� *Value+$ OneWay=����� *
IsNodeType+8  �� $��0��$��1��.+�� -   $ flags�� �� $��40 ��� $��* ��� $��* � � ColumnDefinitions �� ���� # [  �� *FindAncestor+" ��$ ActualWidth�$
 0.50���� $��* �.+��� $��5q�$��0��$��0��$��	Condition���� $��5q�$��0��$��1������ *SelectedNodeConditionPlotName+�� $��5q�$��0��$��2������ *$"SelectedNodeConditionPlotFlagIndex+�� $��5q�$��1��$��0��$��Action���� $��5q�$��1��$��1������ *SelectedNodeActionPlotName+�� $��5q�$��1��$��2������ *!SelectedNodeActionPlotFlagIndex+