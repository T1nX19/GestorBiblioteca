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

namespace Devoluciones
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

        private void btnBuscarPrestamo_Click(object sender, RoutedEventArgs e)
        {
           int buscarid = int.Parse(txtPrestamoID.Text);

            if (!Funciones.Program.validarNumero(txtPrestamoID.Text,out int numero, "id"))
            {
                return;
            }
            List<Entidades.Entidades.Prestamos> prestamos = Funciones.Program.ObtenerPrestamoPorId(buscarid);



            if (prestamos != null && prestamos.Count > 0)
            {
                dtPrestamos.Visibility = Visibility.Visible;
                dtPrestamos.HeadersVisibility = DataGridHeadersVisibility.All;
                dtPrestamos.ItemsSource = prestamos;
            }
            else
            {
                MessageBox.Show("No se encontro el ID");
                return;
            }

        }

        private void btnRegistrarDevolucion_Click(object sender, RoutedEventArgs e)
        {
            if (dtPrestamos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un préstamo de la lista.");
                return;
            }

            // Obtener la fila seleccionada y verificar la casilla de Devuelto
            var prestamoSeleccionado = (Entidades.Entidades.Prestamos)dtPrestamos.SelectedItem;
            if (!prestamoSeleccionado.Devuelto)
            {
                MessageBox.Show("Debe marcar la casilla 'Devuelto' antes de registrar la devolución.");
                return;
            }
            // Obtener el ID del préstamo desde el campo de texto
            int prestamoID = int.Parse(txtPrestamoID.Text);

            // Registrar la devolución
            DateTime fechaDevolucionReal = DateTime.Now; // Usamos la fecha actual como fecha de devolución
            bool exito = Funciones.Program.RegistrarDevolucion(prestamoID, fechaDevolucionReal);

            if (exito)
            {
                MessageBox.Show("Devolución registrada con éxito.");
        
                // Limpiar o actualizar la tabla de préstamos
                dtPrestamos.ItemsSource = null;
                dtPrestamos.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Error al registrar la devolución. Verifique los datos o intente de nuevo.");
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
