   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   J FMessengerClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MessengerClient.ConvertersMessengerClient.Converters 5   	       MessengerClient.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   >	Converter(clr-namespace:MessengerClient.Converters     5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��800��6)   $	��450��65   $	��600��6E    � 	Resources 5      6 0MessengerClient.Converters.TextToBoleanConverter   textToBoleanConverter2 ,MessengerClient.Converters.LastItemConverter  lastItemConverter; 5MessengerClient.Converters.ControlVisibilityConverter  controlVisibilityConverter��%W   &	        &	      &	 &       5   
   6*     5   
   6&     5   
   6/   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   o� 
�������.@�5      m� $��Написать��6   
������ 6)   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5      .+�5!      �� $��1q�6   
�������._�5"      � 
������� 5#      �� 5$      $
��auto �6(   �� 5%      $
��auto �6(   �� 5&      $
��auto �6(   �� 5'      .+�5*      �� $��50��6   $��10q�6)   �� 5,      $��1��6    �� CornerRadius$ 10��6*   
�������
�������$��1q�6g   $
��10,5q�6{   ._�5-      ]� .+�5.      �� $��15��6(   $��15��64   
������$��10,0,0,0q�6Q    J� OpacityMask 5/   "   !� 50   &    j� Stretch$ Uniform=�62     appbar_magnify !� Visual# �  6D   52      �� 54      -   5        $��tbSearch��54   3   $��1��6&   $��0,2,5,2q�6C   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Поиск...��55      $��0q�58   &   	   ClearTextButton	 56      �� 
 �� ElementName$
 tbSearch�� �� Path$
 Text� �� 	Converter# [  ��57      �� *
SearchText+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��58   :   5:      5;      5<      �� 5>      $��2��6    
�������6-   �� 5@      $��3��6Y   -   'MahApps.Metro.Controls.TabControlHelper   
Underlined$ SelectedTabItem=�5A   !   
������  �� SelectedIndex 5@   !   �� *SelectedTabIndex+$ TwoWay=�.@�5B      �� $��Беседы��6"   
������ y�62   �� $
 tbSearch��$
 Text�# [ .��5F      �� $��0q�6&   
���������6R   �� *Groups+ �� SelectedItem 6q   �� *SelectedGroup+��5G   "   �� 5H   &   .R�5I   *   �  �� ShowOnDisabled .  5J   .   �� 5K   2   �� 5L   2   .+�5O   .   �� $��Right=�6M   ��64   �� *Date+6M   ]� 5Q   .   $��1��68   .+�5R   2   �� $
��Left=�68   $��30��6g   ��6N   �� *Image+6g   �� 5S   2    .  �� 	IsEnabled .  � ContextMenu 5T   6   �� 5U   :   .@�5V   >   m� $��Написать��6G   5W   ;   .+�5Z   6   �� ��6@   �� *Name+5a   7   �� 5b   6   
���������6R   �� $ Messages�# [ 5c   3   5d   /   5e   +   5f   '   5h      5i      �� 5j      $��Люди��6"   
������ y�60   �� $
 tbSearch��$
 Text�# [ .��5l      �� $��0q�6(   
���������6T   �� *
FoundUsers+��5m   "   �� 5n   &   .R�5o   *   ]� $��1��64   .+�5p   .   �� $
��Left=�64   $��30��6c   ��6J   �� *Image+6c   �� 5q   .    .  .  5r   2   �� 5s   6   .@�5t   :   m� $��Написать��6C    m� Command 6U   �� *WriteMessageCommand+5u   7   .+�5w   2   �� ��5x   6   `� 5y   :    �� StringFormat$ {0} {1}��6G   .1�5z   >   �� $ 	FirstName�6F   �� 5{   >   $ LastName�6F   5|   ;   5~   3   �� 5   2   
���������6N   �� *Phone+5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      $
��auto �6$   .+�5�      �� -   5        $��
lbMessages��5�      
�������
���������5�      �� *
Messages+$ PropertyChanged=� 5�       �� 
TargetType �� Property �� Value �� 	Resources �� Color��%�   '��       �� 5�      " ��6    .�5�      ��  � ��
 ���� 6;    5�      ���� 5�   "   $ Transparent��6d   (��       62   * SystemColors.HighlightBrushKey+)6d   5�      5�      5�      ��5�      �� 5�      .R�5�      $� $��Bottom=�65   5�      ��5�      �� 5�      .R�5�      �� $ 15��6%   
����·�$��10q�6L    J� Effect 5�   "   3  -System.Windows.Media.Effects.DropShadowEffect  5�   &      ShadowDepth$ 1Q�67      	Direction$	 300Q�6G   ._�5�   "   �� .+�5�   &   �� $
��Wrap=�6S   $	��200��6g   $��10q�6v   ��60   �� $ Content.Text�6v   5�   #   5�      5�      5�      �� 5�      
�������$��1��60   $ 10��6=    �� Padding$ 5q�6O   $��50,10q�6[   $	��500��6j   ._�5�      ]� .+�5�      �� -   5        $��butEmoji��5�   !   $��30��61   
������ $��0q�6U   $
��Left=�6i   �� 5�      -   5        $��butSend��5�   !   $��30��60   
������ $��0q�6T   )   #MahApps.Metro.Controls.ButtonHelper    CornerRadius$  8��6h   $��Right=�6�   ! � ToolTip$! Отправить��6�   {�5�   !   �� $
 	tbMessage��$
 Text�# [  ��5�   !   �� *SendMessageCommand+��6H   �� $
 	tbMessage��$
 Text�.��5�      �� $%��Resources\send_message_icon.png��6$   5�      �� 5�      -   5        $��	tbMessage��5�   "   $��0q�5�   "   
������ $��Center=�5�   "   $' !Введите сообщение��5�   "   5�      5�      5�      5�      5�      5�      