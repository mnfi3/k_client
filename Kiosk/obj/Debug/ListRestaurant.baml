   M S B A M L   `   `   `  ����	  Kiosk    Kiosk.ListRestaurant   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5   	   $	��600��5   	   $
��1000��6   
�������  � 
ResizeMode$  NoResize=�66    � WindowState$ 	Maximized=�6L    � AllowsTransparency .  � WindowStyle$
 None=�6�   $��Vazir)�6�   ��5      Z� .��5
      � 
�������.+�5   
   � $��10��6   $	��Top=�6   ���	#FF0080FF63   � 5   
   $��50��6   $	��Top=�6   ���	#ff000000$��0 10 0 0q�6K   .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��10q�6&   $��Center=�62   $
��Left=�6M   
�������   PopupContent. 5      �� $	��150��6   .+�5      �� -   5         ��Name$ 
btn_manage��5      $��مدیریت��6J   �� 5      �� 5      -   5        $��btn_exit��5      $��خروج��6-   6<   5      5      �� 5      $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5      �� $
��10 0q�6   ���	#FFaaaaaa$��powered by www.ezitech.ir��6A   $��Center=�6b   $��Center=�6~   $��22(�6�   $��Sitka Display)�6�   �� 5      $��Center=�6   ��65   Z� ��6K   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  ���	#FFaaaaaa�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Telegram=�6F   $��25��6V   $��25��6a   5      �� 5      $��Center=�6   ��65   Z� ��6K   Z� .��5        $��Center=�6/   ���	#FFaaaaaa$ 	Instagram=�6a   $��25��6r   $��25��6}   5      �� 5       $��Center=�6   ��65   Z� ��6K   Z� .��5!        $��Center=�6/   ���	#FFaaaaaa$	 Web=�6a   $��25��6l   $��25��6w   5"      5#      5$      � 51   
   -   5         �Name$ grd_main��51      $��0 60 0 0q�6!   .+�54      � 	 � RowDefinitions	 55      �� 56      $��50 �6$   �� 57      $��* �6$   .+�5:      � $��0��6   ���#304FFE.+�5;      �� $��20(�6    $��Center=�6.   $��Center=�6J   
�������$?��9رستوران مورد نظر را انتخاب کنید��6z   5<      � 5>      $��1��6   .+�5?      �� -   5        
 ��Name$
 lst_restaurants��5?   v    �� PanningMode$
 None=�6   $��Disabled=�6@   ��5A      �� 5B      .R�5C   "   A�  A� Columns$ 3��6.   5D      ��5H      �� 5I       �� 
TargetType" ��6$   .�5J   "   ��  �� Property � �� �� Value
 ���� 6?   �� 5K   "    � �� 5L   &   �� 5M   *    �� 
TargetType" ��6:   .R�5N   .   �� 5O   +   5Q   #   5R      5U      5V      5W      5Z      5`      5a      