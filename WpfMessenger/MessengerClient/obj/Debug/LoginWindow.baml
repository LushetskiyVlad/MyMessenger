   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FMessengerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MessengerClient.ConvertersMessengerClient.Converters 5   	   !   MessengerClient.LoginWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   >	Converter(clr-namespace:MessengerClient.Converters     5   	     � Title$  LoginWindow��5	   	   $	��500��6   $	��350��6*    � 
ResizeMode$ CanMinimize=�5
   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6"    � 	Resources 5      /  )MessengerClient.Converters.ConfirmPasskey   ConfirmPasskey��%   &	          5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   �� -   5        $��
tabControl��5      $��0q�6'   .@�5      �� $y�	Collapsed=�6   .��5      �� -   5        $��	butSignUp��5      $��Center=�6.   $	��250��6I   .+�5      �� -   5        $��
Войти��5      $��5q�6-   
�������$��16(�5      
����� �)   #MahApps.Metro.Controls.ButtonHelper   CornerRadius$ 20��5         PreserveTextCase . 5   C   �� 5      -   5        $��butRegister��5      $0��*Создать учетную запись��60   
����� �
�������$��16(�5"      $ 15��5#       . $��5q�5$   C   6N   5%      5&      �� 5'      $y�	Collapsed=�6   .��5(      �  5)      �� 5*      $
��auto �6(   �� 5+      �� 5,      $
��auto �6(   .+�5/      �� -   5        $��butBack��5/      $��50��6,   $��50��67   $
��Left=�50      
����ح�  MetroCircleButtonStyle#���  51      .��52      �� $��20��6$   $��20��6/   
������ J� OpacityMask 53      !� 54   "    j� Stretch$
 Fill=�6.     appbar_arrow_left	 !� Visual#	 �  6=   56      57      �� 59      $��1��6   $��Center=�6*   $��Center=�6E   
�������
 �� CornerRadius$
 10��6x    J� Effect 5:      3  -System.Windows.Media.Effects.DropShadowEffect  5;         ShadowDepth$ 1Q�6/      	Direction$	 300Q�6?   ._�5>      �� $��Center=�6%   $	��250��6@   $��10q�6L   .+�5?      �� $��Вход��6$   $��Center=�63   $��24(�6P   �� 5@      $��5q�6(   �� 5A      $��
Логин��6$   $��16(�64   $
��Left=�6B   $
��10,0q�6]   �� 5B      -   5        $��tbLogin��5B   &   $
��10,5q�6Y   ��65   �� *Login+ �� Mode$ TwoWay=�6Y   �� 5C      $��Пароль��6$   $��16(�65   $
��Left=�6C   $
��10,0q�6^   G� 5E      -   5         G�Name$ 
pbPassword��5E   *   $��
10,5,10,10q�6>   $��0,0,20,0q�6R   �� 5H      -   5        $��butLogin��5H   %   $��
Войти��65   $��Center=�5I   %   $	��100��6B   $��14(�5J   %   $��Normal"�63    . ��5L   %   �� *LoginCommand+��6F   ��  �� ElementName$ 
pbPassword��5N      5O      5Q      5R      �� 5S      $y�	Collapsed=�6   .��5T      �  5U      �� 5V      $
��auto �6(   �� 5W      .+�5Z      �� -	   5        $��butBack1��5Z      $��50��6-   $��50��68   $
��Left=�5[      
����ح�#���  5\      .��5]      �� $��20��6$   $��20��6/   
������ 5^      !� 5_   "   $
 Fill=�6.   #	 �  6=   5a      5b      �� 5d      $
 5��6   $��1��6.   $��Center=�6;   $
��10,5q�6V   
������� 5e        5f      $ 1Q�6/   $	 300Q�6?   ._�5i      �� .+�5j      ]� $��Center=�6(   $��5q�6E   .+�5k   "   �� $��Center=�6,   $��65��6G   $��5q�6R   �� 5l   "   $��Регистрация��6(   
���OO/�$��Verdana)�6Y   $��22(�6n   �� 5m   "   $��Center=�6,   $��65��6G   $��5q�6R   5n      �� 5p      -
   5        $��
tbRegLogin��5p   &   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 
Логин��6f   $
��20,5q�6�   ��68   ��  �� Path$ 
User.Login�$ TwoWay=�6�   ]� 5r      $
��20,5q�6(   ��.  .+�5s   "   �� -   5        $��tbRegFirstName��5s   ~   $
��Left=�6*   $	��130��6r   $ Имя��6�   ��6@   �� $ User.FirstName�$ TwoWay=�6�   �� 5t   "   -   5        $��tbRegLastName��5t   ~   $��Right=�6*   $	��130��6r   $ Фамилия��6�   ��6A   �� $ User.LastName�$ TwoWay=�6�   5u      G� 5w      -   5        $��	pbRegPass��5w   *   $ Пароль��6;   $
��20,5q�6e   G� 5y      -   5        $��pbRegConfirmPass��5y   *   $) #Подтвердите пароль��6B   $
��20,5q�6x   �� 5{      -   5        $��
tbRegPhone��5{   &   $! Номер телефона��6f   $
��20,5q�6�   ��68   �� $ 
User.Phone�$ TwoWay=�6�   �� 5}      -   5        $��
tbRegEmail��5}   &   $ Email��6f   $
��20,5q�6�   ��68   �� $ 
User.Email�$ TwoWay=�6�   �� 5      $(��"Зарегистрироватся��6%    . $��16(�5�   %   $��Medium"�63   $��20,10q�6G   $��45��6V   ��5�   %   �� *RegisterCommand+��5�   "   `� 5�   &    `� 	Converter# [  63    `� Mode$ OneWay=�6_   .1�5�   *   �� $ 	pbRegPass��62   �� 5�   *   $ pbRegConfirmPass��62   5�   '   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $��stackPanel1��5�      $��1��6(   $y�	Collapsed=�65   .+�5�      -   'MahApps.Metro.Controls.MetroProgressBar  -   5        $��progressBar��5�   (   $��10q�6;    � IsIndeterminate 6G   �� *
IsLoaded+�� 5�      -   5        $��	tbMessage��5�      $
��Wrap=�6)   
���  ��$��
30,0,30,30q�6N   5�      5�      5�      