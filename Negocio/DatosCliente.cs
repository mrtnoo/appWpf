using onBreak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio
{
    public class DatosCliente
    {

        
        public onbreakEntities bbdd = new onbreakEntities();

        /*
        * AGREGAR CLIENTE 
        *       
        */
        public bool agregarCliente(Cliente cliente)
        {
            try
            {
                onBreak.Cliente cli1 = new onBreak.Cliente()
                {
                    RutCliente = cliente.RutCliente,
                    RazonSocial = cliente.RazonSocial,
                    NombreContacto = cliente.NombreContacto,
                    MailContacto = cliente.MailContacto,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    IdActividadEmpresa = cliente.ActividadEmpresa,
                    IdTipoEmpresa = cliente.TipoEmpresa
                };
                bbdd.Cliente.Add(cli1);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       
        /*
        * LISTAR CLIENTE
        *       
        */

        public List<onBreak.Cliente> listarCliente()
        {
            var query = (from cliente in bbdd.Cliente select cliente).ToList();

            return query;
        }
        /*
        * BUSCAR CLIENTE 
        *       
        */
        public Negocio.Cliente buscarCliente(string rut)
        {
            onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(rut));
            Negocio.Cliente cli = new Negocio.Cliente();
            if (cliente != null)
            {
                cli.RutCliente = cliente.RutCliente;
                cli.RazonSocial = cliente.RazonSocial;
                cli.NombreContacto = cliente.NombreContacto;
                cli.MailContacto = cliente.MailContacto;
                cli.Direccion = cliente.Direccion;
                cli.Telefono = cliente.Telefono;
                cli.ActividadEmpresa = cliente.IdActividadEmpresa;
                cli.TipoEmpresa = cliente.IdTipoEmpresa;

            }
            return cli;

        }
        /*
        * MODIFICAR CLIENTE 
        *       
        */
        public bool modificarCliente(Negocio.Cliente cli)
        {
            onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(cli.RutCliente));
            if (cliente != null)
            {
                cliente.RutCliente = cli.RutCliente;
                cliente.RazonSocial = cli.RazonSocial;
                cliente.NombreContacto = cli.NombreContacto;
                cliente.MailContacto = cli.MailContacto;
                cliente.Direccion = cli.Direccion;
                cliente.Telefono = cli.Telefono;
                cliente.IdActividadEmpresa = cli.ActividadEmpresa;
                cliente.IdTipoEmpresa = cli.TipoEmpresa;
                bbdd.SaveChanges();
                return true;
            }


            return false;
        }


        /*
        * ELIMINAR CLIENTE 
        *       
        */
        public bool eliminarCliente(string rut)
        {
            onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(rut));
            if (cliente != null)
            {
                bbdd.Cliente.Remove(cliente);
                bbdd.SaveChanges();
                return true;
            }

            return false;
        }

        //validar si el usuario ya existe
        public bool validarCliente(string rut)
        {
            onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(rut));
            if (cliente == null)
            {
                bbdd.SaveChanges();
                return true;
                
            }

            return false;
        }

        //llenar comboboxActivisdad
   
    }

    
}
