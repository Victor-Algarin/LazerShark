   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	        WpfPresentationLayer.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	   -   5          � Title$  Login��5   	   $	��300��6   $	��350��6$    � WindowStartupLocation$ CenterScreen=�6G   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF71B5EE��6    � Offset$ 0.289Q�61   5       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   � $��5��6    � ColumnDefinitions 5      �� 5      �� 5       5"      �� 5%   
   -   5         ��Name$ txtUsername��5%      	 �� 	MaxLength$	 20��6'   
 �� MaxLines$
 5��66   $��2��6C   $��1��6P   $
��75 5q�6`   G� 5&   
   -   5         G�Name$ txtPassword��5&      $��4��6+   $��1��68   $
��75 5q�6I   �� 5'   
   -   5         ��Name$ lblPassword��5'      $��
Password: ��6%   $��3��6:   $��
70 7 75 0 q�6G   �� 5(   
   -   5         ��Name$ 	btnSignIn��5(      $��Sign In��6$   $��6��66   $
��75 3q�6C    �� 	IsDefault . 6i   �� 5)   
   -   5        $ lblUsername��5)      $��
Username: ��6%   $��1��6:   $��	70 7 75 0q�6G   �� 5+   
   -   5        $��btnCreateAccount��5+      $��Create Account��6)   $��5��6B   $��0��6O   $��
60 0 170 0q�6_   $��0 1 0 1q�6s   $��12(�6�   ��6�   Z� ��6�   Z� 6�   �� 5,   
   -   5        $ btnChangePassword��5,      $��Change Password��6,   $��5��6F   $��1��6S   $��
170 0 65 0q�6c   $��1 0 1 0q�6w   $��12(�6�   ��6�   Z� ��6�   Z� 6�   � 5-   
   $��0��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0q�6i   ��5.      �� 5/       �� ImageSource$ yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   51      �� 52   
   -	   5        $ lblLazerShark��52      $��0��6'   $��Lazer Shark��64   $��22(�6J   $��80 5 0 0q�6X   
������ $��Ravie)�6�   ���	#FFEC2424��53      �� 54       �� Color# � ��6"   56      58      59      