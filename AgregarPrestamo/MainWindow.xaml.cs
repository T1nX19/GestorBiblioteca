using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Entidades.Entidades;

namespace AgregarPrestamo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void cancelar_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void guardar_Click_1(object sender, RoutedEventArgs e)
        {
            Entidades.Entidades.Prestamos prestamos = new Entidades.Entidades.Prestamos();
            Entidades.Entidades.Usuarios usuarios = Funciones.Program.ObtenerDatosPorDocumento(usuariop.Text);
            Entidades.Entidades.Libros libros = Funciones.Program.ObtenerDatosPorISBN(ISBNp.Text);

            if (usuariop.Text.Length > 0 && usuariop.Text.Length < 100)
            {
                prestamos.Documento = usuariop.Text;
                prestamos.UsuarioID = usuarios.UsuarioID;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre entre 1 a 100 caracteres.");
                return;
            }

            if (ISBNp.Text.Length > 0 && ISBNp.Text.Length < 100)
            {
                prestamos.ISBN = ISBNp.Text;
                prestamos.LibroID = libros.LibroID;
            }
            else
            {
                MessageBox.Show("Ingrese un ISBN correcto.");
                return;
            }



            if (prestamopp.SelectedDate < DateTime.Now)
            {
                prestamos.FechaPrestamo = prestamopp.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("La fecha está fuera del rango.");
                return;
            }

            if (devop.SelectedDate > DateTime.Now)
            {
                prestamos.FechaDevolucion = devop.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("La fecha está fuera del rango.");
                return;
            }

            if (Funciones.Program.AgregarPrestamos(prestamos))
            {
                MessageBox.Show("Prestamo agregado");
            }
        }
    }
}
