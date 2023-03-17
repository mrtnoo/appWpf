using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ActividadEmpresa
    {

        public ActividadEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            id = Convert.ToInt32(0);
            Descripcion = String.Empty;
        }

        public int id { get; set; }
        public String Descripcion { get; set; }
    }
}
