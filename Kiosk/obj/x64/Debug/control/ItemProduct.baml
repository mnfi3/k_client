   M S B A M L   `   `   `  ����F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  5      	 Kiosk   Kiosk.control.ItemProduct   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  5      -   5           MaterialDesignBody#���   5	      $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�5
      $	��450��5      ��5      Z� .��5      � .+�5   
   �� -   5          ��Name$  PulseBox��5      
������  J� RenderTransformOrigin$ 0.5,0.5&�5   2   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      ._�5      � -   5         �Name$ grd_main��5      $��20q�6    � RowDefinitions 5      �� 5      $	��220 �6$   �� 5      $��* �6$   �� 5       $��* �6$   �� 5!      $��* �6$   .+�5$      � $��0��6   .+�5'      �� -   5        $
��Mask��5'      ���#ffffff$��.5q�6>    �� CornerRadius$ 20��6S   �� 5(      .+�5)         CachedImage.Image  -   5          Name$ img_product��5)   F   $
��auto��6,   $	��220��69   $��../img/ic_appetizer.jpg��6[    �� BitmapScalingMode$
 Fant=�6|   $��Uniform=�6�   $��Stretch=�6�   $��Stretch=�6�    J� OpacityMask 5*      !� 5+       !� Visual 6*   �� 	 �� ElementName$
	 Mask��5-      �� 53      $��5q�6   $ 20��6(   $	��Top=�6<   $
��Left=�6T   ���#f44336$��1q�6�   ._�54      �� -   5        
 ��Name$
 lbl_discount��54   $   $
��Bold"�6:   
�������$��22(�6`   $	��25%��6n   $��Center=�6y   $��Center=�6�   $
��auto��6�   $
��auto��6�   $
��10 5q�6�   55      59      � 5;      $��1��6   .+�5<      �� -   5        $
 txt_product��5<       $��2q�65   $��	appetizer��6@   $��22(�6Q   $��Center=�6_   $��Center=�6|   ���#000c086�   5=      � 5?      $��2��6   .+�5@      �� -   5        $
 txt_product_price��5@       $��Strikethrough{�6;   $��2q�6[   $��RightToLeft=�6f   $��25,000  تومان��6�   $��22(�6�   $��Light"�6�   $��Center=�6�   $��Center=�6�   ���#f443366�   5A      � 5C      $��3��6   .+�5D      �� -	   5        $
 txt_product_d_price��5D       $��2q�6>   $��RightToLeft=�6I   $��25,000  تومان��6e   $��22(�6z   $
��Bold"�6�   $��Center=�6�   $��Center=�6�   ���#00b3566�   5E      5H      5I      5K       � 	Resources 5L        FadeInUp �� TargetProperty W� From	 W� To g� Duration �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value 
 bounce��%  &	       &	 �    �� 5M   
   .��5P      W� $ Opacity�6   $ 0X�6B   $ 1X�6K   $ 0:0:0.35D�6R   5Q      U� 5S      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ PulseBox��6�   .\�5T        $ 0:0:0.0��6'   $
 0.85Q�69     5U      $ 0:0:0.35��6'   $ 1Q�6:   5V      U� 5W      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ PulseBox��6�   .\�5X        $ 0:0:0.0��6'   $
 0.85Q�69     5Y      $ 0:0:0.35��6'   $ 1Q�6:   5Z      U� 5[      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ PulseBox��6�   .\�5\        $ 0:0:0.35��6'   $ -8Q�6:   5^      5_      �� 5`   
   .��5a      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ PulseBox��6�   .\�5b        $ 0:0:0.25��6'   $	 0.9Q�6:     5c      $ 0:0:0.35��6'   $ 1Q�6:   5d      U� 5e      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ PulseBox��6�   .\�5f        $ 0:0:0.25��6'   $	 0.9Q�6:     5g      $ 0:0:0.35��6'   $ 1Q�6:   5h      5i      5j       � Triggers 5k      :� 5l   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5n      �� #��[ 6   5p      :� 5q   
   $  UIElement.PreviewMouseDown��6   .[�5s      �� #��[ 6   5u      5w      