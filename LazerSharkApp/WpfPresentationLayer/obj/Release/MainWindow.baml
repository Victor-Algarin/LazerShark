   M S B A M L   `   `   `  ���� O  KWpfPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WpfPresentationLayerWpfPresentationLayer  %    WpfPresentationLayer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:WpfPresentationLayer     -     � Title$  
MainWindow��$	��550��$	��950�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $
��Auto ��� $��50 ��� �� �� �� �� �� $��30 � � ColumnDefinitions �� �� �� �� �� �� �� �� .+�� $��2��$��5��$��8������  �� Color# � �� �� �� $	��200 �o� $��0��$��8������ # � ��.@�m� $
��File��.@�m� -   $��mnuQuit��$
��Quit��$
��Auto��m� $
��Help��.@�m� -   $��mnuHelp��$
��Help��$
��Auto��m� -   $��mnuAbout��$��About��$
��Auto��m� $��Admin��.@�m� -   $��mnuAdminLogin��$��Login��$
��Auto��� $��1��$��8��.+�� $��1�� J� Opacity$
 0.85Q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black��	 � Offset$	 0Q�� $ 	#FF71B5EE��$
	 0.54Q�.+�� $��1��$��65��$��75��$
��Left=�$��Center=�$��0 5 0 0q����� 
 �� ImageSource$
 yG:\DotNetII\LazerShark\LazerSharkApp\LazerSharkApp\WpfPresentationLayer\Resources\shark_with_laser_by_carrool-d68jf0w.ico���� -   $��btnLogIn��$��1��$��7��$��Log In��$��20 12q�$��10(�$��0q��� -    ��Name$ 	txtSearch��$��1��$��5��$��2��$��Right=�$��23�� �� TextWrapping$
 Wrap=�$��Search��$��Center=�$	��150���� -   $��MainStatusBar��$��7��$��8��.@��� -	   $��statusMessage��$��Status Message���� -
   $ txtDescription��$��5��$��2��$��6��$��0��$��40 30 100 10q�$
 Wrap=� �� 
IsReadOnly . �� -    ��Name$ lstMediaList��$��3��$��3��$��0��$��6��$��
40 0 0 60 q�$��Visible=��� -   $ lstCart��$��2��$��4��$��6��$��2��$��
40 25 20 0q��� $��6��$��6��$��Total:��$��40 15 40 50q�$��0q�$��14(��� -    ��Name$ btnCheckOut��$��6��$��7��$��	Check Out��$��15 15 20 45 q� �� 	IsDefault . �� -   $ txtTotal��$��6��$��6��$��2��$��80 15 110 50q� . $��0q�$��14(� J� IsHitTestVisible .  ��Z� ��Z� �� -    ��Name$ lblLazerShark��$��3��$��2��$��1��$��Lazer Shark��$��36(�$��0q�
������ $��Ravie)����	#FFEC2424���� # � ���� -    ��Name$ cmbCategory��$��
40 30 5 30q�$��2��$��0��$��2�� �� 
IsReadOnly .  �� 
IsEditable . .@��� -   $��	cmbMovies��$��Movies�� �� 
IsSelected . �� -   $��cmbVideoGames��$��Video Games���� -   $ cmbGenre��$��
20 30 0 30q�$��2��$��2��$��2�� .  .  �� Text$ -- Select a Genre --��.@��� -   $��	cmbAction��$��Action���� -   $��cmbDrama��$��Drama���� -   $��	cmbComedy��$��Comedy���� -   $��
cmbShooter��$��Shooter���� -   $��cmbSimulation��$��
Simulation���� -   $��cmbRpg��$	��RPG���� -   $��cmbAll1��$	��All���� -   $ 	cmbMedium��$��
20 30 0 30q�$��2��$��4��$��2�� .  . $ -- Select System --��.@��� -   $��cmbDvd��$	��DVD���� -   $��	cmbBluRay��$��Blu-Ray���� -   $��cmbXbox��$��XBONE���� -   $��cmbPs4��$	��PS4���� -    $��cmbPc��$��PC���� -!   $��cmbAll2��$	��All���� -"   $ btnAddToCart��$��Add Item��$��5��$��5��$��	25 55 0 0q��� -#   $ btnClearCart��$��
Clear Cart��$��6��$��5��$��
25 15 0 45q�