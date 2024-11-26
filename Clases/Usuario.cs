using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public abstract class Usuario : IValidable 
    {
        #region PROPERTYS
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Rol { get; set; }

        #endregion
        #region CONSTRUCTORES
        public Usuario()
        {
            Id = UltimoId++;
            SetRol();
        }

        public Usuario(string nombre, string apellido, string email, string contrasenia)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;
            Validar();
			SetRol();
		}
        #endregion

        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarContrasenia();
        }

        //Metodo que valida el nombre de un usuario
        private void ValidarNombre()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede estar vacio");
            }
        }

        //Metodo que valida el apellido de un usuario
        private void ValidarApellido()
        {
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new Exception("El apellido no puede estar vacio");
            }
        }

        //Metodo para validar el email de un usuario
        private void ValidarEmail()
        {
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("El Email no puede estar vacio");
            }
        }

        //Metodo que valida la contraseña de un usuario
        private void ValidarContrasenia()
        {
            if (Contrasenia.Length < 8)
            {
                throw new Exception("La contraseña no puede ser menor a 8 digitos");
            }

        }

        //Metodo polimorfico para setear el rol de cada usuario creado
        public abstract void SetRol();



    }
}
