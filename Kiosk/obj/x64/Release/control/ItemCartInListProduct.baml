   M S B A M L   `   `   `  ���� F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  	 Kiosk)   #Kiosk.control.ItemCartInListProduct   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  -      MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��320����Z� .��� $	��5 5q�.+��� -     ��Name$  PulseBox��
������  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._��  � RowDefinitions �� $	��15* ��� $��5* ��� $
��0.2* �.+�� $��0�� � ColumnDefinitions �� $
��1.2* ��� $��2* �.+�� $��1��$��2q�$	��180��$��Stretch=�.+��� -   $
��Mask�����#ECEFF1$��0q� �� CornerRadius$ 10��$	��180���� .+�   CachedImage.Image  -     Name$ img_product�� �� BitmapScalingMode$
 Fant=�$
��auto��$	��180��$��Uniform=�$��Right=�$$��../img/ic_chicken_and_ribs.jpg��$��Center=� J� OpacityMask !�  !� Visual �� 	 �� ElementName$
	 Mask��� $��0��$��0q� �� $��* �.+�� $��0��$	��2 5q�$
��Left=� �� $��* ��� $��4* �.+�� $��0��.+�� $��1��$��2q�$��Center=�.+��� ���#121c1b$��Center=�$��Center=�$��
تعداد��$��18(�� $��1��$
��Left=� �� $	��16* ��� $��5* ��� $��0* ��� $	��16* �.+��� -   
 ��Name$
 btn_up��$
��auto��$
��auto��$��Center=�$��Center=�$��0����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�$��Center=�$��70��$��70���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardArrowUp=�
���   �$��0q��� -    ��Name$ 	txt_count��$��26(�$
��Bold"����#00b356$��1�� �� TextAlignment$ Center=�$��Center=�$��Center=�$��1��$��0q�$��2���� -   $
 btn_down��$
��auto��$
��auto��$��Center=�$��Center=�$��3����Z� ��Z� .��  $��Center=�$��Center=�$��70��$��70��$ KeyboardArrowDown=�
���   �$	��0,6q�� $��1��$��5q�.+��� -   $
 
btn_remove��$��Bottom=�$
��Left=�$��10 0 0 0q�$��70��$��70����Z� ��Z� .��  $
��auto��$
��auto��$ CloseCircle=����#ef5350$��Stretch=�$��Stretch=���  �� Orientation$ Vertical=�$��Stretch=�$��Stretch=�$��80 0 0 0q�.+��� -	   $ txt_product�����#121c1b$��جوجه کباب��$��SemiBold"�$��18(�$��Right=�$ Right=�$��Center=��� -
   $ 	txt_price��$��RightToLeft=����#121c1b$
��4545��$
��Bold"�$��18(�$��Right=�$ Right=�$��Center=�� $��2��$��Center=�$��0q�$��2��$
��auto��.+�� $��1��$
��auto�����#aaaaaa � 	Resources   FadeInUp �� TargetProperty W� From	 W� To g� Duration �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%  &	       �� .��W� $ Opacity�$ 0X�$ 1X�$ 0:0:0.35D�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.35��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:0.0��$
 0.85Q�  $ 0:0:0.35��$ 1Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ PulseBox��.\�  $ 0:0:0.35��$ -8Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ 