   M S B A M L   `   `   `  ����	  Kiosk     Kiosk.control.DialogPublic   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5   	   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5   	   
������   � Title$  DialogManageApp��5   	   $	��300��6!   $	��500��6.    � AllowsTransparency .  � WindowStyle$
 None=�6T    � WindowStartupLocation$ CenterScreen=�6g   .��5      �� -   5         ��Name$ PulseBox��5      ���	#eeffffff$��1q�68   ���#1976D2 �� CornerRadius$ 15��6b    J� RenderTransformOrigin$ 0.5,0.5&�6t   ._�5   
   � $��20 20q�6    � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ txt_text��5      $��0��6*   $
��Wrap=�67   $��RightToLeft=�6K   $��dialog��6g   $��18(�6u   
���   �$��Center=�6�   $��Center=�6�   � 5      $��1��6   $��10q�6    	 � ColumnDefinitions	 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� -   5        
 ��Name$
 btn_ok��5      $��17(�6>   $��30 10q�6c   $
��auto��6r   $
��auto��6   ���	#dd388E3C$��1��6�   $��بله��6�   ��6L   Z� 5      �� 5      -   5        $
 
btn_cancel��5      $��17(�6F   $��30 10q�6k   $
��auto��6z   $
��auto��6�   ���	#ddf44336$��0��6�   $��خیر��6�   ��6T   Z� 5       5!      5"      5#      5$      