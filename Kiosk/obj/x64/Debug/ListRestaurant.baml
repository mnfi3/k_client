   M S B A M L   `   `   `  ����	  Kiosk    Kiosk.ListRestaurant   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5   	   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5   	   $	��600��5   	   $
��1000��6   
�������  � 
ResizeMode$  NoResize=�66    � WindowState$ 	Maximized=�6L    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��5      Z� .��5
      � 
�������.+�5   
   � $��50��6   $	��Top=�6   $��0 0 0 0q�63   .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��10q�6&   $��Center=�62   $
��Left=�6M   
�������   PopupContent. 5      �� $	��150��6   .+�5      �� -   5         ��Name$ 
btn_manage��5      $��مدیریت��6J   �� 5      �� 5      -   5        $��btn_exit��5      $��خروج��6-   6<   5      5      5      � 5   
   -   5         �Name$ grd_main��5      $��0 60 0 0q�6!   .+�5      �  � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      � $��0��6   .+�5      �� $��20(�6    $��Center=�6.   $��Center=�6J   
�������$?��9رستوران مورد نظر را انتخاب کنید��6z   5      � 5      $��1��6   .+�5      �� -   5         ��Name$ lst_restaurants��5   v   	 �� PanningMode$
	 None=�6   $��Disabled=�6@   ��5!      �� 5"      .R�5#   "   A� 
 A� Columns$
 3��6.   5$      ��5(      �� 5)       �� 
TargetType" ��6$   .�5*   "   ��  �� Property � �� �� Value
 ���� 6?   �� 5+   "    � �� 5,   &   �� 5-   *    �� 
TargetType" ��6:   .R�5.   .   �� 5/   +   51   #   52      55      56      57      58      59       � Triggers 5:      :� 5;   
    :� RoutedEvent$ Window.Loaded��6   .[�5<      �� .��5=      �� .��5>      W�  g� Duration$ 0:0:.8D�6&    �� TargetProperty$
 Left�68    W� From$
 1920X�6Y   	 W� To$ 0X�6e    g� AccelerationRatio$ .1Q�6l   5?      5@      5A      5C      