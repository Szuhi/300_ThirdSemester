   M S B A M L   `   `   `  ����@  <Pizza, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PizzaPizza  5   	       Pizza.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Pizza     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� $
��Left=�6V   $	��211��6q   $��	10,10,0,0q�6~   $	��Top=�6�   $	��209��6�   ��6   �� *Items+ �� SelectedItem 60   �� *SelectedItem+��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $��140px �6/   �� 5      .+�5      �� $��0��69   ��6    �� *Name+69   �� 5       �� ContentStringFormat$ {0} USD��6:   $��1��6Z   ��6    �� *Price+6Z   5      5      5      �� 5   
   $��224,10,10,0q�66   $	��211��6K   $	��Top=�6X   ��6   �� *Extras+��5      �� 5      .R�5      �  5      �� 5      $
��20px �6/   �� 5      $
��80px �6/   �� 5      .+�5!      �� $��0��6>    d� 	IsChecked 6#   �� *Prop+6>   �� 5"      $��1��69   ��6    �� *Name+69   �� 5#      $ {0} Ft��6:   $��2��6Y   ��6    �� *Price+6Y   5$      5%      5'      �� 5(   
   -   5        $��
Select All��5(   '   $
��Left=�6<   $��392,226,0,0q�6W   $	��Top=�6l   $	��115��6�   �� 5)   
   $��32(�6   $ {0} USD��6<   $
��Left=�6\   $��
10,226,0,0q�6w   $	��Top=�6�   ��6   �� *	FullPrice+6�   5+      5,      