using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cliente : Usuario  
    {
        #region PROPERTYS
        public double Saldo { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Cliente()
        {
            
        }

        public Cliente(double saldo,string Nombre, string Apellido, string Email, string Contrasenia)
            : base(Nombre,Apellido, Email, Contrasenia) 
        {
            Saldo = saldo;
            Validar();
        }
        #endregion  

        private void Validar()
        {
            ValidarSaldo();
        }

        //Valido que el saldo del usuario tiene que ser positivo
        private void ValidarSaldo()
        {
            if (Saldo < 0)
            {
                throw new Exception("El saldo tiene que ser un numero positivo");
            }
        }

        //Seteo el rol de un Cliente
        public override void SetRol()
        {
            Rol = "CLI";
        }
    }
}
