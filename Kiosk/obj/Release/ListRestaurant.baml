   M S B A M L   `   `   `  ���� 	  Kiosk    Kiosk.ListRestaurant   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -      MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��600��$
��1000��
�������  � 
ResizeMode$  NoResize=� � WindowState$ 	Maximized=� � AllowsTransparency .  � WindowStyle$
 None=���Z� .��� 
�������.+�� $��50��$	��Top=�$��0 0 0 0q�.+�'  !MaterialDesignThemes.Wpf.PopupBox  $��10q�$��Center=�$
��Left=�
�������   PopupContent. �� $	��150��.+��� -    ��Name$ 
btn_manage��$��مدیریت���� �� -   $��btn_exit��$��خروج��� -    �Name$ grd_main��$��0 60 0 0q�.+��  � RowDefinitions �� $��50 ��� $��* �.+�� $��0��.+��� $��20(�$��Center=�$��Center=�
�������$?��9رستوران مورد نظر را انتخاب کنید��� $��1��.+��� -    ��Name$ lst_restaurants��	 �� PanningMode$
	 None=�$��Disabled=����� .R�A� 
 A� Columns$
 3������  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R���  � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W�  g� Duration$ 0:0:.8D� �� TargetProperty$
 Left� W� From$
 1920X�	 W� To$ 0X� g� AccelerationRatio$ .1Q�