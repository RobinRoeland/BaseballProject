   M S B A M L   `   `   `  ����G  CBaseballCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BaseballCalcBaseballCalc  5   	       BaseballCalc.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BaseballCalc     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      ��5   
   !� 5       j� TileMode$
 Tile=�6    j� Viewport$ 0.8,2.8,0.09,0.15�6*    j� 
AlignmentX$
 Left=�6H    j� 
AlignmentY$	 Top=�6Z    !� Visual 5      �� 5      $��Imgs/baseball.png��6   69   5      .+�5   
   � -   5         �Name$ Titlebar��5      $��28��6!   $	��Top=�6-   ���	#FF26268D$��0,-2,0,0q�6v   .+�5      �� -   5        	 ��Name$	 Title��5      $��BaseBall Project��6#   $
��Left=�6>   $��Center=�6Y   $	��166��6t   ���	#FF519AFF
 � Cursor$

 Hand��6�   $��Bodoni MT Black)�6�   $��18(�6�   $��28��6�    �� TextAlignment$ Center=�6�   �� 5      -   5         ��Name$ Closebtn��5      $��X��6'   $��0,4,4,0q�63   $	��Top=�6D   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6s   ��  �� ElementName$ 	rectangle�� �� Mode$ OneWay=�6�   �� 5      -   5        $ MiniMaxibtn��5      $	��◙��6*   $��0,4,34,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   �� 5      -   5        $ Minimizebtn��5      $��-��6*   $��0,4,64,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   5      �� 5   
   -   5         ��Name$ cb��5       �� 
IsEditable$
 True��6   $��0,39,4,0q�6O   $��Right=�6a   $��67��6}   $��20��6�   $	��Top=�6�   .@�5      �� -   5         ��Name$ 
cbselecter��5   2   $y�	Collapsed=�6    �� 
IsSelected$
 True��6F   $��Color��6X   �� 5      $
��Blue��6   �� 5      $
��Gray��6   5      � 5!   
   $��159,28,159,0q�6   
������� � ColumnDefinitions 5"      �� 5#      $
��195* �6#   �� 5$      $	��44* �6#   �� 5%      $
��243* �6#   .+�5'      �� $��181,85,181,0q�6   $��Imgs/logo.png��6*   $��3��6A   $	��118��6U   $	��Top=�6b   �� 5(      -   5        $ Statsbtn��5(      $��
Statistics��6'   $��142,218,30,0q�6<   $��2��6�   $��20��6�   $	��Top=�6�   ��6R   �� $ 	rectangle��$ OneWay=�6�   �� 5)      -	   5        $ 
WebShopbtn��5)      $��Webshop��6)   $��30,218,144,0q�6;   $��2��6�   $��20��6�   $	��Top=�6�   ��6Q   �� $ 	rectangle��$ OneWay=�6�   �� 5*      $��2��6   $��129,287,17,0q�6(   $��/Imgs/stats.png��6>   $
��Fill=�6W   $��98��6f   $	��Top=�6r   �� 5+      $��13,271,126,43q�6   $��/Imgs/shop.png��6+   $
��Fill=�6C   $��2��6R   �� 5,      $��2��6   $��129,276,17,48q�6(   $��/Imgs/stats.png��6?   $
��Fill=�6X   5-      5.      5/      