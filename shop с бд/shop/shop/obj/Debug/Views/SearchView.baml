   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  5          shop.Views.SearchView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      3	viewModelclr-namespace:shop.ViewModels     5        N� Title$  
SearchView��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��100��6   �� 5      $��3* �6   .+�5   
   �� $��0��6   $��0��6%   фильтры6<   �� 5   
   $��0��6   $��1��6%    �� Orientation$ Vertical=�62   ���#7E2898.+�5      �� $��Категории��6   �� 5       $	��100��6e   $��1q�6u   
���������6   �� *
Categories+ �� SelectedItem 6;   �� *SelectedCategory+��5!      �� 5"      .R�5#      �� $��0q�6:   $��Bottom=�6E   $��Center=�5$   (   ��5#   $   �� *Name+5$   (   5%      5'      �� 5)      $��цена��6   �� 5*      �� 5.      $ 
Horizontal=�6   .+�50      �� $ 
Horizontal=�6   $��0 0 20 0q�66   $��60��6H   .+�51      �� $
��от��6    $��0 0 10 0q�6*   �� 52      $��Center=�68   $��60��6S   
���   �$��1q�6r   ��6   �� *
MinValue+6r   53      �� 55      $ 
Horizontal=�6   $��60��66   .+�56      �� $
��до��6    $��0 0 10 0q�6*   �� 57      $��Center=�68   $��60��6S   
���   �$��1q�6r   ��6   �� *
MaxValue+6r   59      5;      �� 5<      $ 
Horizontal=�6   $��	0 20 0 10q�62   .+�5=      �� $��Найдено:��6   �� 5>      $��Center=�6`   $��60��6{   ��6   �� *ProductsCount+ �� UpdateSourceTrigger$ PropertyChanged=�6{   �� 5?      $��Center=�6a   $��60��6|   ��6   �� *ProductsCount+$ PropertyChanged=�6|   5@      �� 5A      -   5         ��Name$ 	SortOrder��5A      $	��100��6|   $��1q�6�   
�������$��0 10 0 0q�6�    �� SelectedIndex 6*   �� *SelectedSortIndex+ 6V   �� *SelectedSort+.@�5B      �� -   5         ��Name$ PriceAsc��5B   =   $*��$По возрастанию цены��6   6=   �� 5C      -   5        $ PriceDsc��5C   :   $$��По убыванию цены��6   6:   �� 5D      -   5        $ 	RatingAsc��5D   5   $��По рейтингу��6   65   5E      �� 5G      -   5        	 ��Name$	 UseFilterBtn��5G      $��Применить��6+   $��0 50 0 0q�6a   ��6?   �� *FilterCommand+6a   �� 5H      -   5        $	 AllProductBtn��5H      $*��$Показать все товары��6,   $
��0 10q�6m   ��6J   �� *ShowAllCommand+6m   5J      �� 5M   
   $��0��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   .+�5N      �� -   5        
 ��Name$
 	SearchTxB��5N      $	��400��6H   $��10q�6W   ��6)   �� *textForSearch+6W   �� 5O      -   5        $	 	SearchBtn��5O      $��Search��6J   ��6(   �� *SearchCommand+6J   5P      �� 5R      -	   5         ��Name$ productList��5R   ]   $��1��6@   $��1��6M   $	��491��6�   $	��700��6�   $��Disabled=�6�    6   �� *SelectedProduct+��6r   �� *
Products+$ PropertyChanged=���5S      �� 5T      .R�5U      �� $ Vertical=�6%   $��5q�6<   .+�5V      �� $	��200��6$   $	��200��60   $��Center=�6Z   ��6=   �� *	ImageLink+6Z   �� 5W      $ Vertical=�6)   $
��Left=�6@   .+�5X   "   �� $��12(�6,   $��Center=�6Q   ��6:   �� *Title+6Q   �� 5Y   "   ��6,   �� *Price+ �� StringFormat$ {0} BYN��5Z      �� 5[      $	 InCard��6%   $��В корзину��65   $	��200��6�   $��0 20 0 0q�6�   ��6I   ��  �� ElementName$ productList�� �� Path$ DataContext.AddToCart�6�   5\      5]      ��5`      �� 5a      .R�5b      �  � Orientation$ 
Horizontal=�6$   $��Center=�6=   $��15q�6Z   5c      5e      5      5�      