   M S B A M L   `   `   `  ����  Devoluciones    Devoluciones.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Devoluciones��5   	   $	��450��6   $	��700��6+   ���#1E1E2C.��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   $��Center=�6M   .+�5      �� $��ID de Préstamo:��6   $��Center=�6/   ���#D5CCC7$��16(�6_   $��0,0,10,0q�6m   �� 5      -   5         ��Name$ txtPrestamoID��5      $	��200��6-   $��30��69   $��5q�6E   ���#404053
�������$��0q�5   >   �� 5      -   5         ��Name$ btnBuscarPrestamo��5      $��Buscar��60   $	��120��6A   $��30��6M   $��10,0,0,0q�6Y   ���#6C63FF
�������$��0q�5   =   6R   5      �� 5   
   $��1��6   ���#2E2E3E �� CornerRadius$ 10��63    �� Padding$ 10q�6E   ._�5      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dtPrestamos��5      
   AutoGenerateColumns
 .  $��	0,10,0,10q�6H   ���#404053$��0q�5   -      HeadersVisibility$ Column=�6A      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID del Libro��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	LibroID+6[     5      $ Título��6)   $ * 6T    69   �� *Titulo+6T     5      $ Fecha de Préstamo��6)   $ * 6f    6D   �� *FechaPrestamo+6f   4  .System.Windows.Controls.DataGridCheckBoxColumn  5       $ Devuelto��6-   $
 Auto 6\    6?   �� *
Devuelto+6\   5"      5#      �� 5&   
   $ 
Horizontal=�6   $��Right=�6.   $��2��6J   $��0,10,0,0q�6W   .+�5'      �� -   5        $ btnRegistrarDevolucion��5'      $��Registrar Devolución��65   $	��170��6T   $��40��6`   $��0,0,10,0q�6l   ���#6C63FF
�������$��0q�5(   =   6R   �� 5)      -   5        $ btnCancelar��5)      $��Cancelar��6*   $	��120��6=   $��40��6I   ���#FF6C63
�������$��0q�5*   =   6R   5+      5,      5-      