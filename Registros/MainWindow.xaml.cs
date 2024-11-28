using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Registros
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Entidades.Entidades.Usuarios usuarios = new Entidades.Entidades.Usuarios();

            if (Funciones.Program.ValidacionUser(userr.Text) && userr.Text.Length>1 && userr.Text.Length<50)
            {
                usuarios.Usuario = userr.Text;
            }
            else
            {
                MessageBox.Show("Usuario no permitido");
            }

            if (nombrer.Text.Length>0 && nombrer.Text.Length<50)
            {
                usuarios.Nombre = nombrer.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un nombre entre 1 a 50 caracteres.");
            }

            if (apellidor.Text.Length>0 && apellidor.Text.Length<50)
            {
                usuarios.Apellido = apellidor.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un apellido entre 1 a 50 caracteres.");
            }


            if (Funciones.Program.ValidarEmail(correor.Text))
            {
                usuarios.Correo = correor.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un Email Valido");
                return;
            }
            


            if (contraseña2r.Password == contraseñar.Password) 
            { 
                usuarios.Contraseña = contraseñar.Password;
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden","Advertencia");
                return;
            }

            if (Funciones.Program.ValidacionDocumento(documentor.Text))
            {
                usuarios.Documento = documentor.Text;
            }
            else
            {
                MessageBox.Show("Ingrese Un documento Valido");
                return;
            }

            string patron1 = @"^\d{10}$";
            string patron2 = @"^\d{3}[-\s]?\d{3}[-\s]?\d{4}$";
            string patron3 = @"^+?\d{1,3}?[-.\s]?(?:\d{1,4})?[-.\s]?\d{1,4}[-.\s]?\d{1,9}$";

            if (!Regex.IsMatch(telefonor.Text, patron1) && !Regex.IsMatch(telefonor.Text, patron2) && !Regex.IsMatch(telefonor.Text, patron3))
            {
                MessageBox.Show("Por favor, ingrese un número de teléfono válido.", "Teléfono Inválido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                usuarios.Telefono = telefonor.Text;
            }

            if (admin.IsChecked == false && user.IsChecked == false)
            {
                MessageBox.Show("Seleccione Un Rol");
            }
            if (admin.IsChecked == true)
            {
                usuarios.Rol = "Administrador";
            }
            if (user.IsChecked == true)
            {
                usuarios.Rol = "Usuario";
            }
            if (Funciones.Program.Registrarusuario(usuarios))
            {
                MessageBox.Show("El Usuario Se Registro Correctamente");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
