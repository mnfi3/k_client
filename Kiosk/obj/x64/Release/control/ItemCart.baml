   M S B A M L   `   `   `  ���� F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  	 Kiosk   Kiosk.control.ItemCart   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  -      MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��300����Z� .��� $
��5 10q�.+��� -     ��Name$  PulseBox��
������  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._��  � RowDefinitions �� $	��15* ��� $��* �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��4��$��5 5 20 5q�.+��� -   $
��Mask�����#f4f4f4$��0q� �� CornerRadius$ 10���� .+�   CachedImage.Image  -     Name$ img_product�� �� BitmapScalingMode$
 Fant=�$
��auto��$	��300��$$��../img/ic_chicken_and_ribs.jpg��$��Stretch=�$��Center=� J� OpacityMask !�  !� Visual �� 	 �� ElementName$
	 Mask��� $��3��$��5 5 20 5q�.+��� $��3��$��Center=�
 �� Orientation$
 Vertical=�.+��� -    ��Name$ txt_product�����#121c1b$��جوجه کباب��$
��Bold"�$��22(�$��Right=�$��Center=�� $��2��$��5q� �� $��* ��� $��2* �.+�� $��0��$
��2 50q�$
��Left=� �� $	��16* ��� $	��11* ��� $��5* ��� $	��16* �.+��� -    ��Name$ btn_up��$��90��$��70��$��Center=�$��Center=�$��0����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�$��Center=�$��90��$��70���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardArrowUp=�
���   �$	��0,6q��� -   $ 	txt_count��$��25(�$
��Bold"����#00b356$��1��$��Center=�$��Center=�$��1��$��6,6,5,6q�$��2���� -   $ btn_down��$��90��$��70��$��Center=�$��Center=�$��3����Z� ��Z� .��  $��Center=�$��Center=�$��90��$��70��$ KeyboardArrowDown=�
���   �$	��0,6q�� $��1��$
��10 2q�$
��Left=�.+��� ���#121c1b$��Center=�$��Center=�$��
تعداد��$��20(�� $��1��$��5q�.+��� -	   $ txt_product_price��$��RightToLeft=����#121c1b$��25,000  تومان��$��20(�$
��Bold"�$��Center=�$��Center=�� $��0��$��5q�.+��� -
   $ 
btn_remove��$��85��$��85����Z� ��Z� .��  $��50��$��50��$ CloseCircle=����#ef5350$��Center=�$��Center=�� $��1��$��Center=�$��0q�$��2��$
��auto�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�� $��0��$��1��$
��auto�����#aaaaaa� $��1��$��1��$
��auto�����#aaaaaa� $��2��$��1��$
��auto�����#aaaaaa� $��3��$��1��$
��auto�����#aaaaaa � 	Resources   FadeInUp �� TargetProperty W� From	 W� To g� Duration �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%  &	       �� .��W� $ Opacity�$ 0X�$ 1X�$ 0:0:0.7D�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.7��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.7��$ 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ PulseBox��.\�  $ 0:0:0.7��$ -8Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ 