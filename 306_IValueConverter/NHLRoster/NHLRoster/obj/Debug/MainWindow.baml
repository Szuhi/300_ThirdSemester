   M S B A M L   `   `   `  ����D  @NHLRoster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NHLRoster	NHLRoster  5   	       NHLRoster.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NHLRoster     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��449��6)    � 
ResizeMode$ NoResize=�65   .��5	      �  � 	Resources 5
   
   &    NHLRoster.StatusToBrushConverter   STB��%   &	          5      6+   5      .+�5   
   �� $
��Left=�6W   $	��299��6r   $��	10,10,0,0q�6   $	��Top=�6�   $	��177��6�   ��6   �� *Bench+ �� SelectedItem 60   �� *BenchSelected+��5      �� 5      .R�5      � $��140px��6   ��6)   �� *Status+ �� 	Converter# [   � ColumnDefinitions 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��0��69   $��0��6I   $
��80px��6V   ��6    �� *Name+6V   �� 5       �� ContentStringFormat$ {0} cm��6;   $��1��6Z   $��0��6j   ��6    �� *Height+6j   �� 5      $��0��6=   $��1��6M   $
��80px��6Z   ��6    �� *
Position+6Z   �� 5      $��1��6;   $��1��6K   ��6    �� *Status+6K   5      5      5!      �� 5"   
   $
��Left=�6W   $	��299��6r   $��
192,10,0,0q�6   $	��Top=�6�   $	��119��6�   ��6   �� *Field+ 60   �� *FieldSelected+��5#      �� 5$      .R�5%      ]� .+�5&      �� ��6    �� *Name+�� 5'      ��6    �� *
Position+5(      5)      5+      �� 5-   
   -   5        $	��ADD��5-   !   $
��Left=�6/   $��
316,10,0,0q�6J   $	��Top=�6^   $	��115��6v   �� 5.   
   -   5        $	��MOD��5.   !   $
��Left=�6/   $��
316,35,0,0q�6J   $	��Top=�6^   $	��115��6v   �� 5/   
   -   5        $��MOVE >>��5/   %   $
��Left=�6=   $��
316,60,0,0q�6X   $	��Top=�6l   $	��115��6�   �� 50   
   -   5        $��MOVE <<��50   %   $
��Left=�6=   $��
316,85,0,0q�6X   $	��Top=�6l   $	��115��6�   51      52      