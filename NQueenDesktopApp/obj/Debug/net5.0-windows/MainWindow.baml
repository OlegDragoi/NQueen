   M S B A M L   `   `   `  ����K  GNQueenDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NQueenDesktopAppNQueenDesktopApp  5   	   !    NQueenDesktopApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NQueenDesktopApp     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         �Name$ Screen��5	       � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 
ChessBoard��5      $��0��5      $
��Auto��5      ��6   ��  �� RelativeSource �� *Self+ �� Path$ ActualHeight�5      � 5   
   -   5        $ Controls��5      $��1��5       .+�5!      �� $��
Grid size:��6   $
��Left=�6)   $��5,5,5,0q�6D   $	��Top=�6U   �� 5"      -   5         ��Name$ TbSize��5"      $��8��6&   $��Right=�6/   $��0,8,5,0q�6K    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $��30��6�   6�   �� 5#      -   5         ��Name$	 Rnd��5#      $��5,31,5,0q�5$      $��Random Solution��5%      $
��Auto��5&      $	��Top=�5'      6-   �� 5(      -   5        $ 	BackTrack��5(      $��5,56,5,0q�5)      $��BackTracked Solution��5*      $
��Auto��5+      $	��Top=�5,      6-   �� 5-      -   5        $ RndBackTrack_Copy��5-      $��5,81,5,0q�5.      $#��Randomized BackTrack Solution��5/      $
��Auto��50      $	��Top=�51      6)   �� 52      -	   5        	 ��Name$	 LblIndex��52      $��0��6&   $��Center=�62   $��0,0,0,0q�6O   $��Bottom=�6`   �� 53      -
   5        $ BtnDecrease��53      $��-1��6*   $
��Left=�67   $��5,0,0,5q�6R   $��Bottom=�6c   $��60��6~   6�   �� 54      -   5        $ BtnIncrease��54      $��+1��6*   $��Right=�67   $��0,0,5,5q�6S   $��Bottom=�6d   $��60��6   6�   55      56      57      