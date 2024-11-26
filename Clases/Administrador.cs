using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Administrador : Usuario    
    {
        #region CONSTRUCTORES
        public Administrador()
        {
            
        }
        public Administrador(string Nombre, string Apellido, string Email, string Contrasenia) 
            : base(Nombre, Apellido, Email,Contrasenia) 
        {
            
        }
        #endregion  

        //Seteo el rol de un administrador
        public override void SetRol()
        {
            Rol = "ADM";
        }
    }
}
