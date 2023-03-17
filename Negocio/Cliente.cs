using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            RutCliente = String.Empty;
            RazonSocial = String.Empty;
            NombreContacto = String.Empty;
            MailContacto = String.Empty;
            Direccion = String.Empty;
            Telefono = String.Empty;
            ActividadEmpresa = 0;
            TipoEmpresa = 0;
        }



        public String RutCliente { get; set; }
        public String RazonSocial { get; set; }
        public String NombreContacto { get; set; }
        public String MailContacto { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int ActividadEmpresa { get; set; }
        public int TipoEmpresa { get; set; }

    }
}
