   M S B A M L   `   `   `  ���� F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  	 Kiosk   Kiosk.ProductInfo   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  -   
�������   MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��900��$
��1400��
  � Top$  0�� � Left$ 0��
������� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=�.��� -    �Name$ grd_main��
������� � ColumnDefinitions �� $
��1.5* ��� $��* �.+�� ���#f1f1f1$��0�� � RowDefinitions �� $��0* ��� $��4* ��� $��4* �.+�� $��0��$��20 20q� �� $��* ��� $��3* �.+��� ���#121c1b$
��Bold"�$��22(�$��Center=�$��Right=�$=��7اندازه مورد نظر را انتخاب کنید��� $��1��.+���  �� Orientation$ 
Horizontal=�$��Center=�	 � 	Resources	   bounce1
 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  bounce2  bounce3��%0  &	       &	 \    &	 �    �� .��U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 
LittleSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q�U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 
LittleSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q��� .��U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 
NormalSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q�U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 
NormalSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q��� .��U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	LargeSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q�U� $V
 P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 	LargeSize��.\�  $ 0:0:0.25��$	 0.9Q�  $ 0:0:0.35��$ 1Q�.+��� -    ��Name$ 
LittleSize�� J� RenderTransformOrigin$ 0.5,0.5&� � Triggers :�  :� RoutedEvent$  UIElement.PreviewMouseDown��.[��� #��[ z�V� .~��� �� �� T� ._��� -    ��Name$ 	btn_small�����#fcfcfc���#3b4944$��22(�$��کوچک��$
��auto��$	��150��$��50 10q���Z� �� -   $ 
NormalSize��$ 0.5,0.5&� :� $  UIElement.PreviewMouseDown��.[��� #��[ z�V� .~��� �� �� T� ._��� -   $ 
btn_medium�����#3b4944$��22(�$��
متوسط��$
��auto��$	��150��$��50 10q���Z� ��Z� �� -   $ 	LargeSize��$ 0.5,0.5&� :� $  UIElement.PreviewMouseDown��.[��� #��[ z�V� .~��� �� �� T� ._��� -   $ 	btn_large�����#3b4944$��22(�$��بزرگ��$
��auto��$	��150��$��50 10q���Z� ��Z� � $��1��$��20 20q� �� $��* ��� $��5* �.+��� ���#121c1b$
��Bold"�$��22(�$��Center=�$��Right=�$=��7مخلفات مورد نظر را انتخاب کنید���� -	    ��Name$ 	lst_sides��$��1��$��Disabled=�$��Hidden=�$��RightToLeft=� �� PanningMode$
 Both=����� .R�A�  A� Rows$ 1��$��RightToLeft=�$
��Left=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R��� � $��2��$��20 20q� �� $��* ��� $��5* �.+��� ���#121c1b$
��Bold"�$��22(�$��Center=�$��Right=�$#��غذاهای پیشنهادی���� -
   $ lst_suggests��$��1��$��Disabled=�$��Hidden=�$
 Both=�$��RightToLeft=����� .R�A� $ 1��$��RightToLeft=�$
��Left=����� " ��.���  � ��
 ���� ��  � �� �� " ��.R��� � $��1�� �� $	��330 ��� $��2* ��� $��2* ��� $��3* ��� $
��1.5* �.+�� $��0��$
��0 10q�.+��� -   $
��Mask�����#fcfcfc$��0q� �� CornerRadius$ 15���� .+�   CachedImage.Image  -     Name$ img_product��$��10q�$��Stretch=�$��Stretch=� �� BitmapScalingMode$
 Fant=�$��Uniform=�$	��290��$
��auto��$!��img/ic_chicken_and_ribs.jpg�� J� OpacityMask !�  !� Visual ��  �� ElementName$
 Mask��� $��1�� �� $��* ��� $��* �.+�� $��0�� �� $��* ��� $��* �.+��� -     ��Name$  	txt_price��$��0��$��Strikethrough{�$��RightToLeft=�$��25(�$
��Bold"�$��5q����#f44336$��Center=�$��Bottom=�$��25000���� -   $  txt_d_price��$��1��$��RightToLeft=�$��25(�$
��Bold"�$��5q����#00b356$��Center=�$	��Top=�$��25000���� -   $  txt_name��$��28(�$
��Bold"�$
��20 5q�$��1�����#121c1b$��Right=�$��Center=�$��جوجه کباب���� -   $  txt_description��$��2�����#121c1b$��20(�$
��Wrap=�$��Right=�$
��20 5q�$��RightToLeft=�$����لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون ��� $��3��$��0 0 0 60q� �� $��* ��� $��* �.+�� $��0��$��	10 0 10 0q� �� $	��150 ��� $��* �.+��� ���#121c1b$��1��$��2q�$��Center=�$
��Left=�$��
تعداد��$��22(�� $��0��$
��15 5q�$��Right=� �� $	��16* ��� $	��11* ��� $��5* ��� $	��16* �.+��� -   $ btn_up��$��75��$��75��$��Center=�$��Center=�$��0����Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�$��Center=�$��75��$��75���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]!   Kind$! KeyboardArrowUp=����#616161$	��0,6q��� -   $  	txt_count�����#00b356$��30(�$��	ExtraBold"�$��1��$��Center=�$��Center=�$��1��$��2���� -   $ btn_down��$��75��$��75��$��Center=�$��Center=�$��3����Z� ��Z� .��  $��Center=�$��Center=�$��75��$��75��$! KeyboardArrowDown=����#616161$	��0,6q�� $��1��$��Right=�$��0 0 30 0q� �� $��* ��� $��* �.+��� -   $  	txt_total��$��5q�$��RightToLeft=����#121c1b$�� ��$��25(�$
��Bold"�$��Center=�$��Center=�$��0���� $��5q����#616161$��   : جمع��$��25(�$
��Bold"�$��Center=�$��Center=�$��1��� $��4�� �� $��* ��� $��* �.+��� -   $ 
btn_cancel��$��20(�$��Normal"�$��10q�$
��auto��$��0�����	#FFFD1E1E$��بازگشت����Z� �� -   $ btn_add��$��20(�$��Normal"�$��10q�$
��auto��$��1�����#00b356$'��!افزودن به سبد خرید����Z� 