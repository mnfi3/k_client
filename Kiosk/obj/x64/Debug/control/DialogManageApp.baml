   M S B A M L   `   `   `  ����	  Kiosk#    Kiosk.control.DialogManageApp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������   MaterialDesignBody#���   5   	   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5   	     � Title$  DialogManageApp��5   	   $	��300��6!   $	��500��6.    � AllowsTransparency .  � WindowStyle$
 None=�6T    � WindowStartupLocation$ CenterScreen=�6g   .��5	      � $��20 20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ txt_client_key��5   !   $��0��6   $��fwaefefeafe��69   ���#dddddd$��22(�6a    �� TextAlignment$ Center=�6o   $��Stretch=�6�   $��Stretch=�6�   �� 5   
   $��1��6   $,��&رمز عبور را وارد کنید��6!   $��22(�6>   $��Center=�6M   $��Center=�6h   G� 5   
   -   5         G�Name$ txt_password��5      $��2��6,   $��18(�69   $��5q�6G   
�������6e   � 5   
   $��4��6   $��	0 30 0 10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5        	 ��Name$	 btn_ok��5      $��20(�6:   $��30 10q�6_   $
��auto��6n   $
��auto��6{   ���#388E3C$��1��6�   $��
تایید��6�   ��6H   Z� 5      �� 5      -   5        $	 
btn_cancel��5      $��20(�6B   $��30 10q�6g   $
��auto��6v   $
��auto��6�   ���#f44336$��0��6�   $��لغو��6�   ��6P   Z� 5!      5"      5#      5$      