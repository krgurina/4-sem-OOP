   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:shop.Views.Adminshop.Views.Admin  5      =#clr-namespace:shop.ViewModels.Adminshop.ViewModels.Admin  64       shop.Views.AddProductView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:shop.Views.Admin     5      5admin#clr-namespace:shop.ViewModels.Admin     64   -   5          N� Title$  CategoriesView��5
      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��123* �6   .+�5   
   � $��0��6   .+�5      �� $��15, 15,0 ,0q�6    �� Orientation$ Vertical=�6.   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��15(�6    $��Название��6.   �� 5      -   5         ��Name$ ProductName��5      $	��217��63    J� RenderTransformOrigin$ 0.5,0.5&�6?   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��15(�6    $��Категория��6.   �� 5      $��30��6   $	��200��6+   ��67   �� *
Categories+ �� SelectedItem 6Z   �� *SelectedCategory+��5      �� 5      .R�5   "   �� $��0q�6B   $��Bottom=�6M   $��Center=�5   (   ��5   ,   �� *Name+5   (   5      5!      �� 5#      -   5        $ ProductCategoryName1��5#      $	��217��6S   $ 0.5,0.5&�6_   ��6<   �� *Title+6_   5$      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��15(�6    $��цена��6.   �� 5'      -   5        $ Price��5'      $	��217��6D   $ 0.5,0.5&�6P   ��6-   �� *Price+6P   5(      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��15(�6    $��рейтинг��6.   �� 5+      -   5        $ Rating��5+      $	��217��6F   $ 0.5,0.5&�6R   ��6.   �� *Rating+6R   5,      �� 5-      $ 
Horizontal=�6   .+�5.      �� $��15(�6    $��Описание��6.   �� 5/      -   5        $ ProductDescription��5/      $	��217��6W   $ 0.5,0.5&�6c   ��6:   �� *Description+6c   50      �� 51      $ 
Horizontal=�6   .+�52      �� $��15(�6    $��фото��6.   �� 53      -   5        $ ProductImageLink��53      $	��217��6S   $ 0.5,0.5&�6_   ��68   �� *	ImageLink+6_   54      �� 55      -   5        $��добавить��55      $
��0 10q�6g   ��6,   �� *AddProductCommand+6g   �� 57      -	   5        $��удалить��57      $
��0 10q�6G   �� 59      $ 
Horizontal=�6   .+�5:      �� -
   5        $ SearchRequest��5:      $	��200��6]   $��10q�6i   �� 5;      $��
поиск��6   5=      5>      5A      � 5D   
   $��1��6   .+�5E      &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsGrid��5E         AutoGenerateColumns .     
IsReadOnly . 	   Columns	 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *ID+  5H      $
 TITLE��6)   $ * 68    6B   �� *TITLE+  5I      $
 CATEGORY��6)   $ * 6;    6E   �� *
CATEGORY+  5J      $
 PRICE��6)   $ * 68    6B   �� *PRICE+  5K      $
 PTING��6)   $ * 68    6B   �� *PTING+  5L      $
 DISCRIPTION��6)   $ * 6>    6H   �� *DISCRIPTION+5N      5W      5Z      5[      