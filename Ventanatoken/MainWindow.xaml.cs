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

namespace Ventanatoken
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
            using (SqlConnection connection = Funciones.Program.conexion())
            {
                
                string query = "SELECT * FROM Admins WHERE Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetros para evitar inyecciones SQL
                    
                    command.Parameters.AddWithValue("@Password", Passbox.Password);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           Registros.MainWindow mainWindow = new Registros.MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        Console.WriteLine("contraseña incorrecta.");
                    }
                }
            }
        }
    }
}
