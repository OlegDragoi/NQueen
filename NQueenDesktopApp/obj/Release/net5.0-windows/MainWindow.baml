   M S B A M L   `   `   `  ���� K  GNQueenDesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NQueenDesktopAppNQueenDesktopApp  !    NQueenDesktopApp.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NQueenDesktopApp     -     � Title$  
MainWindow��$	��450��$	��800��.��� -    �Name$ Screen�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� -    ��Name$ 
ChessBoard��$��0��$
��Auto������  �� RelativeSource �� *Self+ �� Path$ ActualHeight�� -   $ Controls��$��1��.+��� $��
Grid size:��$
��Left=�$��5,5,5,0q�$	��Top=��� -    ��Name$ TbSize��$��8��$��Right=�$��0,8,5,0q� �� TextWrapping$
 Wrap=�$	��Top=�$��30���� -    ��Name$	 Rnd��$��5,31,5,0q�$��Random Solution��$
��Auto��$	��Top=��� -   $ 	BackTrack��$��5,56,5,0q�$��BackTracked Solution��$
��Auto��$	��Top=��� -   	 ��Name$	 LblIndex��$��0��$��Center=�$��0,0,0,0q�$��Bottom=��� -	   $ BtnDecrease��$��-1��$
��Left=�$��5,0,0,5q�$��Bottom=�$��60���� -
   $ BtnIncrease��$��+1��$��Right=�$��0,0,5,5q�$��Bottom=�$��60��