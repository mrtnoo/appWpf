using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoEmpresa
    {
        public TipoEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            id = 0;
            Descripcion = String.Empty;
        }


        public int id { get; set; }
        public string Descripcion { get; set; }
    }
}
