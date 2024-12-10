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
        Entidades.Entidades.Libros libroAPrestar = new Entidades.Entidades.Libros();
        public MainWindow(Entidades.Entidades.Libros libros)
        {
            libroAPrestar= libros;
            InitializeComponent();

            // Llena los campos con los datos del libro seleccionado
            idlibrop.Text = libroAPrestar.LibroID.ToString();
            titulop.Text = libroAPrestar.Titulo;
            autorp.Text = libroAPrestar.Autor;
            ISBNp.Text = libroAPrestar.ISBN;

            fechaPrestamo.SelectedDate = DateTime.Now;
            devop.SelectedDate = DateTime.Now.AddDays(7);
        }


        private void cancelar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void guardar_Click_1(object sender, RoutedEventArgs e)// boton de registrar prestamos
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



            if (fechaPrestamo.SelectedDate < DateTime.Now)
            {
                prestamos.FechaPrestamo = fechaPrestamo.SelectedDate.Value;
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
