   M S B A M L   `   `   `  ����K  GTravelPal-Newton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TravelPal_Newton.WindowsTravelPal_Newton.Windows  5   	   *    $TravelPal_Newton.Windows.UserDetails   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TravelPal_Newton.Windows     5   	     � Title$  UserDetails��5   	   $	��330��6   $	��600��6*    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�6I    � AllowsTransparency$
 True��6o   
������  � 	Resources 5	         Buttons �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value��%c  &	        �� 5
   
   " ��6    .�5      ��  � ��$ 22(�6)   �� 5       � ��$	 160��6&   �� 5       �@�FocusVisualStyle 61   Z� �� 5       � ��$	 0 8q�6'   �� 5       � ��
 �����6+   �� 5       � �� �#a295f36+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 6��6!   $��0q�62   #��z��6F   
�������._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      
 5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#160a5a63   5      5      5       .��5!      �� $	 35��6   $��24q�6   ��5"   
   �� 5#       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5$      �  � Color$ #3d22e6��6    � Offset$	 0.4Q�6/   � 5%      $ #1b0d71��6   $	 0.4Q�6/   5&      ._�5(   
   �  � ColumnDefinitions 5)      �� 5*      �� 5+      �� 5,      �� 5-       � RowDefinitions 5/      �� 50      �� 51      �� 52      �� 53      �� 54      �� 55      ��57      �� 58      $	 0,0&�6"   $	 1,1&�63   .��59      � $ #231195��6   $	 0.7Q�6/   � 5:      $ #3d22e6��6#   $	 0.5Q�63   � 5;      $ #1b0d71��6#   $	 0.2Q�63   5<      .+�5>      �� -   5        $��btnCloseWindow��5>   B   #��[  6   $	��100��66   $��5��6X   $��Close��6h   6x   �� 5?      -   5        $��txtUsername��5?      $	��200��6)   $��1��65   $��1��6E   $��2��6R   $��8q�6f   $��Center=�6q   $��Center=�6�   �� 5@      -   5        $��txtuserLocation��5@      $	��200��6-   $��1��69   $��2��6I   $��2��6V   $��8q�6j   $��Center=�6u   $��Center=�6�   �� 5A      $��	Username:��6   
�������$��0��6;   $��1��6K   $��Center=�6X   $��Center=�6|   $��16(�6�   �� 5B      $��
Residence:��6   
�������$��0��6<   $��2��6L   $��Center=�6Y   $��Center=�6}   $��16(�6�   �� 5C      $��
EU member:��6   
�������$��0��6<   $��3��6L   $��Center=�6Y   $��Center=�6}   $��16(�6�   �� 5D      -   5        $��lblEUmember��5D      $�� ��6'   
�������$��1��6E   $��3��6U   $��Center=�6b   $��Center=�6�   $��16(�6�   5E      5F      5G      