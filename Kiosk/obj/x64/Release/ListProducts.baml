   M S B A M L   `   `   `  ���� @  <Kiosk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kiosk.controlKiosk.control      Kiosk.ListProducts   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6controls'using:Microsoft.Toolkit.Uwp.UI.Controls  'localclr-namespace:Kiosk.control  -   
�������   MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��600��$
��1000��
  � Top$  0�� � Left$ 0��
������� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=�.��� -    �Name$ grd_main��
�������.+�� -   $ 	grd_main2��$y�Visible=� � ColumnDefinitions �� -    ��Name$ cln_cart��$
��2.5* ��� $	��10* ��� $
��2.5* �.+�� $��0��$y�Visible=����#ECEFF1.+��  � RowDefinitions �� $��* ��� $��50 ��� $��90 �.+��� -   	 ��Name$	 lst_cart��$��0��$��Disabled=�$��Hidden=�$��Stretch=�$
��auto��$��Stretch=�
 �� PanningMode$

 Both=����� .R�A� $	��Top=�$��Center=� A� Columns$ 1������  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R��� �� $��1�� �� Orientation$ Vertical=�.+��� $��0 1 0 0q�
�������$��0 -4 0 0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 14Q�   ShadowDepth$	 1.5Q�   	Direction$ 90Q�   Color$
 #222��   Opacity$ .5Q�   RenderingBias$ Performance=�� $��1�� �� $��* ��� $��* �.+��� -    ��Name$ 	txt_total��$��RightToLeft=�$��20(�$��0��$��	10 10 0 0q�$
��Left=�$
��Bold"�
���   �$��16000���� $��1��$��20(�$��	0 10 10 0q�$��Right=�$
��Bold"�
���   �$��جمع حساب���� -    ��Name$ btn_checkout��$��2��$
��5 10q�$��20(�$��70��$��Bottom=�$��Stretch=�
�������$��مدیریت سبد�����#00b356� $��1�����#ffffff �� $��65 ��� $��* ��� $��25 �.+�� $��0�� �� $��50 ��� $	��150 ��� $��* �.+��� -   $ txt_category_name��$��2��$
��Auto�����#444444$��	ExtraBold"�$�� ��$��RightToLeft=�$��
0 20 25 10q�$��25(��� -	   $ btn_back_to_restaurants��$y�Visible=�$��1��$��15(�$��50��
����������	#FFFD1E1E$��0q�$��Center=�$��Center=���Z� .���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  
�������$��Center=�$
��Left=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardArrowLeft=�$��40��$��40���� 
�������$��20(�$
��Bold"�$��Center=�$��5q�$��بازگشت���� -
   $	 lst_products��$��1��$��10q�$��Right=�$��Stretch=�$

 Both=�$��Hidden=�$��Disabled=����� .R�A� $��RightToLeft=�$��Stretch=�$
��auto��$	��Top=�$ 3������ " ��.���  � ��
 ���� ��  � �� �� " ��.R��� '  !MaterialDesignThemes.Wpf.PopupBox  -     Name$ btn_setting��$��2��$y�Visible=�$��0q�$	��Top=�$
��Left=����#f1f1f1   PopupContent. �� $	��150��.+��� -   $��مدیریت���� �� -   $��btn_exit��$��خروج��� -   $ grd_category��$��2�����#f6f6f6.+��� -   $	 lst_categories��$��10q�$��Disabled=�$��Stretch=�$��Stretch=�$��Stretch=�$

 Both=�$��Hidden=����� .R�A� $	��Top=�$��Center=�$ 1������ " ��.���  � ��
 ���� ��  � �� �� " ��.R��� (� $	��150��$	��150��$��Center=�$��Center=�$y�	Collapsed=�.��"   Kiosk.control.CircleProgress  -     Name$ prg_loading��$y�	Collapsed=�