   M S B A M L   `   `   `  ����  WpfPresentationLayer)    #WpfPresentationLayer.ChangePassword   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ChangePassword��5   	   $	��400��6    $	��300��6-    � WindowStartupLocation$ CenterScreen=�69   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5	      $ 	#FF71B5EE��6   $ 0.185Q�61   5
       � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��lblLogin��5      $��1��6   $,��&Enter login info to change password...��6-   $��Center=�6^   $��Center=�6y   �� 5   
   -   5        $��lblOldPassword��5      $��2��6   $��Old Password:��63   $��23 10 175 10q�6K   G� 5   
   -   5        $��txtOldPassword��5   #   $��2��6   $��120 12 40 10q�69   �� 5   
   -   5        $��lblNewPassword��5      $��3��6   $��New Password:��63   $��19 10 175 10q�6K   G� 5   
   -   5        $��txtNewPassword��5   #   $��3��6   $��120 12 40 10q�69   �� 5   
   -   5        $��lblConfirmPassword��5      $��4��6   $��Confirm Password:��67   $��1 10 175 10q�6S   G� 5   
   -   5        $��txtConfirmPassword��5   #   $��4��6   $��120 12 40 10q�6=   � 5"   
   $��6��6    � ColumnDefinitions 5#      �� 5$      �� 5%      .+�5'      �� -   5        $��	btnCancel��5'   %   $��0��6   $��Cancel��66   $��
40 5 25 15q�6G    �� IsCancel . 6s   �� 5(      -	   5        $��	btnSubmit��5(   %   $��1��6   $��Submit��66   $��
25 5 40 15q�6G   	 �� 	IsDefault	 . 6s   5)      � 5*   
   $��0��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0q�6i   ��5+      �� 5,      
 �� ImageSource$
 yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   5.      �� 5/   
   -
   5         ��Name$ lblLazerShark��5/      $��0��6'   $��Lazer Shark��64   $��22(�6J   $��80 5 0 0q�6X   
������ $��Ravie)�6�   ���	#FFEC2424��50      �� 51       �� Color# � ��6"   53      56      57      