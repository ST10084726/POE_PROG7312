   M S B A M L   `   `   `  ����F  BProgPartOne, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProgPartOneProgPartOne  5   	       ProgPartOne.Home   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProgPartOne     5   	     � Title$
  Home��5   	   $	��650��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.    � 
ResizeMode$ NoResize=�5
   	   .��5      � ��5   
   �� 5       �� ImageSource$ Images/bg1.jpg��5       j� Stretch$
 Fill=�5      5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ ReplBookImg��5   �   $��/Images/replacing.png��6   $
��Fill=�6/   $
��Left=�6>   $	��275��6Y   $	��Top=�6f   $	��424��6~    � Cursor$
 Hand��6�   $��
376,10,0,0q�6�   $��2��6�   �� 5   
   -   5        	 ��Name$	 ReplBookText��5   �   $��560,145,0,0q�6   
���   �$��Italic$�6<   $
��Bold)�6O   $
��Left=�6a   $
��Wrap=�6|   $��Replacing Books��6�   $��16(�6�   $	��Top=�6�   $
 Hand��6  
 J� RenderTransformOrigin$
 0.5,0.5&�6(  z�5      V� 5      .~�5      �� �� 5       �� 5!       �� Angle$ 4.968Q�6&   T� 5"      5#      5%      �� 5'   
   -   5        $ 	idAreaImg��5'   �   $��/Images/finding.png��6   $
��Fill=�6-   $
��Left=�6<   $	��275��6W   $	��Top=�6d   $	��424��6|   $
 Hand��6�   $��223,205,0,0q�6�   $��3��6�   �� 5(   
   -   5        $	 
idAreaText��5(   �   $��395,123,0,0q�6   
���   �$��Italic$�6<   $
��Bold)�6O   $
��Left=�6a   $
��Wrap=�6|   $��Identifying Areas��6�   $��16(�6�   $	��Top=�6�   $
 Hand��6  $��1��6&  $
 0.284,-0.171&�63  z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      $ 4.622Q�6&   T� 5.       T� X$ 1.234Q�6)    T� Y$ -2.026Q�63   5/      51      �� 54   
   -   5        $ 
findNumImg��54   �   $��/Images/matching.png��6   $
��Fill=�6.   $
��Left=�6=   $	��275��6X   $	��Top=�6e   $	��424��6}   $
 Hand��6�   $��366,148,0,0q�6�   $��1��6�   $��2��6  �� 55   
   -   5        $	 findNumText��55   �   $��
528,67,0,0q�6   
���   �$��Italic$�6<   $
��Bold)�6O   $
��Left=�6a   $
��Wrap=�6|   $��Finding Call Numbers��6�   $��16(�6�   $	��Top=�6�   $
 Hand��6  $��2��6+  $
 0.5,0.5&�68  z�56      V� 57      .~�58      �� �� 59      �� 5:      $ 4.262Q�6&   T� 5;      5<      5>      �� 5@   
   $��Dewey Decimal Training��6   $��Center=�61   $
��Bold"�6N   $��30(�6`   
�������$	��Top=�6�   $��50��6�   $	��354��6�   $��0,9,0,0q�6�   �� 5B   
   -   5        $ exitImg��5B   y   $��/Images/exit.png��6   $��Right=�6*   $��75��6F   $��Bottom=�6R   $	��750��6m   $
 Hand��6�   $��	0,0,10,10q�6�   $��2��6�   5F      5G      