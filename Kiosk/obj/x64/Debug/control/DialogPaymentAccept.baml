   M S B A M L   `   `   `  ����	  Kiosk'    !Kiosk.control.DialogPaymentAccept   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        
������    MaterialDesignBody#���   5   	   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5   	     � Title$  DialogPaymentAccept��5   	   $	��300��6%   $	��500��62    � WindowStartupLocation$ CenterScreen=�6>    � AllowsTransparency .  � WindowStyle$
 None=�6}   .��5
      �� -   5         ��Name$ PulseBox��5
      ���	#eeffffff$��1q�68   ���#1976D2 �� CornerRadius$ 15��6b    J� RenderTransformOrigin$ 0.5,0.5&�6t   ._�5   
   � $��20 20q�6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��2* �6    .+�5      �� $��0��6   $$��جمع مبلغ پرداختی��6%   $��30(�6=   $��Center=�6L   $��Center=�6g   �� 5      -   5         ��Name$ 	txt_price��5      ���#388E3C$��RightToLeft=�6@   $��1��6\   $��20,000 تومان��6i   $��30(�6}   $
��Bold"�6�   $��Center=�6�   $��Center=�6�   �� 5      ���#616161$��2��6-   $I��Cآیا می خواهید خرید خود را نهایی کنید؟��6:   $��20(�6g   $��Center=�6v   $��Center=�6�   � 5      $��3��6   $��	0 30 0 10q�6    	 � ColumnDefinitions	 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� -   5        
 ��Name$
 btn_ok��5      $��20(�6>   $��30 10q�6c   $
��auto��6r   $
��auto��6   ���	#dd388E3C$��1��6�   $��بله��6�   ��6L   Z� 5      �� 5!      -   5        $
 
btn_cancel��5!      $��20(�6F   $��30 10q�6k   $
��auto��6z   $
��auto��6�   ���	#ddf44336$��0��6�   $��خیر��6�   ��6T   Z� 5#      5$      5%      5&      5'      