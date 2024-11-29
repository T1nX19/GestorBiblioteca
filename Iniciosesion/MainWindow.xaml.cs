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

namespace Iniciosesion
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

        private void Button_Click(object sender, RoutedEventArgs e) //boton de inicio de sesion con validacion usuario/administrador
        {
            if (Funciones.Program.ValidarEmail (correoi.Text) == false )
            {
                MessageBox.Show("Ingrece un correo valido");
            }

            Entidades.Entidades.Usuarios usuarios = new Entidades.Entidades.Usuarios()
            {
                Correo = correoi.Text,  
                Contraseña = contraseñai.Password
            };

            if (Funciones.Program.Login(usuarios)>0)
            {
                GestorData.MainWindow gestor = new GestorData.MainWindow(correoi.Text);
                this.Close();
                gestor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Las credenciales no son validas");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e) //boton de registro
        {
            Registros.MainWindow registros = new Registros.MainWindow();
            registros.ShowDialog();
        }
    }
}
