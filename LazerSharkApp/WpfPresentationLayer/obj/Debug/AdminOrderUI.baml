   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   '    !WpfPresentationLayer.AdminOrderUI   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  AdminOrderUI��5   	   $	��450��6   $	��750��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   o� $��4��6   .@�5      m� $
��File��6   $��Center=�6%   .@�5       m� -   5        $��mnuQuit��5       $
��Quit��6*   5!      5"      �� 5$   
   $��CJ Media Supply��6   $��4��6*   $��0q�67   $
��Bold"�6C   $��10 10 55 10q�6U   �� 5%   
   $��Wholesale Media��6   $��5��6*   $��0q�67   $
��Bold"�6C   $��10 10 55 10q�6U   �� 5&   
   $*��$Da Electronic Entertainment Supplier��6   $��6��6@    �� Padding$ 0q�6M   $
��Wrap=�6Y   $
��Bold"�6m   $��	10 0 30 0q�6   	� 5(   
   -   5         	�Name$ radCJ��5(      $��4��6%   $��
155 12 0 0q�62   6F   	� 5)   
   -   5        $ radWholeSale��5)      $��5��6,   $��
155 12 0 0q�69   6M   	� 5*   
   -   5        $ radDa��5*      $��6��6%   $��
155 12 0 0q�62   6F   �� 5,   
   -   5         ��Name$ 	btnLogOut��5,      $��9��6$   $��3��61   $��Log Out��6A   $��
10 10 60 0q�6S   $��0q�6g   6s   �� 5-   
   -   5        $ btnAdd��5-      $��9��6!   $��2��6.   $��Add To Kiosk��6>   $��
30 10 30 0q�6U   $��0q�6i   6u   �� 5.   
   -   5        $ 	btnCancel��5.      $��9��6$   $��1��61   $��Cancel��6A   $��
60 10 10 0q�6R   $��0q�6g    �� IsCancel . 6�   �� 50   
   $��Movies��6   $��2��6!   $��1��6.   $��0q�6>   $��20 20 100 0q�6J   $
��Bold"�6_   �� 51   
   $��Games��6   $��6��6    $��1��6-   $��0q�6=   $��20 0 100 20q�6I   $
��Bold"�6^   �� 54   
   -   5         ��Name$ 	lstMovies��54      $��1��6%   $��3��65   $��3��6I   $��3��6V   $��
20 0 15 20q�6g   $��Visible=�6{   �� 55   
   -	   5        $ lstGames��55      $��1��6$   $��3��64   $��6��6H   $��3��6U   $��
20 20 15 0q�6f   $��Visible=�6z   �� 58   
   -
   5        	 ��Name$	 lblLazerShark��58      $��4��6'   $��1��6;   $��Lazer Shark��6H   $��22(�6^   $��Center=�6l   
������ $��Ravie)�6�   ���	#FFEC2424��59      �� 5:      
 �� Color#
 � ��6"   5<      � 5=   
   $��1��6   $��4��6   $��65��61   $��75��6=   $
��Left=�6H   $��Center=�6c   $��0 5 0 0 q�6~   ��5>      �� 5?       �� ImageSource$ yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   5A      ��5B   
   �� 5C       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5D      �  � Color$ Black��6   � 5E      $ 	#FF71B5EE��6    � Offset$ 0.474Q�61   5F      5H      5I      