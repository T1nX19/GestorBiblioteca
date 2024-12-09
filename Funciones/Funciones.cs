﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using static Entidades.Entidades;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.Security.Cryptography;
// tabla booleano 
namespace Funciones
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        //Conexion sqlserver
        public static SqlConnection conexion()
        {
            SqlConnection conecxion = new SqlConnection("Server = MAR\\SQLEXPRESS; Database=Biblioteca_DB; Trusted_Connection=true; Integrated Security=SSPI;Persist Security Info=False;");
            conecxion.Open();
            return conecxion;
        }

        //Funciones De Registro
        public static int Registrarusuario(Entidades.Entidades.Usuarios usuarios)
        {
            string query = "INSERT INTO Usuarios(Nombre, Correo, Contraseña, Documento, Telefono, Rol,Usuario,Apellido)" +
                " VALUES (@Nombre, @Correo, @Contraseña, @Documento, @Telefono, @Rol,@Usuario,@Apellido) ";
            try
            {
                using (SqlConnection connection = conexion())
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuarios.Nombre); // Accede a los parametros y agrega un valor
                        cmd.Parameters.AddWithValue("@Correo", usuarios.Correo);
                        cmd.Parameters.AddWithValue("@Contraseña", usuarios.Contraseña);
                        cmd.Parameters.AddWithValue("@Documento", usuarios.Documento);
                        cmd.Parameters.AddWithValue("@Telefono", usuarios.Telefono);
                        cmd.Parameters.AddWithValue("@Rol", usuarios.Rol);
                        cmd.Parameters.AddWithValue("@Usuario", usuarios.Usuario);
                        cmd.Parameters.AddWithValue("@Apellido", usuarios.Apellido);
                        int retorno = cmd.ExecuteNonQuery(); // Si devuelve 1 se agrega el usuario correctamente. si es 0 hay un error
                        return retorno;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                return -1;
            }
        }

        public static bool AgregarLibros(Entidades.Entidades.Libros libros)
        {
            string query = "INSERT INTO Libros (Titulo, Autor, ISBN, FechaLanzamiento) VALUES (@Titulo, @Autor, @ISBN, @FechaLanzamiento)";

            try
            {
                using (SqlConnection connection = conexion())
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Titulo", libros.Titulo);
                    command.Parameters.AddWithValue("@Autor", libros.Autor);
                    command.Parameters.AddWithValue("@ISBN", libros.ISBN);
                    command.Parameters.AddWithValue("@FechaLanzamiento", libros.FechaLanzamiento);

                    int retorno = command.ExecuteNonQuery(); // Si devuelve 1 se agrega el usuario correctamente. si es 0 hay un error
                    return retorno > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                return false;
            }
        }


        // Funciones De Validacion
        public static bool ValidarEmail(string Email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(Email, pattern);
        }

        public static bool ValidacionUser(string NombreUsuario)
        {
            using (SqlConnection connection = conexion())
            {
                string query = "SELECT COUNT(1) FROM Usuarios WHERE Usuario=@Usuario";//El arroba es para que no haya inyeccion de SQL

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Usuario", NombreUsuario);
                    int count = (int)cmd.ExecuteScalar();//Fuerza un casting

                    return count == 0;
                }
            }
        }

        public static bool ValidacionDocumento(string Documento)
        {
            string pattern = @"^\d{8}$";

            return Regex.IsMatch(Documento, pattern);
        }
        public static int Login(Entidades.Entidades.Usuarios usuarios)
        {
            int retorno = 0;

            using (SqlConnection connection = conexion())
            {

                

                string query = "SELECT COUNT(1) FROM Usuarios WHERE Correo=@Correo AND Contraseña COLLATE SQL_Latin1_General_CP1_CS_AS =@Contraseña AND estado=0";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Correo", usuarios.Correo);
                    command.Parameters.AddWithValue("@Contraseña", usuarios.Contraseña);
                    try
                    {
                        retorno = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }
                    return retorno;
                }
            }
        }

        // Funciones Crud
        public static List<Entidades.Entidades.Libros> CargarLibros()
        {
            List<Entidades.Entidades.Libros> libros = new List<Entidades.Entidades.Libros>();

            string query = "SELECT * FROM Libros";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Entidades.Libros librosobj = new Entidades.Entidades.Libros()
                        {
                            LibroID = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            Disponible = reader.GetBoolean(4),
                            FechaLanzamiento = reader.GetDateTime(5)
                        };

                        libros.Add(librosobj);
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ha ocurrido un error: " + e.Message);
                }
            }
            return libros;
        }

        public static bool ModificarLibros(Entidades.Entidades.Libros libros)
        {
            string query = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, ISBN = @ISBN, FechaLanzamiento = @FechaLanzamiento WHERE LibroID = @ID";

            using (SqlConnection connection = conexion())
            {
                using (SqlTransaction transaccion = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection, transaccion);

                        command.Parameters.AddWithValue("@Titulo", libros.Titulo);
                        command.Parameters.AddWithValue("@Autor", libros.Autor);
                        command.Parameters.AddWithValue("@ISBN", libros.ISBN);
                        command.Parameters.AddWithValue("@FechaLanzamiento", libros.FechaLanzamiento);
                        command.Parameters.AddWithValue("@ID", libros.LibroID);

                        int retorno = command.ExecuteNonQuery(); // Si devuelve 1 se modifico el usuario correctamente. si es 0 hay un error
                        transaccion.Commit();
                        return retorno > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error" + ex.Message);
                        transaccion.Rollback();
                        return false;
                        throw;
                    }
                }
            }
        }

        public static void EliminarUsuario(int id)
        {
            using (SqlConnection connection = conexion())
            {
                SqlTransaction transaccion = connection.BeginTransaction();

                try
                {
                    string query = "UPDATE Usuarios SET estado=1 WHERE UsuarioID=@id";
                    SqlCommand cmd = new SqlCommand(query, connection, transaccion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    transaccion.Commit();
                    MessageBox.Show("Se ha eliminado el usuario");
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    Console.WriteLine("Ocurrio un error: " + ex.Message);
                }


            }
        }

        public static void EliminarLibros(int id)
        {

            using (SqlConnection connection = conexion())
            {
                SqlTransaction sqlTransaction = connection.BeginTransaction();

                try
                {
                    string query = "UPDATE Libros SET estado=1 WHERE LibroID=@id";
                    SqlCommand cmd = new SqlCommand(query, connection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    sqlTransaction.Commit();
                    MessageBox.Show("Se ha eliminado el libro");
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, revertir la transacción
                    sqlTransaction.Rollback();
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }
            }
        }

        public static void EliminarPrestamo(int id)
        {
            using (SqlConnection connection = conexion())
            {
                SqlTransaction sqlTransaction = connection.BeginTransaction();

                try
                {
                    string query = "UPDATE Prestamos SET estado=1 WHERE PrestamoID=@id";
                    SqlCommand cmd = new SqlCommand(query, connection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    sqlTransaction.Commit();
                    MessageBox.Show("Se ha eliminado el prestamo");
                }
                catch (Exception ex)
                {
                    // Si ocurre un error, revertir la transacción
                    sqlTransaction.Rollback();
                    Console.WriteLine("Ocurrió un error: " + ex.Message);
                }
            }
        }

        public static List<Entidades.Entidades.Usuarios> MostrarUsuarios() // Lista de usuarios
        {
            List<Entidades.Entidades.Usuarios> usuario = new List<Entidades.Entidades.Usuarios>();
            using (SqlConnection connection = conexion())
            {
                string query = "SELECT UsuarioID,Nombre,Apellido,Documento,Correo,Telefono,Usuario FROM Usuarios WHERE estado=0";

                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Entidades.Usuarios usuarioObj = new Entidades.Entidades.Usuarios()
                        {
                            UsuarioID = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Documento = reader.GetString(3),
                            Correo = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            Usuario = reader.GetString(6)
                        };
                        usuario.Add(usuarioObj);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ha ocurrido un error: " + e.Message);
                }
            }
            return usuario;
        }

        public static Entidades.Entidades.Libros ObtenerLibrosPorId(int id) // lista libros por ID
        {
            Entidades.Entidades.Libros libro = new Entidades.Entidades.Libros();
            string query = "SELECT * FROM Libros WHERE LibroId=@id AND estado=0";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        libro = new Entidades.Entidades.Libros()
                        {
                            LibroID = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            Disponible = reader.GetBoolean(4),
                            FechaLanzamiento = reader.GetDateTime(5)
                        };

                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ha ocurrido un error: " + e.Message);
                }
            }
            return libro;
        }
        public static bool AgregarPrestamos(Entidades.Entidades.Prestamos prestamo)
        {
            string query = "INSERT INTO Prestamos (UsuarioID, LibroID, FechaPrestamo, FechaDevolucion, Devuelto, Documento, ISBN)\r\nVALUES (@UsuarioID, @LibroID, @FechaPrestamo, @FechaDevolucion, @Devuelto, @Documento, @ISBN);";
            
            try
            {
                using (SqlConnection connection = conexion())
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    

                    command.Parameters.AddWithValue("@UsuarioID", prestamo.UsuarioID);
                    command.Parameters.AddWithValue("@LibroID", prestamo.LibroID);
                    command.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                    command.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion);
                    command.Parameters.AddWithValue("@Devuelto", prestamo.Devuelto);
                    command.Parameters.AddWithValue("@Documento", prestamo.Documento);
                    command.Parameters.AddWithValue("@ISBN", prestamo.ISBN);

                    int retorno = command.ExecuteNonQuery(); // Si devuelve 1 se agrega el usuario correctamente. si es 0 hay un error
                    return retorno > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                return false;
            }
        }



        public static Entidades.Entidades.Usuarios ObtenerDatosPorDocumento(string documento)
        {
            Entidades.Entidades.Usuarios documentos = new Entidades.Entidades.Usuarios();
            string query = "SELECT * FROM Usuarios WHERE Documento=@documento ";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        documentos = new Entidades.Entidades.Usuarios()
                        {
                            UsuarioID = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Documento = reader.GetString(3),
                            Correo = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            Usuario = reader.GetString(6)
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un Error: " + ex.Message);
                }
            }
            return documentos;
        }

        public static Entidades.Entidades.Libros ObtenerDatosPorISBN(string isbn)
        {
            Entidades.Entidades.Libros isbnl = new Entidades.Entidades.Libros();
            string query = "SELECT * FROM Libros WHERE ISBN=@isbn ";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        isbnl = new Entidades.Entidades.Libros()
                        {
                            LibroID = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            Disponible = reader.GetBoolean(4),
                            FechaLanzamiento = reader.GetDateTime(5)
                        };
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un Error: " + ex.Message);
                }
            }
            return isbnl;    
        }

        public static List<Entidades.Entidades.Prestamos> ListaPrestamo() // Lista de prestamos
        {
            List<Entidades.Entidades.Prestamos> prestamos = new List<Prestamos>();
            
            using (SqlConnection connection = conexion())
            {
                string query = "SELECT * FROM Prestamos WHERE estado=0";

                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Entidades.Prestamos prestamos1 = new Entidades.Entidades.Prestamos
                        {
                            PrestamoID = reader.GetInt32(0),
                            UsuarioID = reader.GetInt32(1),
                            LibroID = reader.GetInt32(2),
                            FechaPrestamo = reader.GetDateTime(3),
                            FechaDevolucion = reader.GetDateTime(4),
                            Devuelto = reader.GetBoolean(5),
                            Documento = reader.GetString(6),
                            ISBN = reader.GetString(7),

                        };
                       
                        prestamos.Add(prestamos1);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error :" + ex.Message);
                }

            }
            return prestamos;
        }

        public static List<Entidades.Entidades.Prestamos> ObtenerPrestamoPorId(int id)
        {
            List<Entidades.Entidades.Prestamos> prestamos = new List<Prestamos>();
            string query = @"
        SELECT 
            p.PrestamoID, p.UsuarioID, p.LibroID, p.FechaPrestamo, p.FechaDevolucion, 
            p.Devuelto, p.Documento, p.ISBN, l.Titulo
        FROM Prestamos p
        JOIN Libros l ON p.LibroID = l.LibroID
        WHERE p.PrestamoID = @id";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Entidades.Entidades.Prestamos prestamos1 = new Entidades.Entidades.Prestamos
                        {
                            PrestamoID = reader.GetInt32(0),
                            UsuarioID = reader.GetInt32(1),
                            LibroID = reader.GetInt32(2),
                            FechaPrestamo = reader.GetDateTime(3),
                            FechaDevolucion = reader.GetDateTime(4),
                            Devuelto = reader.GetBoolean(5),
                            Documento = reader.GetString(6),
                            ISBN = reader.GetString(7),
                            Titulo = reader.GetString(8),  // Aquí obtenemos el título del libro
                        };
                        prestamos.Add(prestamos1);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ha ocurrido un error: " + e.Message);
                }
            }
            return prestamos;
        }



        public static Entidades.Entidades.Usuarios UsuariosPorEmail(string correo)
        {
            Entidades.Entidades.Usuarios usuarios = null;

            using (SqlConnection connection = conexion())
            {
                string query = "SELECT * FROM Usuarios WHERE Correo=@correo ";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@correo", correo);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarios = new Entidades.Entidades.Usuarios()
                        {
                            UsuarioID = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Correo = reader.GetString(2),
                            Contraseña = reader.GetString(3),
                            Rol = reader.GetString(4),
                            Documento = reader.GetString(5),
                            Telefono = reader.GetString(6),
                            Usuario = reader.GetString(7),
                            Apellido = reader.GetString(8),
                        };

                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ha ocurrido un error: " + e.Message);
                }
            }
            return usuarios;


        }
        public static List<Entidades.Entidades.Libros> LibrosPorNombre(string nombre)
        {
            List<Entidades.Entidades.Libros> librosEncontrados = new List<Libros>();

            string query = "SELECT * FROM Libros WHERE Titulo LIKE '%' + @titulo + '%' AND estado=0";

            using (SqlConnection connection = conexion())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@titulo", nombre);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Entidades.Libros libro = new Entidades.Entidades.Libros()
                        {
                            LibroID = reader.GetInt32(0),
                            Titulo = reader.GetString(1),
                            Autor = reader.GetString(2),
                            ISBN = reader.GetString(3),
                            Disponible = reader.GetBoolean(4),
                            FechaLanzamiento = reader.GetDateTime(5)
                        };
                        librosEncontrados.Add(libro);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error" + e.Message);
                }
            }
            return librosEncontrados;
        }

        public static bool validarNumero(string numero,out int numerovalidado, string campo)
        {
            if (int.TryParse(numero, out numerovalidado))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Ingrese solo numeros: ");
                return false;
            }
        }

        public static bool RegistrarDevolucion(int prestamoID, DateTime fechaDevolucionReal)
        {
             string updatePrestamoQuery = @"UPDATE Prestamos SET Devuelto = 1 WHERE PrestamoID = @prestamoID";

            string insertDevolucionQuery = @"INSERT INTO Devoluciones (PrestamoID, FechaDevolucionReal, estado) VALUES (@prestamoID, @fechaDevolucionReal, 1)";

            using (SqlConnection connection = conexion())
            {
                SqlTransaction transaction = null;

                try
                {
            
                    transaction = connection.BeginTransaction();

                    // Actualizar el estado del préstamo
                    SqlCommand updateCmd = new SqlCommand(updatePrestamoQuery, connection, transaction);
                    updateCmd.Parameters.AddWithValue("@prestamoID", prestamoID);
                    updateCmd.ExecuteNonQuery();

                    // Insertar registro de devolución
                    SqlCommand insertCmd = new SqlCommand(insertDevolucionQuery, connection, transaction);
                    insertCmd.Parameters.AddWithValue("@prestamoID", prestamoID);
                    insertCmd.Parameters.AddWithValue("@fechaDevolucionReal", fechaDevolucionReal);
                    insertCmd.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaction.Commit();
                    return true;
                }
                catch (Exception e)
                {
                    // Revertir los cambios si ocurre un error
                    transaction?.Rollback();
                    MessageBox.Show("Error al registrar la devolución: " + e.Message);
                    return false;
                }
            }       
        }

        public static List<Entidades.Entidades.Devoluciones> ListaDevolucion() // Lista de devolucion
        {
            List<Entidades.Entidades.Devoluciones> devolucion = new List<Devoluciones>();

            using (SqlConnection connection = conexion())
            {
                string query = "SELECT * FROM Devoluciones";

                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entidades.Entidades.Devoluciones devoluciones = new Entidades.Entidades.Devoluciones
                        {
                            DevolucionID = reader.GetInt32(0),
                            PrestamoID = reader.GetInt32(1),
                            DevoReal = reader.GetDateTime(2),
                            
                            
                            

                        };

                        devolucion.Add(devoluciones);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error :" + ex.Message);
                }

            }
            return devolucion;
        }
        
        
        public static string Generarpass(int length = 10)
        {
             const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
             char[] chars = new char[length];
             using (var crypto = new RNGCryptoServiceProvider())
             {
               byte[] data = new byte[length];
               crypto.GetBytes(data);
               for (int i = 0; i < chars.Length; i++)
               {
                  chars[i] = validChars[data[i] % validChars.Length];
               }
             }
             return new string(chars);
        }
        public static int registrarAdministrador(Entidades.Entidades.Admins admins)
        {
            using (SqlConnection connection = conexion())
            {
                string query = "INSERT INTO Admins (AdminID, Password) VALUES (@id,@password)";
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", admins.AdminID );
                        cmd.Parameters.AddWithValue("@password", admins.Password );
                        int filas = cmd.ExecuteNonQuery();
                        return filas;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar administrador");
                    return -1;
                }
            }
        }
    }
}
