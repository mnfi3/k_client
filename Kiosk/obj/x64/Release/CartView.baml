   M S B A M L   `   `   `  ���� F  BCachedImage, Version=0.1.8.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CachedImage;assembly=CachedImageCachedImage  	 Kiosk   Kiosk.CartView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  @cachedImage.clr-namespace:CachedImage;assembly=CachedImage  -   
�������   MaterialDesignBody#���   $=��7/Kiosk;component/fonts/iransans/#IRANSans(FaNum) Medium)�$	��900��$
��1400��
  � Top$  0�� � Left$ 0��
������� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=�.��� -    �Name$ grd_main�����#f4f4f4.+�� $��0 0 0 0q� � RowDefinitions �� $��0 ��� $��* �.+�� $��0�����#304FFE � ColumnDefinitions �� $��* ��� $��2* �.+��� $��20(�
�������$��Normal"�$��Center=�$��Center=�$��0��$$��مبلغ قابل پرداخت���� $��20(�
�������$��Normal"�$��Center=�$��Center=�$��1��$$��محتویات سبد خرید��� $��1�� �� $��* ��� $��2* �.+�� -   $ grd_pay��$��0��
�������.+��� -    ��Name$ btn_pay��
����������#00b356$��20(�$��70��$��پرداخت��$��50 10q�$��Bottom=�$��Stretch=�$��Light"���Z� � -   $ grd_payment��$��
0 10 0 100q�$��Stretch=�$��Stretch=�.+��� $��Stretch=�$��Stretch=�$��20q�
�������	 �� CornerRadius$	 10��._�� $��Stretch=�$��Stretch=�$��20q�
������� �� $
��0.8* ��� $��4* ��� $��4* ��� $��* �.+��� -   $ btn_back_to_restaurants��$��0��$��15(�$��50��
����������	#FFFD1E1E$��0q�$	��Top=�$
��Left=���Z� .���� 
 �� Orientation$
 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  
�������$��Center=�$
��Left=��  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardArrowLeft=�$��40��$��40���� 
�������$��20(�$
��Bold"�$��Center=�$��5q�$��بازگشت���� -    ��Name$ 	grd_price��$��1��$��5q����#ECEFF1$	 15��$��0q����#673AB7._��� $
 Vertical=�$��15q�$��Center=�$��Stretch=�.+��� 
���   �$
��10 5q�$��Right=�$��Center=�$��22(�$'��! : جمع مبلغ پرداختی���� -    ��Name$ txt_cost��$��RightToLeft=����#00b356$
��10 5q�$��Center=�$��Center=�$��22(�$�� ��$
��Bold"��� 
���   �$��
10 20 10 5q�$��Right=�$��Center=�$��22(�$0��* : مبلغ پرداختی با تخفیف���� -	   $ 
txt_d_cost��$��RightToLeft=����#00b356$
��10 5q�$��Center=�$��Center=�$��22(�$�� ��$
��Bold"��� -
   $ grd_discount��$��2��$��5q����#ECEFF1$	 15��$��0q����#673AB7._��� $��15q�$��Center=�$
 Vertical=�.+��� ���	#FF2251FF$��10q�$��6��$��Center=�$��20(�$��Light"� �� TextAlignment$ Right=�$��Bottom=�$C��=اگر کد تخفیف دارید آن را وارد کنید���� -    ��Name$ txt_discount_code��$��20q�)  #MaterialDesignThemes.Wpf.HintAssist   
IsFloating . ���#263238$�� ��$��RightToLeft=�$	��250��$��70��$��Center=�$��Stretch=�$��22(����#673AB7$
��Bold"�.��   Hint �� $��Right=����#37474F$,��&کد تخفیف را وارد کنید��$	��Top=�$��16(�$��Center=�$��RightToLeft=�$
��auto��.���� -   $ btn_discount�����	#FF2251FF
�������$��20q�$	��200��$��50��$	��Top=�$��Stretch=�$��18(�$��Light"�$ ��اعمال کد تخفیف����Z� �� -   $ grd_out��$��3��$��5q����#ECEFF1$	 15��$��0q����#673AB7._��� $
 
Horizontal=�$��Center=�.+��� -    ��Name$ chk_out��$
��10 0q����	#FF2251FF d� 	IsChecked$ FalseY� � LayoutTransform ��  �� ScaleX$ 2Q� �� ScaleY$ 2Q��� $
��10 0q�$��بیرون بر��$��Center=�
���   �$��20(�$��Center=�� -   $ grd_products��$��1��.+��� -    ��Name$ lst_cart��$��Disabled=�$��5q�$��Stretch=�$��Stretch=�$��Stretch=� �� PanningMode$
 Both=�$��Hidden=����� .R�A�  A� Columns$ 1��$	��Top=�$��Stretch=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � �� ��  �� 
TargetType" ��.R��� 