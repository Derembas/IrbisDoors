   M S B A M L   `   `   `  ����E  ACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Calculator.WindowsCalculator.Windows  5   	   ?$clr-namespace:Calculator.BaseClassesCalculator.BaseClasses  5   	   #    Calculator.Windows.DoorWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Calculator.Windows     5   	   5base$clr-namespace:Calculator.BaseClasses     5   	     � Title$  
DoorWindow��5
   	    � SizeToContent$ Height=�5   	    � 
ResizeMode$ NoResize=�5   	   $	��800��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $'��!Основные свойства��6   $��5q�6.   .��5      �� ��6   ��  �� Path$ MainProperties.Properties���5      �� 5      .R�5      � $��5q�6    5      �� 5   "   $
��auto �60   �� 5   "   .+�5!      �� $��Center=�6C   ��6(   �� $
 Name�6C   �� 5"      $��1��6A      PropertyControlStyle#��[  6N   ��6-   �� 6N   5#      5$      ��5&      �� 5'      .R�5(      ��  �� Orientation$ 
Horizontal=�6%   5)      5+      5,      9� 5/   
    9� 
IsExpanded . $��1��6%   ��50      �� 51      $ 
Horizontal=�6   .+�52      �� $$��Основные опции - ��6    �� 53      ��6    �� $ OptionsCount��� 54      $�� шт.��6    55      .��57      � $	��Top=�6    � ColumnDefinitions 58      �� 59      $	��200��6'   $��2* �66   �� 5:      $
��auto �6'   �� 5;      $	��200��6'   $��3* �66   .+�5>      � $	��250��6    5?      �� 5@      �� 5A      $
��auto �6(   .+�5D      �� $��
Опции��6   .��5G      �� -   5        $��
OptionList��5H      $��0q�6,   $��0q�6@   ��5G   "   �� $ EnabledOptions� �� SelectedItem 5I   "   �� $ SelectedOption���5J      �� 5K   "   .R�5L   &   �� ��60   �� $
 Name�5M   #   5O      5P      A� 5R      $��1��6"   	 A� Columns$	 2��6/   .+�5S      �� $��Добавить��6!   ��64   �� $ AddNewOptionCommand��� 5T      $��Удалить��6!   ��63   �� $ DelOptionCommand�5U      5V      �� 5X      $��1��6   $��3��6/   $��Stretch=�69   $��Stretch=�6W   �� 5Z      $!��Список свойств��6   $��2��63   .��5[      �� ��5\      �� 
 �� ElementName$
 
OptionList��$ SelectedItem.Properties���5^      �� 5_      .R�5`   "   �  5a   &   �� 5b   *   $	��150 �6;   �� 5c   *   .+�5f   &   �� ��60   �� $
 Name��� 5g   &   $��1��6I   #��[  6Y   ��65   �� 6Y   5h   #   5i      5k      5l      5p      5q      9� 5t   
   $-��'Дополнительные опции��6   $��2��61   9� 5w   
   $��Примечание��6   $��3��6'   �� 5z   
   $��Применить��6   $��4��6%   5{      5|      