using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace GestorData
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string email;
        public MainWindow(string Email)
        {
            InitializeComponent();
            email = Email;
            Entidades.Entidades.Usuarios usuarios = Funciones.Program.UsuariosPorEmail(email);
            devolucionescmb.Visibility = Visibility.Hidden;
            if (usuarios.Rol == "Usuario")
            {
                Agregar.Visibility = Visibility.Hidden;
                Modificar.Visibility = Visibility.Hidden;
                Eliminar.Visibility = Visibility.Hidden;
                prestamocmb.Visibility = Visibility.Hidden;
                devolucionescmb.Visibility = Visibility.Hidden;
                usuariocmb.Visibility = Visibility.Hidden;
            }
        }


        private void selector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indice_seleccionado = selector.SelectedIndex;
            if (indice_seleccionado==1)
            {
                dt_libros.Visibility = Visibility.Visible;
                dt_prestamos.Visibility = Visibility.Hidden;
                dt_devoluciones.Visibility = Visibility.Hidden;
                dt_usuarios.Visibility = Visibility.Hidden;
                dt_libros.HeadersVisibility = DataGridHeadersVisibility.All;
                List<Entidades.Entidades.Libros> libros = Funciones.Program.CargarLibros();
                dt_libros.ItemsSource= libros;
            }
            else if (indice_seleccionado==2)
            {
                dt_libros.Visibility = Visibility.Hidden;
                dt_prestamos.Visibility = Visibility.Hidden;
                dt_devoluciones.Visibility = Visibility.Hidden;
                dt_usuarios.Visibility = Visibility.Visible;
                dt_usuarios.HeadersVisibility = DataGridHeadersVisibility.All;
                List<Entidades.Entidades.Usuarios> usuarios = Funciones.Program.MostrarUsuarios();
                dt_usuarios.ItemsSource = usuarios;
            }
            else if (indice_seleccionado == 4)
            {
                dt_libros.Visibility= Visibility.Hidden;
                dt_prestamos.Visibility= Visibility.Visible;
                dt_devoluciones.Visibility= Visibility.Hidden;
                dt_usuarios.Visibility= Visibility.Hidden;
                dt_prestamos.HeadersVisibility = DataGridHeadersVisibility.All;
                List<Entidades.Entidades.Prestamos> prestamos = Funciones.Program.ListaPrestamo();
                dt_prestamos.ItemsSource = prestamos;
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string titulobuscado = buscadorg.Text;

            List<Entidades.Entidades.Libros> libroBuscado = Funciones.Program.LibrosPorNombre(titulobuscado);

            if (libroBuscado != null && libroBuscado.Count > 0)
            {
                dt_libros.Visibility = Visibility.Visible;
                dt_prestamos.Visibility = Visibility.Hidden;
                dt_devoluciones.Visibility = Visibility.Hidden;
                dt_usuarios.Visibility = Visibility.Hidden;
                dt_libros.HeadersVisibility = DataGridHeadersVisibility.All;
                dt_libros.ItemsSource = libroBuscado;
            }
            else
            {
                // Si no se encuentra, mostrar un mensaje de error
                MessageBox.Show("El libro no fue encontrado.", "Búsqueda", MessageBoxButton.OK, MessageBoxImage.Warning);

                // Opcional: Limpiar el DataGrid
                dt_libros.ItemsSource = null;
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarLibro.MainWindow mainWindow = new AgregarLibro.MainWindow();
            mainWindow.ShowDialog();
        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            if (dt_libros.SelectedItem is Entidades.Entidades.Libros libroSeleccionado) //llamo al item del datagrid
            {
                if (libroSeleccionado==null || libroSeleccionado.LibroID == null )
                {
                    MessageBox.Show("Seleccione un libro");
                }
                else
                {
                    ModificarLibro.MainWindow mainWindow = new ModificarLibro.MainWindow(libroSeleccionado.LibroID);
                    mainWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un libro");
            }
            
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?",
                                                  "Confirmar Eliminación",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Warning);
            if (dt_libros.SelectedItem is Entidades.Entidades.Libros libroSeleccionado) //llamo al item del datagrid
            {
                if (libroSeleccionado == null || libroSeleccionado.LibroID == null)
                {
                    MessageBox.Show("Seleccione un libro");
                }
                else
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        Funciones.Program.EliminarLibros(libroSeleccionado.LibroID);
                        List<Entidades.Entidades.Libros> libros = Funciones.Program.CargarLibros();                    
                        dt_libros.ItemsSource=libros;
                    }
                }
            }
            else if(dt_usuarios.SelectedItem is Entidades.Entidades.Usuarios usuarioSeleccionado)
            {
                if (usuarioSeleccionado == null || usuarioSeleccionado.UsuarioID == null)
                {
                    MessageBox.Show("Seleccione un usuario");
                }
                else
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        //aca la funcion de eliminar
                        Funciones.Program.EliminarUsuario(usuarioSeleccionado.UsuarioID);
                        List<Entidades.Entidades.Usuarios> usuarios = Funciones.Program.MostrarUsuarios();
                        dt_usuarios.ItemsSource=usuarios;
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una casilla");
            }
        }
    }
    
} 
