   M S B A M L   `   `   `  ����D  @testik4-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:testik4_5	testik4_5  5   	   %clr-namespace:testik4_5	testik4_5  5   	       testik4_5.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:testik4_5     5   	   +controlclr-namespace:testik4_5     5   	   -   5           WindowStyle#���   5	   	     � Title$  
MainWindow��5
   	   $	��800��6   $	��800��6)    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:WindowCommands.Exit��5      6=     5   
   -   5        $* $local:WindowCommands.RoutedUICommand��5      6H    � 	Resources 5       �� 
TargetType �� Triggers ]� 
Conditions �� Property �� Value	 �� Property
 �� Value �� Binding �� ElementName �� Path �� Value �� 
TargetType  
btTemplate �� CornerRadius  BorderStyle��%}  '��       &	 t    �� 5   
   " ��6    5   
   ]� 5       5      �� 5       �@J�IsMouseOver . 6;   �� 5       � �� . 69   /�5      �� 5      	 � ��$
 20(�65   �� 5      	 � ��

 �����67   5      �� 5       6   �� $ DisableChBox��$ 	IsChecked� True6[   .a�5       �� 	 � {�
 .  62   5!      5#      �� 5%   
   " ��6   .R�5&      �� $ 25��6   
�������$��2q�6;   #���  5'      $��40��6;   $	��100��6G   $��0 10 0 0q�6S   ._�5(      �� $��5q�6"   $��Center=�6-   $��Center=�6J   $��Hello��6e   5)      5*      5,      .��5.      �  � ColumnDefinitions 50   
   �� 51      $	��77* �6   �� 52      $
��123* �6   .+�56   
   �� $��2��6   .��57      �� .+�58      �� $��10q�6   .+�59      ��   TextBlockStyle#���  6    $
��10 0q�6I   $��Язык��6W   �� 5:      -   5         ��Name$ LanguageComboBox��5:   G     ComboBoxStyle#���  6   $��0 5 0 10q�5;      5<      �� 5=      #���  6    $
��10 0q�6I   $��Тема��6W   �� 5>      -   5        $ StyleBox��5>   G   #���  6   6G   5?      � 5A       5B      �� 5C      $
��166* �6+   �� 5D      $
��382* �6+   �� 5E      $
��235* �6+    � RowDefinitions 5H      �� 5I      $
��50px �6(   �� 5J      �� 5K      .+�5N      �� $��0��6!   $��2��6.   $
��Left=�6B   $��	30 -5 0 0q�6]   .+�5O      �� -   5         ��Name$ UndoBttn��5O   @   $��Отменить��6!   $	��100��64   $��25��6�   $
��Undo��6�   ��6R   �� $ 	Text_From��6�   �� 5P      -   5        $ RedoBttn��5P   ?   $��Вернуть��6!   $	��100��63   $��25��6Q   $��0 5 0 0q�6�   $
��Redo��6�   ��6^   �� $ 	Text_From��6�   5Q      �� 5S      $
��20 0q�6!   $��1��6/   $��0��6?    �� Orientation$ 
Horizontal=�6L   .+�5T      �� $��25��6!   $	��100��6-   
����·�$��
назад��6N   .  (System.Windows.Input.ApplicationCommands   Undo#��Z 6^    5U        5V   "   -   5        $
 Undo��5V   1   6@   5X      �� 5Z      $��25��6!   $	��100��6-   
����·�$��вперед��6N      Redo#��Z 6_    5[        5\   "   -	   5        $
 Redo��5\   1   6@   5^      5_      �� 5b      $��	10,0,20,0q�6!   $��0��64   $��2��6A   $ 
Horizontal=�6Q   $��Right=�6j   .+�5c      �� -
   5         ��Name$ SearchField��5c   "   $	��120��67   $	��600��6F   $��20��6U   �� 5d      -   5        $��10 15q�5d   !   $��50��60     ButtonStyle#���  6;    
 Search#���  6b   6�   5e      �� 5f      $��5,0,5,0q�6"   $��1��63   .+�5g      �� .��5h      �� $��0��6)   $	��150��6:   .+�5i   "   ��  �� TextAlignment$ Center=�6-     Company#���  6D   �� 5j   "   -   5         ��Name$ Filter��5j   *   $��5q�6;   $��10q�6F     ListBoxStyle#���  6S   $��0q�6{   $��Disabled=�6�   $��Disabled=�6�   5l   #   �� 5m   "   $��Center=�6-   .+�5n   &   �� #���  60   $ Center=�6Y    	 Price_filter#��� 	 6p   �� 5o   &   $	��0 3q�61   $ 
Horizontal=�6>   .+�5p   *   �� #���  64   $��Center=�6]    
 
Price_From#��� 
 6z   �� 5q   *   -   5        $ 	Text_From��5q   K   $
��16 0q�62   $��50��6@   $��Center=�6_   6|   5r   '   �� 5s   &   $ 
Horizontal=�61   $	��0 5q�6J   .+�5t   *   �� #���  64   $��Center=�6^     Price_To#���  6|   �� 5u   *   -   5        $ Text_To��5u   2   $��Center=�6D   $
��15 0q�6a   $��50��6o   6z   5v   '   �� 5w   &   -   5        #���  5w   -   $��	25 0 25 0q�6S   $��20��6f    	 Reset#���  6s   6�   5x   #   5y      5{      �� 5}      $��0 15 0 0q�6%   .+�5~      ��   
ChBoxStyle#���  6'   $��Enable��6L   �� 5      -   5         ��Name$ DisableChBox��5   L   #���  6'   $��Disable��6b   �� 5�      -   5        #��[ 5�   %   6L   5�         testik4_5.UserControl1  5�      6/      testik4_5.UserControl2  5�      5�      �� 5�      $��2��6!   5�      �� 5�      $��
20 0 20 10q�6!   $��1��65   $��2��6E   $��1��6Y   .+�5�      �� -   5         ��Name$ sneakerList��5�   K     ListViewStyle#���  6#   $	��350��6a   $��Disabled=�6q   ��5�      �� 5�   "   .R�5�   &   �� $��5q�61   .+�5�   *   �� $	��100��60   $��75��6<   ��6H   �� *	ImagePath+ � ToolTip 5�   .   _� 5�   2   ���#2624AF
������� _� HasDropShadow .   _� 	Placement$ Relative=�5�        _� HorizontalOffset$  15��6&   ! _� VerticalOffset$! 10��6<   .��5�   6   �� .+�5�   :   �� ��6D   �� *Description+" �� StringFormat$" Описание: {0}���� 5�   :   ��6D   �� *Rating+$" Рейтинг: {0}��5�   7   5�   3   5�   +   �� 5�   *   $��12(�64   $��Center=�6Y   ��6B   �� *Title+6Y   �� 5�   *   $��12(�64   $��Center=�6y   ��6B   �� *	Company+$" Компания: {0}��6y   �� 5�   *   ��64   �� *Price+$" Цена: {0}BYN��5�   '   5�   #   ��5�      �� 5�   "   .R�5�   &   � 5�   #   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� -   5        $��Center=�5�   )   .+�5�   "   �� -   5        $ button1��5�   )   $��80��6:   $��50��6E   $��10q�6o   .��5�   &   �� -   5        $��label1��5�   ,   $��Bubbling��6:   6M   5�   #   5�      �� 5�      -   5        $��Center=�5�   )   .+�5�   "   �� -   5        $ button2��5�   )   $��80��6:   $��50��6E   $��10q�6v   .��5�   &   �� -   5        $��label2��5�   ,   $��	Tunneling��6:   6N   5�   #   5�      �� 5�      -   5        $��Center=�5�   )   .+�5�   "   �� -   5        $ button3��5�   )   $��80��6:   $��50��6E   $��10q�6q   .��5�   &   �� -   5        $��label3��5�   ,   $��Direct��6:   6K   5�   #   5�      �� 5�      -   5        $ button4��5�   8   $��очистить��6%   $��80��6I   $��50��6T   $��10q�6v   �� 5�      -   5        $ Button1��5�   %   $��80��66   $��30��6A   $��
Выход��6M   
�������$��local:WindowCommands.Exit��5�      �� 5�      -   5        $ Button2��5�   %   $��80��66   $��30��6A   $��RoutedUICommand��6M   
�������$*��$local:WindowCommands.RoutedUICommand��5�      5�      �� 5�      -   5        # ��Name$# 
textBlock1��5�   $   $ �� Padding$$ 10q�68   �� 5�      -    5        $ unvisibleTxtB��5�   "   $:��4Вы отобразили скрытый текст!��69   $��10q�6]   $y�Hidden=�6j   
�������6~   5�      �� 5�      $��2��6!   $��2��6.   $ 
Horizontal=�6>   $��Center=�6W   $��0,15,0,0q�6t   $	��217��6�   .+�5�      �� -!   5        #���  5�   !   $��25��6G   $��2 0 10 0q�6S     butt_delete#���  6e   6�   �� 5�      -"   5        #���  5�   !   $��25��6G   $��	10 0 10 0q�6S     butt_change#���  6f   6�   �� 5�      -#   5        #���  5�   !   $��25��6G   $��10,0,10,-0.2q�6S     butt_create#���  6i   $	��Top=�6�   5�      5�      5�      5�      5�      5�      