   M S B A M L   `   `   `  ����F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  5      	 Kiosk   Kiosk.control.ItemCart   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  5      -   5           MaterialDesignBody#���   5	      $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5
      $	��300��5      ��5      Z� .��5      � $
��5 10q�6   .+�5   
   �� -   5          ��Name$  PulseBox��5      
������  J� RenderTransformOrigin$ 0.5,0.5&�5   2   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      ._�5      �  � RowDefinitions 5      �� 5      $	��15* �6$   �� 5      $��* �6$   .+�5"      � $��0��6    � ColumnDefinitions 5#      �� 5$      $��* �6+   �� 5%      $��* �6+   �� 5&      $��* �6+   �� 5'      $��* �6+   �� 5(      $��* �6+   .+�5+      � $��4��6   $��5 5 20 5q�6,   .+�5,      �� -   5        $
��Mask��5,   !   ���#f4f4f4$��0q�6B    �� CornerRadius$ 10��6V   �� 5-      .+�5.         CachedImage.Image  -   5          Name$ img_product��5.   0    �� BitmapScalingMode$
 Fant=�6E   $
��auto��6m   $	��300��6z   $$��../img/ic_chicken_and_ribs.jpg��6�   $��Stretch=�6�   $��Center=�6�    J� OpacityMask 5/      !� 50   "    !� Visual 6.   �� 	 �� ElementName$
	 Mask��52      53      � 55      $��3��6   $��5 5 20 5q�6,   .+�56      �� $��3��6%   $��Center=�65   
 �� Orientation$
 Vertical=�6P   .+�57      �� -   5         ��Name$ txt_product��57   (   ���#121c1b$��جوجه کباب��6S   $
��Bold"�6d   $��22(�6v   $��Right=�6�   $��Center=�6�   �� 59      -   5         ��Name$ lst_desserts��59   '   $	��170��6=   $
��auto��6J   $��0 10 0 0q�6W   $��Hidden=�6i   $��Disabled=�6�   $��Stretch=�6�   ��5:   "   �� 5;   &   .R�5<   *   A�  A� Columns$ 1��66   $	��Top=�6B   $��Right=�6Z   $��RightToLeft=�6v   5=   '   ��5A   "   �� 5B   &    �� 
TargetType" ��6,   .�5C   *   ��  �� Property � �� �� Value
 ���� 6G   �� 5D   *    � �� 5E   .   �� 5F   2    �� 
TargetType" ��6B   .R�5G   6   �� 5H   3   5J   +   5K   '   5O      5Q      5R      � 5T      $��2��6   $��5q�6+    5V      �� 5W      $��* �6/   �� 5X      $��2* �6/   .+�5\      � $��0��6   $
��2 50q�6/   $
��Left=�6=    5]      �� 5^   "   $	��16* �60   �� 5_   "   $	��11* �60   �� 5`   "   $��5* �60   �� 5a   "   $	��16* �60   .+�5d      �� -   5         ��Name$ btn_up��5d   %   $��90��6J   $��70��6U   $��Center=�6�   $��Center=�6�   $��0��6�   ��6a   Z� ��6w   Z� .��5e   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6;   $��Center=�6X   $��90��6s   $��70��6~   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardArrowUp=�6�   
���   �$	��0,6q�6�   5f      �� 5g      -   5        $ 	txt_count��5g   (   $��25(�6;   $
��Bold"�6I   ���#00b356$��1��6p   $��Center=�6}   $��Center=�6�   $��1��6�   $��6,6,5,6q�6�   $��2��6�   �� 5h      -	   5        $ btn_down��5h   %   $��90��6N   $��70��6Y   $��Center=�6�   $��Center=�6�   $��3��6�   ��6e   Z� ��6{   Z� .��5i   "     $��Center=�6:   $��Center=�6W   $��90��6s   $��70��6~   $ KeyboardArrowDown=�6�   
���   �$	��0,6q�6�   5j      5k      � 5n      $��1��6   $
��10 2q�6/   $
��Left=�6=   .+�5o      �� ���#121c1b$��Center=�6=   $��Center=�6X   $��
تعداد��6u   $��20(�6�   5p      5q      � 5s      $��1��6   $��5q�6+   .+�5t      �� -
   5        $ txt_product_price��5t   $   $��RightToLeft=�6?   ���#121c1b$��25,000  تومان��6p   $��20(�6�   $
��Bold"�6�   $��Center=�6�   $��Center=�6�   5u      � 5y      $��0��6   $��5q�6+   .+�5z      �� -   5        $ 
btn_remove��5z   !   $��85��6N   $��85��6Z   ��6e   Z� ��6{   Z� .��5{        $��50��66   $��50��6B   $ CloseCircle=�6M   ���#BDBDBD$��Center=�6u   $��Center=�6�   5|      5}      5�      � 5�      $��1��6   $��Center=�6$   $��0q�6@   $��2��6K   $
��auto��6V    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      � $��0��6   $��1��6+   $
��auto��66   ���#aaaaaa6C   � 5�      $��1��6   $��1��6+   $
��auto��66   ���#aaaaaa6C   � 5�      $��2��6   $��1��6+   $
��auto��66   ���#aaaaaa6C   � 5�      $��3��6   $��1��6+   $
��auto��66   ���#aaaaaa6C   5�      5�      5�      5�       � 	Resources 5�        FadeInUp �� TargetProperty W� From	 W� To g� Duration �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%  &	       �� 5�   
   .��5�      W� $ Opacity�6   $ 0X�6B   $ 1X�6K   $ 0:0:0.7D�6R   5�      U� 5�      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ PulseBox��6�   .\�5�        $ 0:0:0.0��6'   $
 0.85Q�69     5�      $ 0:0:0.7��6'   $ 1Q�69   5�      U� 5�      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ PulseBox��6�   .\�5�        $ 0:0:0.0��6'   $
 0.85Q�69     5�      $ 0:0:0.7��6'   $ 1Q�69   5�      U� 5�      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ PulseBox��6�   .\�5�        $ 0:0:0.7��6'   $ -8Q�69   5�      5�      5�       � Triggers 5�      :� 5�   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5�      �� #��[ 6   5�      5�      