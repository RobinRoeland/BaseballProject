   M S B A M L   `   `   `  ����G  CBaseballCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BaseballCalcBaseballCalc  5   	       BaseballCalc.StatsPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BaseballCalc     5   	     � Title$  	StatsPage��5   	   $	��450��6   $	��800��6(    � WindowStyle$
 None=�5	   	   .��5
      � ��5   
   !� 5       j� TileMode$
 Tile=�6    j� Viewport$ 0.8,2.8,0.09,0.15�6*    j� 
AlignmentX$
 Left=�6H    j� 
AlignmentY$	 Top=�6Z    !� Visual 5      �� 5      $��Imgs/baseball.png��6   69   5      .+�5   
   � -   5         �Name$ Titlebar��5      $��28��6!   $	��Top=�6-   ���	#FF26268D$��0,-2,0,0q�6v   .+�5      �� -   5         ��Name$ Title��5      $��BaseBall Project��6#   $
��Left=�6>   $	��166��6Y   ���	#FF519AFF	 � Cursor$
	 Hand��6|   $��Bodoni MT Black)�6�   $��18(�6�   
 �� TextAlignment$
 Center=�6�   6�   �� 5      -   5         ��Name$ Closebtn��5      $��X��6'   $��0,4,4,0q�63   $	��Top=�6D   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6s   ��  �� ElementName$ 	rectangle�� �� Mode$ OneWay=�6�   �� 5      -   5        $ MiniMaxibtn��5      $	��◙��6*   $��0,4,34,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   �� 5      -   5        $ Minimizebtn��5      $��-��6*   $��0,4,64,0q�66   $	��Top=�6H   ���	#FF304998���	#FFBDBDBD$��Right=�6�   $��29��6�   ��6w   �� $ 	rectangle��$ OneWay=�6�   5      �� 5   
   -   5         ��Name$ cb��5       �� 
IsEditable$
 True��6   $��0,39,4,0q�6O   $��Right=�6a   $��67��6}   $��20��6�   $	��Top=�6�   .@�5      �� -   5         ��Name$ 
cbselecter��5   2   $y�	Collapsed=�6    �� 
IsSelected$
 True��6F   .��6X   Color6_   �� 5      .��6   Blue6!   �� 5      .��6   Gray6!   5      �� 5   
   -   5         ��Name$ 
TeamSearch��5      $
��Left=�6&   $��23��6A   $��	10,39,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��106��6�   6�   �� 5   
   -	   5         ��Name$ TeamList��5      $
��Left=�6%   $��
10,62,0,10q�6@   $	��106��6T   5      �� 5    
   -
   5        $ PlayerSearch��5       $
��Left=�6(   $��23��6C   $��
116,39,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��104��6�   6�   �� 5!   
   -   5        $ 
PlayerList��5!      $
��Left=�6'   $��116,62,0,10q�6B   $	��104��6W   6c   �� 5#   
   $��220,39,76,10q�6   .@�5$      �� $��Selected Player��6   $��0,0,0,0q�6/   .��5%      &   System.Windows.Controls.DataGrid  -   5          Name$ Stats��5%      $��0,0,0,0q�6*      
IsReadOnly$
 True��6;   ��5&      �� 5'       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5(      -   5        5*      5,      5-      �� 5.      $��League Stats��6   $��0,0,0,0q�6,   .��5/        -   5        $ LeagueStats��5/      $��0,0,0,0q�60   $
 True��6A   50      51      �� 53   
   -   5        $ addbtn��53      $��0,62,4,0q�6!   $	��Top=�63   $y�Hidden=�6K   $��
Add Player��6_   $��20��6t   $��Right=�6�   $��67��6�   �� 54   
   -   5        $ 
addcombobx��54      $��0,62,4,0q�6D   $��67��6V   $��20��6a   $	��Top=�6m   $��Right=�6�   $y�Hidden=�6�   .@�55      �� -   5        $ Additem��55      $y�	Collapsed=�6-   $
 True��6D   $	��Add��6V   �� 56      $��Player��6   �� 57      $��Season��6   58      �� 59   
   -   5        $ EditCb��59      $y�Hidden=�6#   $
 True��67   $��0,85,4,0q�6i   $��Right=�6{   $��67��6�   $��20��6�   $	��Top=�6�   .@�5:      �� -   5        $ emptycomboselect��5:      $y�	Collapsed=�65   $
 True��6L   $��Actions��6^   �� 5;      $
��Edit��6   �� 5<      $��Remove��6   5=      5>      5?      