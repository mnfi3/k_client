   M S B A M L   `   `   `  ����	  Kiosk'    !Kiosk.control.DialogPaymentAccept   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        ���#eeeeee   MaterialDesignBody#���   5   	    	 vazir#��[ 5   	     � Title$  DialogPaymentAccept��5   	   $	��300��6%   $	��500��62    � WindowStartupLocation$ CenterScreen=�6>    � AllowsTransparency .  � WindowStyle$
 None=�6}   .��5	      � $��20 20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $$��جمع مبلغ پرداختی��6!   $��30(�69   $��Center=�6H   $��Center=�6c   �� 5   
   -   5         ��Name$ 	txt_price��5      ���#388E3C$��1��6<   $��20,000 تومان��6I   $��30(�6]   $
��Bold"�6k   $��Center=�6}   $��Center=�6�   �� 5   
   ���#616161$��2��6)   $I��Cآیا می خواهید خرید خود را نهایی کنید؟��66   $��20(�6c   $��Center=�6r   $��Center=�6�   � 5   
   $��3��6   $��	0 30 0 10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ btn_ok��5      $��20(�6:   $��30 10q�6_   $
��auto��6n   $
��auto��6{   ���#67aa39$��1��6�   $��بله��6�   ��6H   Z� 5      �� 5      -   5        $ 
btn_cancel��5      $��20(�6B   $��30 10q�6g   $
��auto��6v   $
��auto��6�   ���#7986CB$��0��6�   $��خیر��6�   ��6P   Z� 5!      5"      5#      5$      