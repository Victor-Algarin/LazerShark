   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   %    WpfPresentationLayer.AdminLogin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  
AdminLogin��5   	   $	��300��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF71B5EE��6    � Offset$ 0.289Q�61   5      .+�5   
   o� ��5      �� 5       �� Color# � ��6"   .@�5      m� $
��File��6   .@�5      m� -   5        $��mnuQuit��5      $
��Quit��6*   $
��Auto��68   5      m� 5       $��Settings��6   5"      5#      �� 5$   
   $��	Username:��6   $��2��6$   $��30 15 200 15q�61   $��0q�6G   �� 5%   
   -   5        $��txtUsername��5%      $��2��6%   $��100 15 30 15q�62   �� 5'   
   $��	Password:��6   $��3��6$   $��33 15 200 15q�61   $��0q�6G   G� 5(   
   -   5        $��txtPassword��5(      $��3��6)   $��100 15 30 15q�66   �� 5*   
   -   5        $��	btnCancel��5*      $��4��6"   $��Cancel��6/   $��75 15 170 15q�6@    �� IsCancel . 6n   �� 5+   
   -   5        $��btnLogin��5+      $��4��6!   $��Login��6.   $��170 15 75 15q�6>   	 �� 	IsDefault	 . 6k   � 5-   
   $��1��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0q�6i   ��5.      �� 5/      
 �� ImageSource$
 yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   51      �� 52   
   -   5         ��Name$ lblLazerShark��52      $��1��6'   $��Lazer Shark��64   $��22(�6J   $��80 5 0 0q�6X   
������ $��Ravie)�6�   ���	#FFEC2424��53      �� 54      # � ��6"   56      57      58      