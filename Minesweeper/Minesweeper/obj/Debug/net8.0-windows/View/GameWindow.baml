   M S B A M L   `   `   `  ����  Minesweeper!    Minesweeper.View.GameWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$
  Game��5   	    � SizeToContent$ WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� .��5	   
   �� ��6   �� *Cells+��5
      �� 5      .R�5      A�  A� Rows 6"   �� *GameBoard.Rows+ A� Columns 6B   �� *GameBoard.Columns+5      ��5      �� 5      .R�5      �� $��30��5      $��30��6)   ��5      �� *DataContext.RevealCellCommand+ �� RelativeSource ��  �� AncestorType
 Window��5      �� ��5      �� 5      $��Center=�5   (   $��Center=�5   (   ��5   (   �� *.+   CellContentConverter �� 	Converter# [  5   (   	 J� InputBindings	 5      d� 5      
 d� Gesture$
 	LeftClicka�6+    �� Command 6?   �� *DataContext.RevealCellCommand+ �� 
 Window �� CommandParameter 6�   �� d� 5      $
 
RightClicka�6+    6@   �� *DataContext.ToggleFlagCommand+ �� 
 Window 6�   �� 5      5      5       5!      5"      