   M S B A M L   `   `   `  ����F  BProgPartOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProgPartOneProgPartOne  5   	       ProgPartOne.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProgPartOne     5   	     � Title$  
MainWindow��5   	   $	��550��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � 
ResizeMode$ NoResize=�5
   	   .��5      � ��5   
   �� 5       �� ImageSource$ Images/bg3.png��5       j� Stretch$
 Fill=�5      5       � ColumnDefinitions 5   
   �� 5      $	��19* �6   �� 5      $	��13* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ callNumList��5      
������ 
������ 
�������$��32(�6t   $��	ExtraBold"�6�   $��0��6�   $��2��6�   $��20,38,170,10q�6�   $��Center=�6�   ��5       �� 5!      .R�5#      �� ��6    �� 5$      ��5&      �� 5'      	 �� 
TargetType"	 ��6   .�5(      -   5        �� 5+      
 �� Property
 �@J�	AllowDrop �� Value . 62   5,      5.      �� 50   
   $��0��6   $��0��6    $*��$Arrange The Books In Ascending Order��6-   $��2��6\   $
��Bold"�6p   $��24(�6�   
���   �$��
336,60,0,0q�6�   $
��Left=�6�   $	��Top=�6�   $��50��6�   $	��464��6�   �� 51   
   -   5         ��Name$ startImg��51   *   $��/Images/play.png��6   $
��Left=�6o   $��74��6�   $	��Top=�6�   $	��100��6�    � Cursor$
 Hand��6�   $��
420,63,0,0q�6�   $��1��6�   $��2��6�   �� 52   
   -   5        $ 	submitImg��52   +   $��/Images/check.png��6   $��1��6r   $��
163,63,0,0q�6�   $
��Left=�6�   $��74��6�   $	��Top=�6�   $	��100��6�   $
 Hand��6�   $��1��6�   �� 53   
   -   5        $ 	returnImg��53   *   $��/Images/back.png��6   $��0��6q   $��
55,238,0,0q�6~   $
��Left=�6�   $��74��6�   $	��Top=�6�   $	��100��6�   $
 Hand��6�   $��1��6�   $��2��6�   �� 54   
   -   5        $ helpImg��54   *   $��/Images/info.png��6   $��1��6m   $��0��6}   $��0,138,195,0q�6�   $��Right=�6�   $��74��6�   $	��Top=�6�   $	��100��6�   $
 Hand��6�   � 57   
   -   5        $��
oneCorrect��57      ��.  $��Center=�61    � 	StaysOpen .  .��58      �� 
���  ��
���   �$��2q�6:   ._�59      �� .+�5;      �� $��/Image/info.png��6   $��75��65   $��75��6@   �� 5>      $%��1 Correct Answer Badge Acheived��6    $��Center=�6G   5?      5@      5A      � 5D   
   -   5        $��fiveCorrect��5D      ��.  $��Center=�62    .  .��5E      �� 
����  �
���   �$��2q�6;   ._�5F      �� .+�5H      �� $��/Image/info.png��6   $��75��65   $��75��6@   �� 5K      $&�� 5 Correct Answers Badge Acheived��6    $��Center=�6H   5L      5M      5N      5Q      5R      