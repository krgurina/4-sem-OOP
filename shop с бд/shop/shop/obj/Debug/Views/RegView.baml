   M S B A M L   `   `   `  ����?  ;shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:shop.Views
shop.Views  5      1clr-namespace:shop.ViewModelsshop.ViewModels  6.       shop.Views.RegView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:shop.Views     5      4
viewmodelsclr-namespace:shop.ViewModels     6.     N� Title$  RegView��5	      .��5      � 
�������.+�5   
   �� $��15q�6    �� Orientation$ Vertical=�6!   $��Center=�68   $	��320��6U   .+�5      �� $��logo.svg��6   $	��180��6&   $	��155��62   $��10q�6?   �� 5      $ 
Horizontal=�6   $
��15 0q�63   .+�5      �� $��15(�6   $��login��6*   $��Center=�67   $��0 0 79 0q�6T   �� 5      -   5         ��Name$ login��5      $	��175��6@   ��6)   �� *Login+6@   5      �� 5      $ 
Horizontal=�6   $
��15 5q�63   .+�5      �� $��15(�6   $��userName��6*   �� 5      -   5        $ userName��5      $	��175��6B   $��Right=�6N   ��6,   �� *Name+6N   5      �� 5      $ 
Horizontal=�6   $
��15 0q�63   .+�5      �� $��15(�6   $��userSurname��6*   �� 5      -   5        $ userSurname��5      $	��175��6H   ��6/   �� *	Surname+6H   5      �� 5      $ 
Horizontal=�6   $
��15 5q�63   .+�5      �� $��15(�6   $��	userEmail��6*   �� 5      -   5        $ 	userEmail��5      $	��175��6D   ��6-   �� *Email+6D   5       �� 5"      $ 
Horizontal=�6   $
��15 0q�63   .+�5#      �� $��15(�6   $��	userPhone��6*   �� 5$      -   5        $ 	userPhone��5$      $	��175��6D   ��6-   �� *Phone+6D   5%      �� 5&      $ 
Horizontal=�6   $
��15 5q�63   .+�5'      �� $��15(�6   $��password��6*   $��0 0 50 0q�6:   �� 5(      -   5        $ password��5(      $	��175��6l   ��6-   �� *
Password+ �� UpdateSourceTrigger$ PropertyChanged=�6l   5)      �� 5*      $ 
Horizontal=�6   $
��15 0q�63   .+�5+      �� $��15(�6   $��password��6*   $��0 0 50 0q�6:   �� 5,      -   5        $ 	password2��5,      $	��175��6m   ��6.   �� *
Password+$ PropertyChanged=�6m   5-      �� 5/      -   5        $*��$зарегистрироваться��5/      $��10q�6j   ��62   �� *RegUserCommand+6j   51      5?      5@      