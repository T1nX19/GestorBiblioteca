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

namespace AgregarLibro
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

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, RoutedEventArgs e) //boton de guardar y respectivas condiciones
        {
            Entidades.Entidades.Libros libros = new Entidades.Entidades.Libros();

            if (titulol.Text.Length > 0 && titulol.Text.Length < 200)
            {
                libros.Titulo = titulol.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre entre 1 a 200 caracteres");
                return;
            }

            if (autorl.Text.Length > 0 && autorl.Text.Length < 100)
            {
                libros.Autor = autorl.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre entre 1 a 100 caracteres");
                return;
            }

            if (ISBNl.Text.Length > 0 && ISBNl.Text.Length < 20)
            {
                libros.ISBN = ISBNl.Text;
            }
            else
            {
                MessageBox.Show("Iingrece un codigo entre 1 a 20 caracteres");
                return;
            }

            if (fechal.SelectedDate < DateTime.Now)
            {
                libros.FechaLanzamiento = fechal.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("La fecha está fuera del rango.");
                return;
            }

            if (Funciones.Program.AgregarLibros(libros))
            {
                MessageBox.Show("El libro se agrego correctamente");
            }
            else
            {
                MessageBox.Show("Ocurrio un Error");
                return;
            }
        }
    }
}