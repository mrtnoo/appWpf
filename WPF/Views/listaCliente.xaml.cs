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
    /// Lógica de interacción para listaCliente.xaml
    /// </summary>
    public partial class listaCliente : UserControl
    {
        public listaCliente()
        {
            InitializeComponent();
            btnEliminarCliente.Visibility = Visibility.Hidden;

        }

        public onbreakEntities bbdd = new onbreakEntities();

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.DatosCliente consulta = new Negocio.DatosCliente();
            var mostrar = (from d in bbdd.Cliente
                           join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                           join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa
                        
                           select new {Rut = d.RutCliente,d.RazonSocial , Nombre =  d.NombreContacto, Correo = d.MailContacto,d.Direccion,d.Telefono, Actividad = m.Descripcion , tipo =  t.Descripcion}).ToArray();
            //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
            dgCliente.ItemsSource = mostrar;
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
            if (txtBusquedaRut.Text=="")
            {
                txtBusquedaRut.Text = "Ingrese rut..";
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtBusquedaRut.Text;
            if (txtBusquedaRut.Text.Length<11 && txtBusquedaRut.Text.Length>9 )
            {
                onbreakEntities bbdd = new onbreakEntities();

                var mostrar = (from d in bbdd.Cliente
                               join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                               join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa
                               where d.RutCliente == txtBusquedaRut.Text
                               select new { Rut = d.RutCliente, d.RazonSocial, Nombre = d.NombreContacto, Correo = d.MailContacto, d.Direccion, d.Telefono, Actividad = m.Descripcion, tipo = t.Descripcion }).ToArray();
                //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
                dgCliente.ItemsSource = mostrar;
                btnEliminarCliente.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Complete el campo de busqueda");
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mostrar = (from d in bbdd.Cliente
                           join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                           join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa
                           select new { Rut = d.RutCliente, d.RazonSocial, Nombre = d.NombreContacto, Correo = d.MailContacto, d.Direccion, d.Telefono, Actividad = m.Descripcion, tipo = t.Descripcion }).ToArray();
            //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
            dgCliente.ItemsSource = mostrar;
            txtBusquedaRut.Text = "";
            btnEliminarCliente.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Negocio.DatosCliente consulta = new Negocio.DatosCliente();
            MessageBoxResult respues = MessageBox.Show("Srguro que desea eliminar Cliente Rut : " + txtBusquedaRut.Text, "Confirmacion",
                MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (respues == MessageBoxResult.Yes)
            {
                try
                {
                    consulta.eliminarCliente(txtBusquedaRut.Text);
                    MessageBox.Show("Se ha eliminado el cliente");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se puede eliminar un cliente que posea un contrato");
                }
            }

        }

        private void CbxModalidad_Loaded(object sender, RoutedEventArgs e)
        {
            onbreakEntities bbdd = new onbreakEntities();

            var llenar = (from a in bbdd.ActividadEmpresa orderby a.IdActividadEmpresa select new { id = a.IdActividadEmpresa, descrip = a.Descripcion }).ToList();
            cbxModalidad.ItemsSource = llenar;
            cbxModalidad.SelectedValuePath = "id";
            cbxModalidad.DisplayMemberPath = "descrip";


        }

        private void BtnBusquedaFiltro_Click(object sender, RoutedEventArgs e)
        {
            onbreakEntities bbdd = new onbreakEntities();
            int valor = Convert.ToInt32(cbxModalidad.SelectedValue);
            if (valor == 0)
            {
                MessageBox.Show("Seleccione una actividad de empresa","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var mostrar = (from d in bbdd.Cliente
                               join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                               join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa
                               where d.IdActividadEmpresa == valor
                               select new { Rut = d.RutCliente, d.RazonSocial, Nombre = d.NombreContacto, Correo = d.MailContacto, d.Direccion, d.Telefono, Actividad = m.Descripcion, tipo = t.Descripcion }).ToArray();
                //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
                dgCliente.ItemsSource = mostrar;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var mostrar = (from d in bbdd.Cliente
                           join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                           join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa
                           join c in bbdd.Contrato on d.RutCliente equals c.RutCliente
                           select new { Rut = d.RutCliente, d.RazonSocial, Nombre = d.NombreContacto, Correo = d.MailContacto, d.Direccion, d.Telefono, Actividad = m.Descripcion, tipo = t.Descripcion,Contrato = c.Numero,Estado = c.Realizado }).ToArray();
            //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
            dgCliente.ItemsSource = mostrar;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Negocio.DatosCliente consulta = new Negocio.DatosCliente();
            var mostrar = (from d in bbdd.Cliente
                           join m in bbdd.ActividadEmpresa on d.IdActividadEmpresa equals m.IdActividadEmpresa
                           join t in bbdd.TipoEmpresa on d.IdTipoEmpresa equals t.IdTipoEmpresa

                           select new { Rut = d.RutCliente, d.RazonSocial, Nombre = d.NombreContacto, Correo = d.MailContacto, d.Direccion, d.Telefono, Actividad = m.Descripcion, tipo = t.Descripcion }).ToArray();
            //dgCliente.ItemsSource = consulta.listarCliente().ToArray();
            dgCliente.ItemsSource = mostrar;
        }
    }
}
