   M S B A M L   `   `   `  ���� 	  Kiosk'    !Kiosk.control.DialogPaymentAccept   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   
������    MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�  � Title$  DialogPaymentAccept��$	��300��$	��500�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � WindowStyle$
 None=�.���� -    ��Name$ PulseBox�����	#eeffffff$��1q����#1976D2 �� CornerRadius$ 15�� J� RenderTransformOrigin$ 0.5,0.5&�._�� $��20 20q� � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��2* �.+��� $��0��$$��جمع مبلغ پرداختی��$��30(�$��Center=�$��Center=��� -    ��Name$ 	txt_price�����#388E3C$��RightToLeft=�$��1��$��20,000 تومان��$��30(�$
��Bold"�$��Center=�$��Center=��� ���#616161$��2��$I��Cآیا می خواهید خرید خود را نهایی کنید؟��$��20(�$��Center=�$��Center=�� $��3��$��	0 30 0 10q�	 � ColumnDefinitions	 �� $��* ��� $��* �.+��� -   
 ��Name$
 btn_ok��$��20(�$��30 10q�$
��auto��$
��auto�����	#dd388E3C$��1��$��بله����Z� �� -   $
 
btn_cancel��$��20(�$��30 10q�$
��auto��$
��auto�����	#ddf44336$��0��$��خیر����Z� 