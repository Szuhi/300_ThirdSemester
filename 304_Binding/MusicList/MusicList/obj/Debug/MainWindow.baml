   M S B A M L   `   `   `  ����D  @MusicList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MusicList	MusicList  5   	       MusicList.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MusicList     5   	     � Title$  
MainWindow��5   	   $	��483��6   $	��421��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ 	lst_lists��5
      $
��Left=�6e   $	��178��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��393��6�   ��6%   �� *Lists+ �� SelectedItem 6C   �� *
Selected+6�   �� 5   
   $
��Left=�66   $	��197��6Q   $��
10,193,0,0q�6^   $	��Top=�6r   $	��393��6�    � DataContext 6   �� *
Selected+.+�5      ��  �� ContentStringFormat$ Fájl neve: {0}��61   ��6   �� *
FileName+61   �� 5      $ 
Címe: {0}��6-   ��6   �� *Name+6-   �� 5      $ Number of Songs: {0}��67   ��6   �� *PlayList.Count+67   5      �� 5   
   -   5        $��
Details...��5      $
��Left=�6&   $��148,395,0,0q�6A   $	��Top=�6V   $	��100��6n    J� RenderTransformOrigin$ 0.5,0.5&�6z   6�   5      5      