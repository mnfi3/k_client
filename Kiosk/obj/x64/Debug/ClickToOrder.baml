   M S B A M L   `   `   `  ����F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  5   	   	 Kiosk   Kiosk.ClickToOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   FcachedImage.clr-namespace:CachedImage;assembly=CachedImage     5   	   -   5          � Title$  ClickToOrder��5   	   
 � Top$ 0��6    � Left$ 0��6'    � 
ResizeMode$ NoResize=�60    � AllowsTransparency .  � WindowStyle$
 None=�6x   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�6�   .��5      �  � 	Resources 5   
    �� 
TargetType �� Property	 �� Value��%4  '��       �� 5	      " ��6   .�5
      ��  � ��
	 �����6/   �� 5       � ��$	 85(�6-   �� 5       � ��$	 40,20q�6+   �� 5       � ��$	 Center=�68   �� 5       � ��$	 Center=�66   �� 5       � ��$)	 #برای سفارش لمس کنید��6)   5      5      .+�5   
      CachedImage.Image  -   5        
  Name$
 
img_splash��5   S    �� BitmapScalingMode$
 Fant=�6   $
��Fill=�6D   $
��auto��6g   $��0q�6t   $
��auto��6   $��1��6�   $��/img/click_to_order.jpg��6�   6�   �� 5   
   -   5         ��Name$ PulseBox��5      
������  J� RenderTransformOrigin$ 0.5,0.5&�5   2   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      ._�5      �� -   5        
�������$��4q�5   )    �� CornerRadius$ 30��6=   $��center=�6O   $��Center=�6j   ._�5      �� 
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          ShadowDepth$ 0Q�6+      Color$ Black��6;      
BlurRadius$ 10Q�6I   5"      5#      5$      5%       5(       	  Pulse g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%  &	        �� 5*   
   $ Forever��6#   .��5+      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ PulseBox��6�   .\�5,        $ 0:0:1��6'   $
 1.15Q�67     5-      $ 0:0:2��6'   $ 1Q�67   5.      U� 5/      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ PulseBox��6�   .\�50        $ 0:0:1��6'   $
 1.15Q�67     51      $ 0:0:2��6'   $ 1Q�67   52      53      55       � Triggers 56      :� 57   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�58      �� #��[  6   6D   59      5;      