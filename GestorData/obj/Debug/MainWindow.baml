   M S B A M L   `   `   `  ����  
GestorData    GestorData.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Gestión de Biblioteca��5   	   $	��500��6'   $	��800��64   ���#1E1E2C.��5      �  � RowDefinitions 5	   
   �� 5
      $	��125 �6   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   � $��0��6   ���#2E2E3E.+�5      �� $��Center=�6   .+�5      �� $��Gestión de Biblioteca��6   $��24(�69   $
��Bold"�6G   ���#D5CCC7$��0,0,0,10q�6n    �� TextAlignment$ Center=�6�   ]� 5      .+�5      �� -   5         ��Name$ selector��5      $	��200��61   $��25��6=   $��0,0,10,0q�6I    �� SelectedIndex$ 0��6[   ���#404053$��0q�6�   .@�5      �� {�.  $��Seleccione una opción��69   �� 5      $��Libros��6'   �� 5      -   5        $��
usuariocmb��5   '   $��Usuarios��69   �� 5      -   5        $��devolucionescmb��5   '   $��Devoluciones��6>   �� 5      -   5        $��prestamocmb��5   '   $��
Préstamos��6:   5      �� 5      -   5         ��Name$ 	buscadorg��5      $	��300��61   $��25��6=   $��16(�6I   ���#404053���#D5CCC7$��0q�6�   $��0,0,10,0q�6�   �� 5      -   5        $��Buscar��5      $	��100��6.   $��25��6:   ���#6C63FF
�������$��0q�6n   6�   5       5!      5"      �� 5%   
   $��1��6   ���#2E2E3E �� CornerRadius$ 10��63   	 �� Padding$	 10q�6E   ._�5&      � .+�5(      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 	dt_libros��5(      $y�	Collapsed=�6.      AutoGenerateColumns .  ���#404053$��0q�6v      
IsReadOnly .    Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	LibroID+  5+      $ Título��6-    6=   �� *Titulo+  5,      $ Autor��6-    6<   �� *Autor+  5-      $
 ISBN��6-    6;   �� *ISBN+  5.      $ 
Disponible��6-    6A   �� *DisponibleTexto+  5/      $ Fecha de Lanzamiento��6-    6K   �� *FechaLanzamiento+51        54      -   5        $
 dt_usuarios��54      $y�	Collapsed=�60    .  ���#404053$��0q�6x    .  55        56      $ Id��6-    69   �� *	UsuarioID+  57      $ Nombre��6-    6=   �� *Nombre+  58      $ Apellido��6-    6?   �� *
Apellido+  59      $ 	Documento��6-    6@   �� *	Documento+  5:      $ Correo��6-    6=   �� *Correo+  5;      $ 	Teléfono��6-    6?   �� *
Telefono+  5<      $ Usuario��6-    6>   �� *	Usuario+5>        5A      -	   5        $
 dt_devoluciones��5A      $y�	Collapsed=�64    .  ���#404053$��0q�6|    .  5B        5C      $ ID Devolución��6-    6D   �� *DevolucionID+  5D      $ ID Préstamo��6-    6B   �� *
PrestamoID+  5E      $ 	Documento��6-    6@   �� *	Documento+  5F      $ Título��6-    6=   �� *Titulo+  5G      $ Usuario��6-    6>   �� *	UsuarioID+  5H      $ Fecha Préstamo��6-    6E   �� *FechaPrestamo+  5I      $ Fecha Real Devolución��6-    6L   �� *FechaDevolucionReal+5K        5N      -
   5        $
 dt_prestamos��5N      $y�	Collapsed=�61    .  ���#404053$��0q�6y    .  5O        5P      $ ID Préstamo��6-    6B   �� *
PrestamoID+  5Q      $ 
ID Usuario��6-    6A   �� *	UsuarioID+  5R      $ 	Documento��6-    6@   �� *	Documento+  5S      $ ID Libro��6-    6?   �� *	LibroID+  5T      $ Titulo��6-    6=   �� *Titulo+  5U      $
 ISBN��6-    6;   �� *ISBN+  5V      $ Fecha del Préstamo��6-    6I   �� *FechaPrestamo+  5W      $ Fecha de Devolución��6-    6J   �� *FechaDevolucion+5Y      5Z      5[      � 5^   
   $��2��6   ���#2E2E3E.+�5_      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5`      �� -   5        $��Agregar��5`   +   $��Agregar��6   $	��120��6:   $��40��6F   ���#6C63FF$��0q�6g   6{   �� 5a      -   5        $��	Modificar��5a   -   $��	Modificar��6   $	��120��6>   $��40��6J   ���#FFC063$��0q�6k   6   �� 5b      -   5        $��Eliminar��5b   ,   $��Eliminar��6   $	��120��6<   $��40��6H   ���#FF6C63$��0q�6i   6}   �� 5c      -   5        $��Prestamo��5c   -   $��
Préstamos��6   $	��120��6=   $��40��6I   ���#63CFFF$��0q�6j   6~   �� 5d      -   5        $��
Devolucion��5d   0   $��Devoluciones��6   $	��120��6B   $��40��6N   ���#63FF63$��0q�6o   6�   5e      5f      5g      5i      