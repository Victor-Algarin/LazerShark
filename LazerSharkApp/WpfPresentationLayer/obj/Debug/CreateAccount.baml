   M S B A M L   `   `   `  ����O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  5   	   (    "WpfPresentationLayer.CreateAccount   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:WpfPresentationLayer     5   	     � Title$  CreateAccount��5   	   $	��350��6   $	��300��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ 	#FF71B5EE��6    � Offset$ 0.289Q�61   5      .+�5   
   � $��0��6   $��65��6   $��75��6(   $
��Left=�63   $��Center=�6N   $��0 5 0 0q�6i   ��5      �� 5       �� ImageSource$ yD:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico��6    j� Stretch$ Uniform=�6�   5!      �� 5"   
   -   5        	 ��Name$	 lblLazerShark��5"      $��0��6'   $��Lazer Shark��64   $��22(�6J   $��80 5 0 0q�6X   
������ $��Ravie)�6�   ���	#FFEC2424��5#      �� 5$      
 �� Color#
 � ��6"   5&      �� 5'   
   -   5        $��lblFirstName��5'      $��1��6$   $��First Name:��61   $��
40 0 175 0q�6G   �� 5(   
   -   5        $��txtFirstName��5(      $��1��6&   $��
120 5 40 5q�63   �� 5*   
   -   5        $��lblLastName��5*      $��2��6#   $��
Last Name:��60   $��
40 0 175 0q�6E   �� 5+   
   -   5        $��txtLastName��5+      $��2��6%   $��
120 5 40 5q�62   �� 5-   
   -   5        $��lblEmail��5-      $��3��6    $��Email:��6-   $��
68 0 175 0q�6>   �� 5.   
   -   5        $��txtEmail��5.      $��3��6"   $��
120 5 40 5q�6/   �� 50   
   -   5        $��lblPhoneNumber��50      $��4��6&   $��Phone Number:��63   $��
16 0 175 0q�6K   �� 51   
   -	   5        $��txtPhoneNumber��51      $��4��6(   $��
120 5 40 5q�65   �� 53   
   -
   5        $��
lblAddress��53      $��5��6"   $��Address:��6/   $��
54 0 175 0q�6B   �� 54   
   -   5        $��
txtAddress��54      $��5��6$   $��
120 5 40 5q�61   �� 56   
   -   5        $��lblUsername��56      $��6��6#   $��	Username:��60   $��
44 0 175 0q�6D   �� 57   
   -   5        $��txtUsername��57      $��6��6%   $��
120 5 40 5q�62   �� 59   
   -   5        $��lblPassword��59      $��7��6#   $��	Password:��60   $��
48 0 175 0q�6D   G� 5:   
   -   5        $��txtPassword��5:      $��7��6)   $��
120 5 40 5q�66   �� 5<   
   -   5        $��lblConfirmPassword��5<      $��8��6*   $��Confirm Password:��67   $��	2 0 175 0q�6S   G� 5=   
   -   5        $��txtConfirmPassword��5=      $��8��60   $��
120 5 40 5q�6=   �� 5?   
   -   5        $��	btnCancel��5?      $��9��6"   $��Cancel��6/   $��0q�6@   $��
60 5 175 5q�6L    �� IsCancel . 6x   �� 5@   
   -   5        $��	btnSubmit��5@      $��9��6"   $��Submit��6/   $��0q�6@   $��
175 5 60 5q�6L    �� 	IsDefault . 6x   5A      5B      