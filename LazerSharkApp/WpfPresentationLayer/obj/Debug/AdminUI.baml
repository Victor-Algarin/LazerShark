   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   "    WpfPresentationLayer.AdminUI   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  AdminUI��5   	   $	��450��6   $	��700��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      $	��100 �6   .+�5    
   o� $��4��6   .@�5!      m� $
��File��6   .@�5"      m� -   5        $��mnuQuit��5"      $
��Quit��6*   5#      5$      �� 5'   
   -   5        $��btnRemoveMovie��5'   ?   $��3��6   $��2��6   $��3��6/   $��Remove��6U   $��0q�6f   $��8(�6r   $��10 50 10 10q�6   6�   �� 5(   
   -   5        $��btnRemoveGame��5(   ?   $��7��6   $��2��6   $��3��6/   $��Remove��6T   $��0q�6e   $��8(�6q   $��10 45 10 15q�6~   6�   �� 5)   
   -   5        $��btnOrder��5)   0   $��10��6   $��3��6    $��Create Order��6@   $��0q�6W   $��8(�6c   $��10 10 10 10q�6p    �� 	IsDefault . 6�   �� 5*   
   -   5         ��Name$ 	btnLogout��5*      $��Log Out��6$   $��10��66   $��2��6D   $��100 10 5 10q�6T   $��0q�6i   $��8(�6u    �� IsCancel . 6�   �� 5.   
   $��Movies in Kiosk#: 100000��6   $��0��63   $��3��6C   $��	25 0 0 20q�6P   $��0q�6c   $
��Bold"�6o   �� 5/   
   $��Games in Kiosk#: 100000��6   $��0��62   $��6��6B   $��	25 20 0 0q�6O   $��0q�6b   $
��Bold"�6n   �� 50   
   -   5         ��Name$ lstMovieList��50      $��3��6(   $��3��66   $��0��6G   $��3��6W   $��	25 20 5 0q�6k   $��Visible=�6~   �� 51   
   -   5        $ lstGameList��51      $��7��6'   $��3��64   $��0��6E   $��3��6U   $��	25 0 5 20q�6j   $��Visible=�6}   �� 55   
   -   5         ��Name$ lblLazerShark��55      $��4��6'   $��1��6;   $��Lazer Shark��6H   $��32(�6^   $��Center=�6l   
������ $��Ravie)�6�   ���	#FFEC2424��56      �� 57      	 �� Color#	 � ��6"   59      � 5:   
   $��1��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0 q�6i   ��5;      �� 5<      
 �� ImageSource$
 yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   5>      ��5?   
   �� 5@       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5A      �  � Color$ Black��6   � 5B      $ 	#FF71B5EE��6    � Offset$ 0.458Q�61   5C      5G      5H      