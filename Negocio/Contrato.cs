using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Contrato
    {

        Cliente cliente = new Cliente();

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numerocontrato = String.Empty;
            Creacion = Convert.ToDateTime("2019-01-01");
            Termino = Convert.ToDateTime("2019-01-01");
            RutCliente = String.Empty;
            IdModalidad = String.Empty;
            IdTipoEvento = 0;
            FechaHoraInicio = Convert.ToDateTime("2019-01-01");
            FechaHoraTermino = Convert.ToDateTime("2019-01-01");
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado = false;
            ValorTotalContrato = 0;
            Observaciones = String.Empty;
        }




        public String Numerocontrato { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        public String RutCliente { get; set; }
        public String IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public String Observaciones { get; set; }
    }
}
