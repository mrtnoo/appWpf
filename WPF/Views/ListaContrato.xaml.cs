using onBreak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Views
{
    /// <summary>
    /// Lógica de interacción para ListaContrato.xaml
    /// </summary>
    public partial class ListaContrato : UserControl
    {
        public ListaContrato()
        {
            InitializeComponent();
            btnEliminarContrato.Visibility = Visibility.Hidden;
             onbreakEntities bbdd = new onbreakEntities();
        }
        onbreakEntities bbdd = new onbreakEntities();
        private void DgContrato_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.DatosContrato contrato = new Negocio.DatosContrato();
            var llenar = (from c in bbdd.Contrato
                          join m in bbdd.ModalidadServicio on c.IdModalidad equals m.IdModalidad
                          join t in bbdd.TipoEvento on c.IdTipoEvento equals t.IdTipoEvento
                          select new {Numero_Contrato = c.Numero,Rut = c.RutCliente, Creacion_C = c.Creacion, Termino_C = c.Termino, Modalidad = m.Nombre,
                          Tipo = t.Descripcion, Hora_Inicio = c.FechaHoraInicio,Fecha_Termino = c.FechaHoraTermino, Asistentes_Evento = c.Asistentes,
                          Personal_Evento = c.PersonalAdicional, Total = c.ValorTotalContrato, c.Observaciones ,Estado = c.Realizado}
                          ).ToArray();
            //dgContrato.ItemsSource = contrato.listarContrato().ToArray();
            dgContrato.ItemsSource = llenar;
        }

        private void TxtBusquedaRut_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtBusquedaRut.Text == "Ingrese rut..")
            {
                txtBusquedaRut.Text = "";
            }
        }

        private void TxtBusquedaRut_MouseLeave(object sender, MouseEventArgs e)
        {
            if (txtBusquedaRut.Text == "")
            {
                txtBusquedaRut.Text = "Ingrese rut..";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //l busqueda permite de contrato x rut o por numero contrato
            String valor = txtBusquedaRut.Text;
            if (txtBusquedaRut.Text.Length>0)
            {

               
                var llenar = (from c in bbdd.Contrato
                              join m in bbdd.ModalidadServicio on c.IdModalidad equals m.IdModalidad
                              join t in bbdd.TipoEvento on c.IdTipoEvento equals t.IdTipoEvento
                              where c.RutCliente == valor || c.Numero == valor
                              select new
                              {
                                  Numero_Contrato = c.Numero,
                                  Rut = c.RutCliente,
                                  Creacion_C = c.Creacion,
                                  Termino_C = c.Termino,
                                  Modalidad = m.Nombre,
                                  Tipo = t.Descripcion,
                                  Hora_Inicio = c.FechaHoraInicio,
                                  Fecha_Termino = c.FechaHoraTermino,
                                  Asistentes_Evento = c.Asistentes,
                                  Personal_Evento = c.PersonalAdicional,
                                  Total = c.ValorTotalContrato,
                                  c.Observaciones,
                                  Estado = c.Realizado
                              }).ToArray();

                dgContrato.ItemsSource = llenar;
                btnEliminarContrato.Visibility = Visibility.Visible;
                 }
                else
                {
                    MessageBox.Show("El rut ingresado no corresponde a ningun Cliente con contrato");
                }
        }
    


        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Negocio.DatosContrato contrato = new Negocio.DatosContrato();
            btnEliminarContrato.Visibility = Visibility.Hidden;
            dgContrato.ItemsSource = contrato.listarContrato().ToArray();

        }

        private void BtnEliminarContrato_Click(object sender, RoutedEventArgs e)
        {
            Negocio.DatosContrato datosContrato = new Negocio.DatosContrato();
            MessageBoxResult result = MessageBox.Show("Seguro que desea eliminar el contrato?", "confirmacion",
                MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    datosContrato.eliminarContrato(txtBusquedaRut.Text);
                    MessageBox.Show("Se ha eliminado el contrato");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se ha podido eliminar al cliente" +ex);
                }
            }
        }

        private void CbxModalidad_Loaded(object sender, RoutedEventArgs e)
        {

            var llenar = (from a in bbdd.ModalidadServicio select new {id = a.IdModalidad, descrip = a.Nombre }).ToList();
            cbxModalidad.ItemsSource = llenar;
            cbxModalidad.SelectedValuePath = "id";
            cbxModalidad.DisplayMemberPath = "descrip";

        }

        private void BtnBusquedaFiltro_Click(object sender, RoutedEventArgs e)
        {
            String valor = Convert.ToString(cbxModalidad.SelectedValue);
            var consulta = (from a in bbdd.Contrato where a.IdModalidad == valor select a).ToList();
            if (valor == "" )
            {
                MessageBox.Show("Seleccione una actividad de empresa", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                dgContrato.ItemsSource = consulta;
            }
            
        }
    }
}
