   M S B A M L   `   `   `  ����D  @testik4-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:testik4_5	testik4_5  5   	       testik4_5.AddingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:testik4_5     5   	     � Title$  AddingWindow��5   	   $	��648��6   $	��592��6+    � 	Resources 5	       �� 
TargetType 
  Adding �� Property �� Value  	TestEvent �� Triggers :� RoutedEvent �� TargetProperty g� Duration		 W� To
 g� AutoReverse��%�  &	        &	 n     �� 5
   
   " ��6   .�5      ��  � ��$
 0 12q�6'   �� 5       � ��$ 15(�6)   5      �� 5   
    5      :� 5      $ Button.Click��6   [�5      �� 5      .��5      �� .��5   "   W� $ Width�62   $ 0:0:1D�6T   $		 220X�6e   
 . 6n   W� 5   "   $ Height�62   $ 0:0:1D�6U   $	 80X�6f   
 . 6n   5      5      5      5      5      .��5      �  � RowDefinitions 5    
   �� 5!      $	��30* �6   �� 5"      $
��453* �6   �� 5#      $
��149* �6    � ColumnDefinitions 5&   
   �� 5'      $
��182* �6   �� 5(      $
��307* �6   �� 5)      $
��182* �6   .+�5+   
   �� $��0��6   $��3��6"   .+�5,      �� $��Добавление��6    �� TextAlignment$ Center=�6+   $��25(�6B   5-      �� 5/   
   $��0,70,0,0q�6   $��1��6'   $��1��64    �� Orientation$ 
Horizontal=�6D   .+�51      �� $ Vertical=�6   $��0��60   .+�52      �� #��[  6   $��Название��6<   �� 53      #��[  6   $��Картинка��6=   �� 54      #��[  6   $��Компания��6=   �� 55      #��[  6   $��Цена��6=   �� 56      #��[  6   $��Описание��6=   �� 57      #��[  6   $
��0 40q�6<   $��Рейтинг��6J   5:      �� 5;      $��15, 15,0 ,0q�6   $ Vertical=�6.   .+�5<      �� -   5         ��Name$ 
TitleFiled��5<      $	��100��6.   �� 5=      -   5        $ 
ImageFiled��5=      $��26q�6.   $	��100��6:   �� 5>      -   5        $ CompanyFiled��5>      $	��100��61   �� 5?      -   5        $ 
PriceFiled��5?      $
��0 26q�6.   $	��100��6<   �� 5@      -   5        $ DescriptFiled��5@      $��50��61   $	��100��6=   �� 5A      $ 
Horizontal=�6   $
��0 25q�66   .+�5B      �� -   5         ��Name$ 	RateFiled��5B      $��15 -5q�60   $	��100��6?    �� IsSelectionRangeEnabled .  � Minimum$ 0Q�6j    � Maximum$ 10Q�6v   �� 5C      $��10 -5q�6    ��60   ��  �� StringFormat$ {0:f0}�� �� ElementName$ 	RateFiled�� �� Path$ Value�5D      5F      5H      �� 5I   
   $��1��6   $��2��6%   $��Center=�62   $��0,33,0,0q�6O   $	��120��6a   .+�5K      �� $��50��6   $	��120��6!   #��[ 6-   $��0 0 0 15q�6P   $#��Кнопка-заглушка��6b   �� 5L      $��25��6   $	��100��6!   
����·�$��Добавить��6B   .  (System.Windows.Input.ApplicationCommands
   New#��Z 6U    J� CommandBindings 5M      )  #System.Windows.Input.CommandBinding  5N      -   5           Command$	 New��5N   %   63   5P      5Q      5S      5T      