   M S B A M L   `   `   `  ����  
GestorData    GestorData.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ Gestión de Biblioteca��5   	   $	��500��6'   $	��800��64   .��5      �  � RowDefinitions 5   
   �� 5	      $	��125 �6   6+   �� 5
      $��* �6   6)   �� 5      $	��100 �6   6+   .+�5   
   � $��0��6   ���#261C1A.+�5      ]� .+�5      �� $��Gestión de Biblioteca��6   $��20(�65   $
��Bold"�6C   $��Center=�6U   $	��Top=�6r   $��0,0,0,10q�6�   ���#D5CCC76�   �� 5      -   5         ��Name$ selector��5      $	��200��6-   $��25��69   $��0,0,10,0q�6E    �� SelectedIndex$ 0��6�   .@�5      �� {�.  $��Seleccione una opcion��65   �� 5      $��Libros��6#   �� 5      -   5        $��
usuariocmb��5   #   $��Usuarios��65   �� 5      -   5        $��devolucionescmb��5   #   $��Devoluciones��6:   �� 5      -   5        $��prestamocmb��5   #   $��	Prestamos��66   5      �� 5      -   5         ��Name$ 	buscadorg��5      $	��300��6-   $��25��69   $��18(�6E   $��
50,0,-80,0q�6S   �� 5      -   5        $��Buscar��5      $	��100��6*   $��30��66   6B   5       5!      � 5$   
   $��1��6   ���#261C1A.+�5%      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dt_libros��5%   /   $y�	Collapsed=�6      AutoGenerateColumns .  	   HeadersVisibility$
	 None=�6^   
   CanUserAddRows
 .     CanUserDeleteRows .  $��0,10,0,0q�6�   ���#261C1A   
IsReadOnly .    Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	LibroID+  5(      $ Titulo��6)    69   �� *Titulo+  5)      $ Autor��6)    68   �� *Autor+  5*      $
 ISBN��6)    67   �� *ISBN+  5+      $ 
Disponible��6)    6=   �� *
Disponible+  5,      $ Fecha De Lanzamiento��6)    6G   �� *FechaLanzamiento+5.        5/      -   5        $ dt_usuarios��5/      $y�	Collapsed=�6,    .  $
	 None=�6`   
 .   .  $��0,10,0,0q�6�   ���#261C1A .  50        51      $ Id��6)    65   �� *	UsuarioID+  52      $ Nombre��6)    69   �� *Nombre+  53      $ apellido��6)    6;   �� *
Apellido+  54      $ 	Documento��6)    6<   �� *	Documento+  55      $ Correo��6)    69   �� *Correo+  56      $ Telefono��6)    6;   �� *
Telefono+  57      $ Usuario��6)    6:   �� *	Usuario+59        5:      -	   5        $ dt_devoluciones��5:      $y�	Collapsed=�60    .  $
	 None=�6d   
 .   .  $��0,10,0,0q�6�   ���#261C1A .  5;        5<      $ ID Devolucion��6)    6@   �� *DevolucionID+  5=      $ ID Prestamo��6)    6>   �� *
PrestamoID+  5>      $ Fecha De Devolucion��6)    6F   �� *FechaDevolucionReal+5@        5A   
   -
   5        $ dt_prestamos��5A      $y�	Collapsed=�6)    .  $
	 None=�6]   
 .   .  $��0,10,0,0q�6�   ���#261C1A .  5B        5C      $ ID Prestamo��6%    6:   �� *
PrestamoID+  5D      $ 
ID Usuario��6%    69   �� *	UsuarioID+  5E      $ 	Documento��6%    68   �� *	Documento+  5F      $ ID Libro��6%    67   �� *	LibroID+  5G      $
 ISBN��6%    63   �� *ISBN+  5H      $ Fecha Del Prestamo��6%    6A   �� *FechaPrestamo+  5I      $ Fecha De Devolucion��6%    6B   �� *FechaDevolucion+5N      5O      � 5Q   
   ���#261C1A$��2��6$   .+�5R      ]� .+�5S      �� -   5        $��Agregar��5S   9   $��Agregar��6   $��18(�6+   $��	130,0,0,0q�6H   $	��100��6[   $��40��6g   $��Center=�6s   6�   �� 5T      -   5        $��	Modificar��5T   ;   $��	Modificar��6   $��18(�6-   $	��100��6L   $��50,0,0,0q�6X   $��40��6j   $��Center=�6v   6�   �� 5U      -   5        $��Eliminar��5U   :   $��Eliminar��6   $��18(�6,   $	��100��6J   $��40��6V   $��50,0,0,0q�6b   $��Center=�6t   6�   �� 5V      -   5        $��Prestamo��5V   ;   $��	Prestamos��6   $��18(�6-   $	��100��6K   $��40��6W   $��	0,0,100,0q�6c   $��Center=�6v   6�   5W      5X      5Y      5Z      