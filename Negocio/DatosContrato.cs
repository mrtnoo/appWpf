using onBreak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DatosContrato
    {
        public onbreakEntities bbdd = new onbreakEntities();

        /*
         * AGREGAR CONTRATO
         */
         public bool agregarContrato(Contrato contrato)
        {
            try
            {
                onBreak.Contrato con1 = new onBreak.Contrato()
                {
                    Numero = contrato.Numerocontrato,
                    Creacion = contrato.Creacion,
                    Termino = contrato.Termino,
                    RutCliente = contrato.RutCliente,
                    IdModalidad = contrato.IdModalidad,
                    IdTipoEvento = contrato.IdTipoEvento,
                    FechaHoraInicio = contrato.FechaHoraInicio,
                    FechaHoraTermino = contrato.FechaHoraTermino,
                    Asistentes = contrato.Asistentes,
                    PersonalAdicional = contrato.PersonalAdicional,
                    Realizado = contrato.Realizado,
                    ValorTotalContrato = contrato.ValorTotalContrato,
                    Observaciones = contrato.Observaciones

                };
                bbdd.Contrato.Add(con1);
                bbdd.SaveChanges();
                return true;

            }
            catch (Exception )
            {
                return false;
               
            }
        }

        /*
        *LISTAR CONTRATO 
        */
        public List<onBreak.Contrato> listarContrato()
        {
            var query = (from ncontrato in bbdd.Contrato select ncontrato).ToList();
            return query;
        }

        public Negocio.Contrato buscarContrato(string numero)
        {
            onBreak.Contrato contrato = bbdd.Contrato.FirstOrDefault(ncontrato => ncontrato.Numero.Equals(numero));
            Negocio.Contrato contra = new Negocio.Contrato();
            if (contrato != null)
            {
                contra.Numerocontrato = contrato.Numero;
                contra.Creacion = contrato.Creacion;
                contra.Termino = contrato.Termino;
                contra.RutCliente = contrato.RutCliente;
                contra.IdModalidad = contrato.IdModalidad;
                contra.IdTipoEvento = contrato.IdTipoEvento;
                contra.FechaHoraInicio = contrato.FechaHoraInicio;
                contra.FechaHoraTermino = contrato.FechaHoraTermino;
                contra.Asistentes = contrato.Asistentes;
                contra.PersonalAdicional = contrato.PersonalAdicional;
                contra.Realizado = contrato.Realizado;
                contra.ValorTotalContrato = contrato.ValorTotalContrato;
                contra.Observaciones = contrato.Observaciones;

            }

            return contra;
        }

        /*
         * MODIFICAR CONTRATO
         */
         public bool modificarContrato(Negocio.Contrato contra)
        {
            onBreak.Contrato contrato = bbdd.Contrato.FirstOrDefault(ncontrato=>ncontrato.Numero.Equals(contra.Numerocontrato));
            if (contrato != null)
            {
                contrato.Creacion = contra.Creacion;
                contrato.Termino = contra.Termino;
                contrato.RutCliente = contra.RutCliente;
                contrato.IdModalidad = contra.IdModalidad;
                contrato.IdTipoEvento = contra.IdTipoEvento;
                contrato.FechaHoraInicio = contra.FechaHoraInicio;
                contrato.FechaHoraTermino = contra.FechaHoraTermino;
                contrato.Asistentes = contra.Asistentes;
                contrato.PersonalAdicional = contra.PersonalAdicional;
                contrato.Realizado = contra.Realizado;
                contrato.ValorTotalContrato = contra.ValorTotalContrato;
                contrato.Observaciones = contra.Observaciones;
                bbdd.SaveChanges();
                return true;
            }
            return false;
        }

        public bool eliminarContrato(String rut)
        {
            onBreak.Contrato contrato = bbdd.Contrato.FirstOrDefault(ncontrato=>ncontrato.RutCliente.Equals(rut));
            if(contrato != null)
            {
                bbdd.Contrato.Remove(contrato);
                bbdd.SaveChanges();
                return true;
            }
            return false;
        }

        public int calcularTotal()
        {
            return 2 ;
        }


    }


}
