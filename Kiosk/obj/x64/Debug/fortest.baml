   M S B A M L   `   `   `  ����	  Kiosk    Kiosk.fortest   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      6controls'using:Microsoft.Toolkit.Uwp.UI.Controls  5   
   -   5        
�������   MaterialDesignBody#���   5   	     iransans#��[ 5   	   $	��400��5	   	   $	��600��6   
�������  � 
ResizeMode$  NoResize=�65    � WindowState$ 	Maximized=�6K   $��iransans)�6{   .��5
      � .+�5+   
   � $��Center=�6   $��Center=�6-    � 	Resources 5,       �� 
TargetType �� Property �� Value��%�  '��       '�     '�� U    �� 5-      " ��6   .�5.      ��  � ��
 �����63   �� 5/       � ��$
 Bold"�63   �� 50       � ��$ 35(�61   �� 51       � ��$ Center=�6<   �� 52       � ��$ Center=�6:   �� 53       � ��$ ALERT��6-   54      �� 55      " �6   .�56      ��  � ��$
 0,10q�6/   57      �� 58      " ��6   .�59      ��  � ��$ 50��6/   �� 5:       � ��$	 150��6.   5;      5<      .+�5>      �� .+�5A      � .+�5C      �� -   5         ��Name$ AlertBox��5C       
����  � �� StrokeDashOffset$ 2Q�5E       �� StrokeDashArray$ 5R�6-   $��5q�6A   ��5F      �� 5G      	 �� 
StartPoint$		 0,0&�62   
 �� EndPoint$

 10,8&�6C    � MappingMode$ Absolute=�6S    � SpreadMethod$ Repeat=�6j   .��5H   "   �  � Color$
 Blue��6/    � Offset$
 0.15Q�6<   � 5I   "   $ #00ff00��6/   $
 0.15Q�6?   5J      5L      �� 5N      5P      � 5U      .+�5V      �� -   5         ��Name$ PulseBox��5V      
���  �� J� RenderTransformOrigin$ 0.5,0.5&�5W   *   z�5X      V� 5Y      .~�5Z   "   �� �� 5[   "   �� 5\   "   T� 5]   "   5^      ._�5a      �� 5c      5d      � 5i      .+�5j      �� -   5        $ 
FlipperBox��5j      
���  ��z�5l      V� 5m      .~�5n   "   �� �� 5o   "   �� 5p   "   T� 5q   "   5r      ._�5u      �� 5w      5x      � 5}      .+�5~      �� -   5        $ 
ElasticBox��5~       
���  ��$��5��5   $   $��5q�68   ��5�      �� 5�      $		 0,0&�62   $	
 6,4&�6C   $ Absolute=�6R   $ Repeat=�6i   .��5�   "   � $	 Red��6/   $
 0.25Q�6;   � 5�   "   $ 	#00000000��6/   $
 0.15Q�6A   5�      5�      �� 5�      5�      � 5�      .+�5�      �� 
���  ��6    �� 5�      -   5        $ KRBox��5�       $��50��6/   
�������$ 0.5,0.5&�6G   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      5�      �� 5�      
���  ��6    5�      5�      5�      5�       5�        MarchingAnts g� 	BeginTime �� 
TargetName �� TargetProperty	 W� To g� Duration g� RepeatBehavior W� From 	 Pulse9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  Flipper8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value  ElasticLines g� AutoReverse  KnightRider��%>  &	       &	 3    &	 .    &	     &	 �    �� 5�   
   .��5�      W� $ 00:00:00X�6   $ AlertBox��5�   !   $ StrokeThickness�5�   !   $ 4X�5�   !   $ 0:0:0.25D�5�   !   W� 5�      $ 00:00:00X�6   $ Forever��63   $ AlertBox��6L   $ StrokeDashOffset�6m   $ 0:3:0D�5�   !   $
 1000X�62   $ 0X�6>   5�      �� 5�   
   $ Forever��6#   .��5�      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $ PulseBox��6�   .\�5�        $ 0:0:0.5��6'   $
 1.15Q�69     5�      $ 0:0:1��6'   $ 1Q�67   5�      U� 5�      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ PulseBox��6�   .\�5�        $ 0:0:0.5��6'   $
 1.15Q�69     5�      $ 0:0:1��6'   $ 1Q�67   5�      5�      �� 5�   
   $ Forever��6%   .��5�      *� $' !(UIElement.RenderTransformOrigin)�6+   $ 
FlipperBox��6i   .'�5�        $ 0:0:1��6&   $ 0.5,0.5&�66     5�      $ 0:0:2��6&   $ 0.5,0.5&�66   5�      U� 5�      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $ 
FlipperBox��6�   .\�5�        $ 0:0:1��6'   $ -1Q�67     5�      $ 0:0:2��6'   $ 1Q�67   5�      5�      �� 5�   
   $ Forever��6*    . .��5�      *� $1 +(Shape.Fill).(LinearGradientBrush.EndPoint)�6+   $ 
ElasticBox��6s   .'�5�        $ 0:0:4��6&   $
 12,8&�66   5�      5�      �� 5�   
   $ Forever��6)    . .��5�      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ KRBox��6�   .\�5�        $ 0:0:1��6'   $	 -50Q�67     5�      $ 0:0:2��6'   $ 50Q�67     5�      $ 0:0:3��6'   $ 0Q�67   5�      5�      5�       � Triggers 5�      :� 5�   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5�      �� #��[ 6   �� 5�      #��[ 6   �� 5�      #��[ 6   �� 5�      #��[ 6   �� 5�      #��[ 6   5�      5�      