   M S B A M L   `   `   `  ���� @  <Kiosk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Kiosk.controlKiosk.control  F BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage     Kiosk.ClickToOrder   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /controlclr-namespace:Kiosk.control     FcachedImage.clr-namespace:CachedImage;assembly=CachedImage     -     � Title$  ClickToOrder��
 � Top$ 0�� � Left$ 0�� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=�$=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�.��� -    � 	Resources  �� 
TargetType �� Property	 �� Value��%�   '��       �� " ��.���  � ��
	 �������  � ��$	 85(���  � ��$	 40,20q���  � ��$	 Center=���  � ��$	 Center=���  � ��$)	 #برای سفارش لمس کنید��.+�  CachedImage.Image  -   
  Name$
 
img_splash�� �� BitmapScalingMode$
 Fant=�$
��Fill=�$
��auto��$��0q�$
��auto��$��1��$��/img/click_to_order.jpg���� -    ��Name$ PulseBox��
������  J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._��� -   $ brdr_click_to_order��
�������$��4q� �� CornerRadius$ 30��$��center=�$��Center=�._��� 
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   Color$ Black��   
BlurRadius$ 10Q��� -   $ brdr_description��$��20q�$��Center=�$	��Top=�$ 20�����	#af000000._��� -    ��Name$ txt_description��$��Center=�$	��Top=�$��خوش آمدید��$��20(�"   Kiosk.control.CircleProgress  -     Name$ prg_wait��$��0 0 0 0q�$y�	Collapsed=�$	��300��$	��300��  	  Pulse g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%f  &	        �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:1��$
 1.15Q�  $ 0:0:2��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:1��$
 1.15Q�  $ 0:0:2��$ 1Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[  