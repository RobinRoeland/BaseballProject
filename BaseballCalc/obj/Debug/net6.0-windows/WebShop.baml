   M S B A M L   `   `   `  ����G  CBaseballCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BaseballCalcBaseballCalc  5   	       BaseballCalc.WebShop   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BaseballCalc     5   	     � Title$  WebShop��5   	   $	��450��6   $	��800��6&    � WindowStyle$
 None=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      ��5   
   !� 5       j� TileMode$
 Tile=�6    j� Viewport$ 0.8,2.8,0.09,0.15�6*    j� 
AlignmentX$
 Left=�6H    j� 
AlignmentY$	 Top=�6Z    !� Visual 5      �� 5      $��Imgs/baseball.png��6   69   5      .+�5   
   � -   5         �Name$ Titlebar��5      $��28��6!   $	��Top=�6-   ���	#FF26268D$��0,-2,0,0q�6v   .+�5      �� -   5        	 ��Name$	 Title��5      $��BaseBall Project��6#   $
��Left=�6>   $	��166��6Y   ���	#FF519AFF
 � Cursor$

 Hand��6|   $��Bodoni MT Black)�6�   $��18(�6�    �� TextAlignment$ Center=�6�   6�   �� 5      -   5         ��Name$ Closebtn��5      $��X��6'   $��0,4,4,0q�63   $	��Top=�6D   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6s   ��  �� ElementName$ 	rectangle�� �� Mode$ OneWay=�6�   �� 5      -   5        $ MiniMaxibtn��5      $	��◙��6*   $��0,4,34,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   �� 5      -   5        $ Minimizebtn��5      $��-��6*   $��0,4,64,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   5      �� 5   
   -   5         ��Name$ cb��5       �� 
IsEditable$
 True��6   $��0,39,4,0q�6O   $��Right=�6a   $��67��6}   $��20��6�   $	��Top=�6�   .@�5      �� -   5         ��Name$ 
cbselecter��5   2   $y�	Collapsed=�6    �� 
IsSelected$
 True��6F   .��6X   Color6_   �� 5      .��6   Blue6!   �� 5      .��6   Gray6!   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ Prods��5       $��10,39,76,10q�6"   �� 5!   
   -	   5        $��Add To cart��5!   '   $��0,65,4,0q�6=   $��20��6O   $	��Top=�6[   $��Right=�6s   $��66��6�   �� 5"   
   -
   5        $ Checkoutbtn��5"      $y�Hidden=�69   $��Checkout��6M   $��0,90,4,0q�6`   $��20��6r   $	��Top=�6~   $��Right=�6�   $��66��6�   5#      5$      