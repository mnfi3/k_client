   M S B A M L   `   `   `  ����	  Kiosk    Kiosk.control.Receipt   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5   	    	 vazir#��[ 5   	   
�������  � 
ResizeMode$  NoResize=�5       � WindowState$ 	Maximized=�62   $	��400��6J   $	��700��6V    � WindowStyle$
 None=�6e   ��5      Z� .��5	      � $��3q�6   
������� � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   � $��0��6   .+�5      �� $��5q�6   $E��?فاکتور خرید از رستوران ستاره باران��6#   
���   �$��Right=�6a   $��Center=�6}   $��15(�6�   �� 5      $��5q�6   $ ��شماره سفارش : 25��6#   
���   �$
��Left=�6N   $��Center=�6i   $��15(�6�   $
��Bold"�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 dtg��5       $��1��6      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ردیف��6h      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6v     CenterGridHeaderStyle   HeaderStyle# [ 6�   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *num+
   ClipboardContentBinding
 6?   �� *num+6�     5      $ نام��6h   $ 5* 6v   # [ 6�   	 6%   �� *name+
 6?   �� *name+6�     5      $ سایز��6h   $ * 6w   # [ 6�   	 6%   �� *size+
 6?   �� *size+6�     5      $ قیمت واحد��6i   $ 3* 6}   # [ 6�   	 6%   �� *price+
 6?   �� *price+6�     5      $ 
تعداد��6i   $ * 6y   # [ 6�   	 6%   �� *count+
 6?   �� *count+6�     5      $ قیمت کل��6h   $ 3* 6z   # [ 6�   	 6%   �� *cost+
 6?   �� *cost+6�   5       � 5"   
   $��2��6    5#      �� 5$      $��* �6    �� 5%      $��* �6    .+�5(      �� $��0��6   $
��20 5q�6%   $��Stretch=�63    �� TextAlignment$ Right=�6R   $��Stretch=�6h   
���   �$��: قیمت کل��6�   $��17(�6�   $��SemiBold"�6�   �� 5)      $��0��6   $
��20 5q�6%   $��Stretch=�63   $
 Left=�6R   $��Stretch=�6g   
���   �$��55,200 تومان��6�   $��17(�6�   $��SemiBold"�6�   �� 5*      $��1��6   $
��20 5q�6%   $��Stretch=�63   $ Right=�6R   $��Stretch=�6h   
���   �$ ��: قیمت با تخفیف��6�   $��17(�6�   $��SemiBold"�6�   �� 5+      $��1��6   $
��20 5q�6%   $��Stretch=�63   $
 Left=�6R   $��Stretch=�6g   
���   �$��49,500 تومان ��6�   $��17(�6�   $��SemiBold"�6�   5-      50      51      