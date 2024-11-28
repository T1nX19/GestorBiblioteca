using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidades
    {
        static void Main(string[] args)
        {
        }

        public class Usuarios
        {
            public int UsuarioID { get; set; }
            public string Usuario {  get; set; }
            public string Nombre { get; set; }
            public string Apellido {  get; set; }
            public string Documento { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; }

            public Usuarios() { }
            public Usuarios(int UsuarioID, string Nombre, string Documento, string Telefono, string Correo, string Contraseña, string Rol, string Usuario, string Apellido)
            {
                this.UsuarioID = UsuarioID;
                this.Nombre = Nombre;
                this.Documento = Documento;
                this.Telefono = Telefono;
                this.Correo = Correo;
                this.Contraseña = Contraseña;
                this.Rol = Rol;
                this.Usuario = Usuario;
                this.Apellido = Apellido;
            }
        }
        public class Libros
        {
            public int LibroID { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public DateTime FechaLanzamiento { get; set; }
            public string ISBN { get; set; }
            public bool Disponible { get; set; }

            public Libros() { }
            public Libros(int LibroID, string Titulo, string Autor, DateTime FechaLanzamiento, string ISBN, bool Disponible)
            {
                this.LibroID = LibroID;
                this.Titulo = Titulo;
                this.Autor = Autor;
                this.FechaLanzamiento = FechaLanzamiento;
                this.ISBN = ISBN;
                this.Disponible = Disponible;
            }


        }
        public class Prestamos
        {
            public int PrestamoID { get; set; }
            public int UsuarioID { get; set; }
            public int LibroID { get; set; }
            public DateTime FechaPrestamo { get; set; }
            public DateTime FechaDevolucion { get; set; }
            public bool Devuelto { get; set; }
            public string Documento {  get; set; }
            public string ISBN { get; set;}

            public Prestamos() { }
            public Prestamos(int prestamoID, int usuarioID, int libroID, DateTime fechaPrestamo, DateTime fechaDevolucion, bool devuelto, string Documento, string ISBN)
            {
                this.PrestamoID = prestamoID;
                this.UsuarioID = usuarioID;
                this.LibroID = libroID;
                this.FechaPrestamo = fechaPrestamo;
                this.FechaDevolucion = fechaDevolucion;
                this.Devuelto = devuelto;
                this.Documento = Documento;
                this.ISBN = ISBN;
            }
        }
        public class Devoluciones
        {
            public int DevolucionID { get; set; }
            public int PrestamoID { get; set; }
            public DateTime DevoReal { get; set; }

            public Devoluciones() { }
            public Devoluciones(int devolucionID, int prestamoID, DateTime devoReal)
            {
                this.DevolucionID = devolucionID;
                this.PrestamoID = prestamoID;
                this.DevoReal = devoReal;
            }
        }
        
    }
}
