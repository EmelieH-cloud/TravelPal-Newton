   M S B A M L   `   `   `  ����K  GTravelPal-Newton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TravelPal_Newton.WindowsTravelPal_Newton.Windows  5   	   )    #TravelPal_Newton.Windows.InfoWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TravelPal_Newton.Windows     5   	     � Title$  
InfoWindow��5   	   $	��400��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6[    � AllowsTransparency$
 True��6o   
������ .��5	      ��  �� CornerRadius$ 35��6   $��24q�6   ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #1b0d71��6    � Offset$	 0.5Q�6/   5      ._�5   
   � ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ #6553d9��6#   $	 0.2Q�63   � 5      $ #231195��6#   $	 0.4Q�63   � 5      $ #1b0d71��6#   $	 0.7Q�63   � 5      $ MediumSlateBlue��6#   $	 0.1Q�6<   5      	 � ColumnDefinitions	 5      �� 5      �� 5      �� 5      �� 5      
 � RowDefinitions
 5   
   �� 5      �� 5       �� 5!      �� 5"      .+�5$      �� $��How to use TravelPal��6   $��Microsoft YaHei UI Light)�64   $��0��6Z   $��0��6g   
�������$��4��6�   $��Center=�6�   $��Center=�6�   $��22(�6�   �� 5%      $��5q�6   $����When using TravelPal you can register travels of three types: 'Vacation', 'Worktrip' or unspecified 'Travel'. All travels must have a type, country, destination, startdate and enddate.��6#   $��Microsoft YaHei UI Light)�6�   $��1��6	  $��0��6  
�������$��4��69  $��Center=�6M  $	��Top=�6j  $��16(�6�  $
��Wrap=�6�  �� 5&      $����After creating a travel there is an option to add items to a packinglist. Passport requirements are generated automatically, but the user must manually press 'register packinglist' for it to be saved.��6   $��Microsoft YaHei UI Light)�6�   $��2��6  $��0��6  
�������$��4��6?  $��Center=�6S  $	��Top=�6p  $��16(�6�  $
��Wrap=�6�  �� 5'      -   5        $��	btnClosew��5'      $��4��6&   $��X��66   $��40��6B   $��40��6M   $	��Top=�6Y   $��Right=�6q   $��18(�6�   6�   5(      5)      5*      