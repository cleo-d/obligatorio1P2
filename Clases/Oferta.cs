using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    
    public class Oferta
    {
        #region PROPERTYS
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public Cliente Cliente { get; set; }

        public double Monto { get; set; }
        public DateTime FechaOferta { get; set; }

        #endregion

        #region CONSTRUCTORES
        public Oferta()
        {
            Id = UltimoId++;
        }

        public Oferta(Cliente cliente, double monto, DateTime fechaOferta)
        {
            Id = UltimoId++;
            Cliente = cliente;
            Monto = monto;
            FechaOferta = fechaOferta;
            Validar();
        }
        #endregion
       
        private void Validar()
        {
            ValidarSaldoParaOferta();
        }

        private void ValidarSaldoParaOferta()
        {
            if (Cliente.Saldo < Monto)
            {
                throw new Exception("No tiene saldo para realizar esta oferta");
            }
        }
    
    }
}
