   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   #    WpfPresentationLayer.CheckOut   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  CheckOut��5   	   $	��400��6   $	��500��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF71B5EE��6    � Offset$ 0.719Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5"   
   �� $��1��6   $��2��6   $��Rental Confirmation��61   $��Center=�6O   $��20(�6l   $��Center=�6z   $��0q�6�   $
��Bold"�6�   ��5#      �� 5$       �� Color$ 	#FF0B78B6��6"   5&      �� 5'   
   -   5        	 ��Name$	 lstConfirmation��5'      $��2��6+   $��2��68   $��3��6L   $��100 0 100 0 q�6]   �� 5(   
   $��5��6   $��2��6   $��Total:��61   $��150 0 200 15q�6B   $��14(�6X   �� 5)   
   -   5        
 ��Name$
 txtTotal��5)      $��5��6$   $��2��61   $��190 5 200 20q�6E   $��0q�6[    �� 
IsReadOnly . $��14(�6�   ��6g   Z� ��6~   Z� 6�   �� 5*   
   -   5         ��Name$ 	btnCancel��5*      $��0��6$   $��6��64   $��
100 5 30 5q�6A   $��Cancel��6U   6f   �� 5+   
   -   5        $ 
btnConfirm��5+      $��1��6%   $��6��65   $��
30 5 100 5q�6B   $��Confirm��6W   6i   � 5-   
   $��0��6   $��2��6   $��65��60   $��75��6<   $
��Left=�6G   $��Center=�6b   $��0 5 0 0q�6}   ��5.      �� 5/       �� ImageSource$q kD:\DotNetII\LazerShark\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   51      �� 52   
   -   5         ��Name$ lblLazerShark��52      $��2��6'   $��0��6;   $��Lazer Shark��6H   $��22(�6^   $��Center=�6l   
������ $��Ravie)�6�   ���	#FFEC2424��53      �� 54      # � ��6"   56      57      58      