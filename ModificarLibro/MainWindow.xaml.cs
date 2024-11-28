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

namespace ModificarLibro
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int idSeleccionado;
        public MainWindow(int id)
        {
            InitializeComponent();
            idSeleccionado = id;
            Entidades.Entidades.Libros libroObtenidoPorId = Funciones.Program.ObtenerLibrosPorId(idSeleccionado);
            libroId.Text = idSeleccionado.ToString();
            titulom.Text = libroObtenidoPorId.Titulo;
            autorm.Text = libroObtenidoPorId.Autor;
            ISBNm.Text = libroObtenidoPorId.ISBN;
            fecham.Text = libroObtenidoPorId.FechaLanzamiento.ToString();
        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Está seguro de que desea modificar los datos del libro?",
           "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            Entidades.Entidades.Libros libros = new Entidades.Entidades.Libros();
            libros.LibroID = idSeleccionado;
            if (resultado == MessageBoxResult.Yes)
            {
                // Validar campos vacíos
                if (string.IsNullOrEmpty(libroId.Text) || string.IsNullOrEmpty(titulom.Text) ||
                    string.IsNullOrEmpty(autorm.Text) || string.IsNullOrEmpty(ISBNm.Text) ||
                    fecham.SelectedDate == null)
                {
                    MessageBox.Show("No puede dejar ningún campo en blanco...", "ATENCIÓN");
                    return;
                }

                // Validar título
                if (titulom.Text.Length < 1 || titulom.Text.Length > 200)
                {
                    MessageBox.Show("Ingrese un título entre 1 y 200 caracteres.");
                    return;
                }
                libros.Titulo = titulom.Text;

                // Validar autor
                if (autorm.Text.Length < 1 || autorm.Text.Length > 100)
                {
                    MessageBox.Show("Ingrese un nombre de autor entre 1 y 100 caracteres.");
                    return;
                }
                libros.Autor = autorm.Text;

                // Validar ISBN
                if (ISBNm.Text.Length < 1 || ISBNm.Text.Length > 20)
                {
                    MessageBox.Show("Ingrese un código ISBN entre 1 y 20 caracteres.");
                    return;
                }
                libros.ISBN = ISBNm.Text;

                // Validar fecha
                if (fecham.SelectedDate >= DateTime.Now)
                {
                    MessageBox.Show("La fecha está fuera del rango.");
                    return;
                }
                libros.FechaLanzamiento = fecham.SelectedDate.Value;

                // Intentar modificar el libro
                try
                {
                    if (Funciones.Program.ModificarLibros(libros))
                    {
                        MessageBox.Show("El libro se modificó correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al modificar el libro.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}");
                }
            }
        }
    }
}
