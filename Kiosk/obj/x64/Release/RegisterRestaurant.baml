   M S B A M L   `   `   `  ���� 	  Kiosk    Kiosk.RegisterRestaurant   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�  � Title$  RegisterRestaurant��$	��800��$
��1000�� � WindowState$ 	Maximized=� � AllowsTransparency .  � WindowStyle$
 None=�.��� ���#81C784 � ColumnDefinitions �� $��2* ��� $��* �.+�� $��0��$��10q�.+��� $3��-افزودن رستوران به دستگاه��$��Center=�$
��Bold"�$��22(�$��20q�� $��Center=�$��Center=�$	��400��$	��500��
������� � RowDefinitions �� $��* ��� $��2* ��� $��* ��� $��2* ��� $��2* �.+��� $
��10 5q�$��0��$��نام کاربری��$��Center=�$��Center=�$
��Bold"�$��15(����	#FF0337EA�� -    ��Name$ txt_user_name��$
��10 5q�$��1�����	#FFDED4D4$
��Bold"�$��25(��� $
��10 5q�$��2��$��کلمه عبور��$��Center=�$��Center=�$��15(����	#FF0337EA$
��Bold"�G� -    G�Name$ txt_password��$
��10 5q�$��3�����	#FFDED4D4
���   �$��25(��� -    ��Name$ 	btn_login��$
��10 5q�$
��auto��$��4��$��افزودن��� $��Bottom=� �� $��* ��� $��* �.+��� -   $ 
btn_finish��$��0��$��50��$��تمام��$��20q��� -   $ btn_back��$��1��$��بازگشت��$��50��$��20q�� $��1��
�������.+��� -   	 ��Name$	 lst_restaurants��$
��auto��$
��auto��$��10q����#f00$��Disabled=����� 
 �� 
TargetType"
 ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R��� 