   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   "    WpfPresentationLayer.AdminUI   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  AdminUI��5   	   $	��350��6   $	��400��6&   .��5	      �  � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      $��50 �6   �� 5      $��20 �6   �� 5      .+�5   
   o� .@�5      m� $
��File��6   .@�5      m� -   5        $��mnuQuit��5      $
��Quit��6*   5      5      � 5   
   $��2��6   #��� ��6   �� 5   
   -   5        $��tabAdmin��5      $��2��6%   .@�5      �� -   5        $��	tabMovies��5      $��Movies��6'   $
��Left=�67   $��20��6R   $��0q�6^   $
��Auto��6i   $	��Top=�6v   �� 5      -   5        $��tabGames��5      $��Games��6&   $
��Left=�65   $��20��6P   $��0q�6\   $
��Auto��6g   $	��Top=�6t   5      �� 5   
   -   5        $��	btnRemove��5      $��3��6   $��Remove��6/   $��0q�6@   $��8(�6L   $��50 200 275 15q�6Y   �� 5    
   -   5        $��btnAdd��5       $��3��6   $	��Add��6,   $��0q�6:   $��8(�6F   $��160 200 165 15q�6S   �� 5!   
   -   5        $��btnCreateOrder��5!      $��3��6   $��Create Order��65   $��0q�6L   $��8(�6X   $��270 200 50 15q�6e   �� 5"   
   -   5         ��Name$ 	btnLogout��5"      $��Log Out��6$   $��2��66   $��	340 0 0 0q�6C   $��0q�6V   $��8(�6b   �� 5%   
   -	   5         ��Name$ lblLazerShark��5%      $��1��6'   $��Lazer Shark��64   $��22(�6J   $��80 5 0 0q�6X   
������ $��Ravie)�6�   ���	#FFEC2424��5&      �� 5'       �� Color# � ��6"   5)      � 5*   
   $��1��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0 q�6i   ��5+      �� 5,       �� ImageSource$ yF:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   5.      �� 5/   
   -
   5         ��Name$ lstMoviesGames��5/      $��3��6*   $��30 20 30 140q�67   $��Visible=�6M   �� 50   
   -   5        $ lstReserveMoviesGames��50      $��3��61   $��30 100 30 80q�6>   $��Visible=�6T   ��51   
   �� 52       �� EndPoint$ 0.5,1&�6"   	 �� 
StartPoint$	 0.5,0&�63   .��53      � 
 � Color$
 Black��6   � 54      $
 	#FF71B5EE��6    � Offset$ 0.289Q�61   55      59      5:      