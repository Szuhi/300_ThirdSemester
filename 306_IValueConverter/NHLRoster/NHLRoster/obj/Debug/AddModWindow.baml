   M S B A M L   `   `   `  ����D  @NHLRoster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NHLRoster	NHLRoster  5   	       NHLRoster.AddModWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NHLRoster     5   	     � Title$  AddModWindow��5   	   $	��229��6   $	��300��6+    � 
ResizeMode$ NoResize=�67   .��5	      �  � 	Resources 5
   
   $   NHLRoster.IntToHeightConverter   ITM��%   &	          5      6)   5      .+�5   
   �� $
��Name��6   $
��Left=�6   $��	10,10,0,0q�6:   $	��Top=�6M   �� 5   
   $��Height��6   $
��Left=�6!   $��	10,41,0,0q�6<   $	��Top=�6O   �� 5   
   $��Status��6   $
��Left=�6!   $��	10,72,0,0q�6<   $	��Top=�6O   �� 5   
   $��Position��6   $
��Left=�6#   $��
10,103,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ txtname��5      $
��Left=�6#   $��23��6>   $��	78,13,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6�   $	��204��6�   ��6q   �� *Name+ �� UpdateSourceTrigger$ Explicit=�6�   �� 5   
   -   5        $ 	txtheight��5      $
��Left=�6%   $��23��6@   $��	78,45,0,0q�6L   $
 Wrap=�6_   $	��Top=�6�   $	��204��6�   ��6s   �� *Height+$ Explicit=� �� 	Converter# [  6�   �� 5   
   -   5         ��Name$ 	cmbstatus��5      $
��Left=�6&   $��	78,76,0,0q�6A   $	��Top=�6T   $	��204��6l    �� SelectedItem 6x   �� *Status+$ Explicit=���6�   �� *	AllStatus+�� 5   
   -   5        $ cmbposition��5      $
��Left=�6(   $��
78,103,0,0q�6C   $	��Top=�6W   $	��204��6o    6{   �� *
Position+$ Explicit=���6�   �� *AllPosition+�� 5   
   -   5        $��OK��5       $
��Left=�6-   $��
78,146,0,0q�6H   $	��Top=�6\   $��75��6t   �� 5   
   -   5        $��Cancel��5   $   $
��Left=�65   $��177,146,0,0q�6P   $	��Top=�6e   $��75��6}   5      5      