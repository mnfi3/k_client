   M S B A M L   `   `   `  ���� 	  Kiosk    Kiosk.fortest   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6controls'using:Microsoft.Toolkit.Uwp.UI.Controls  -   
�������   MaterialDesignBody#���     iransans#��[ $	��400��$	��600��
�������  � 
ResizeMode$  NoResize=� � WindowState$ 	Maximized=�$��iransans)�.��� .+�� $��Center=�$��Center=� � 	Resources  �� 
TargetType �� Property �� Value��%  '��       '� �     '�� �     �� " ��.���  � ��
 �������  � ��$
 Bold"���  � ��$ 35(���  � ��$ Center=���  � ��$ Center=���  � ��$ ALERT���� " �.���  � ��$
 0,10q��� " ��.���  � ��$ 50����  � ��$	 150��.+��� .+�� .+��� -    ��Name$ AlertBox��
����  � �� StrokeDashOffset$ 2Q� �� StrokeDashArray$ 5R�$��5q����� 	 �� 
StartPoint$		 0,0&�
 �� EndPoint$

 10,8&� � MappingMode$ Absolute=� � SpreadMethod$ Repeat=�.���  � Color$
 Blue�� � Offset$
 0.15Q�� $ #00ff00��$
 0.15Q��� � .+��� -    ��Name$ PulseBox��
���  �� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� ._��� � .+��� -   $ 
FlipperBox��
���  ��z�V� .~��� �� �� T� ._��� � .+��� -   $ 
ElasticBox��
���  ��$��5��$��5q����� $		 0,0&�$	
 6,4&�$ Absolute=�$ Repeat=�.��� $	 Red��$
 0.25Q�� $ 	#00000000��$
 0.15Q��� � .+��� 
���  ���� -   $ KRBox��$��50��
�������$ 0.5,0.5&�z�V� .~��� �� �� T� �� 
���  ��   MarchingAnts g� 	BeginTime �� 
TargetName �� TargetProperty	 W� To g� Duration g� RepeatBehavior W� From 	 Pulse9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  Flipper8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value  ElasticLines g� AutoReverse  KnightRider��%�  &	       &	 �     &	     &	 W    &	 �    �� .��W� $ 00:00:00X�$ AlertBox��$ StrokeThickness�$ 4X�$ 0:0:0.25D�W� $ 00:00:00X�$ Forever��$ AlertBox��$ StrokeDashOffset�$ 0:3:0D�$
 1000X�$ 0X��� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ PulseBox��.\�  $ 0:0:0.5��$
 1.15Q�  $ 0:0:1��$ 1Q�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ PulseBox��.\�  $ 0:0:0.5��$
 1.15Q�  $ 0:0:1��$ 1Q��� $ Forever��.��*� $' !(UIElement.RenderTransformOrigin)�$ 
FlipperBox��.'�  $ 0:0:1��$ 0.5,0.5&�  $ 0:0:2��$ 0.5,0.5&�U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�$ 
FlipperBox��.\�  $ 0:0:1��$ -1Q�  $ 0:0:2��$ 1Q��� $ Forever�� . .��*� $1 +(Shape.Fill).(LinearGradientBrush.EndPoint)�$ 
ElasticBox��.'�  $ 0:0:4��$
 12,8&��� $ Forever�� . .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ KRBox��.\�  $ 0:0:1��$	 -50Q�  $ 0:0:2��$ 50Q�  $ 0:0:3��$ 0Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� #��[ �� #��[ �� #��[ �� #��[ �� #��[ 