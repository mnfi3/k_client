   M S B A M L   `   `   `  ���� F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  	 Kiosk   Kiosk.control.ItemProduct   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  -      MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��450��$��35q���Z� .��� .+��� -     ��Name$  PulseBox��
������  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._�� -    �Name$ grd_main��$��10q� � RowDefinitions �� $	��220 ��� $��1* ��� $��2* �.+�� $��0��.+��� -   $
��Mask�����#ffffff$��.5q� �� CornerRadius$ 20���� .+�   CachedImage.Image  -     Name$ img_product��$
��auto��$	��220��$��../img/ic_appetizer.jpg�� �� BitmapScalingMode$
 Fant=�$��Uniform=�$��Stretch=�$��Stretch=� J� OpacityMask !�  !� Visual �� 	 �� ElementName$
	 Mask���� $��5q�$ 20��$	��Top=�$
��Left=����#f44336$��1q�._��� -   
 ��Name$
 lbl_discount��$
��Bold"�
�������$��22(�$	��25%��$��Center=�$��Center=�$
��auto��$
��auto��$
��10 5q�� $��1��.+��� -   $
 txt_product��$��2q�$��	appetizer��$��22(�$��Center=�$��Center=����#000c08� $��2�� � ColumnDefinitions �� $��2* ��� $��* �.+�� $��0�� �� $��* ��� $
��1.3* �.+�� $��0��.+��� -   $
 txt_product_price��$��Strikethrough{�$��2q�$��RightToLeft=�$��25,000  تومان��$��15(�$��Light"�$
��Left=�$��Bottom=����	#FF575252� $��1��.+��� -	   $
 txt_product_d_price��$��2q�$��RightToLeft=�$��25,000  تومان��$��22(�$
��Bold"�$
��Left=�$��Center=����#00b356� $��1��.+��� -
    ��Name$ btn_add_to_cart��$
��auto��$
��auto��$��2q�$��RightToLeft=����	#FF0B9117$��16(�$
��Bold"�$��Center=�$��Center=�
���������Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  
�������$��Center=�$��Center=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ AddShoppingCart=�$��40��$��40�� � 	Resources   FadeInUp �� TargetProperty W� From	 W� To g� Duration �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value 
 bounce��%�  &	       &	     �� .��W� $ Opacity�$ 0X�$ 1X�$ 0:0:0.35D�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.35��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.35��$ 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ PulseBox��.\�  $ 0:0:0.35��$ -8Q��� .��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ :� $  UIElement.PreviewMouseDown��.[��� #��[ 