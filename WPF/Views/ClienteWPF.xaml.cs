using onBreak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace WPF
{
    /// <summary>
    /// Lógica de interacción para ClienteWPF.xaml
    /// </summary>
    public partial class ClienteWPF : UserControl
    {
        public ClienteWPF()
        {
            InitializeComponent();
            btnModificar.Visibility = Visibility.Hidden;
            btnEliminarCliente.Visibility = Visibility.Hidden;
            btnModificar.Focusable = true;
            btnAgregar.IsEnabled = false;
            //control vaciar campos


        }
        public onbreakEntities bbdd = new onbreakEntities();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(cbxActividad.SelectedValue);
      

                Negocio.Cliente cliente = new Negocio.Cliente()
                {
                    RutCliente = txtRut.Text,
                    RazonSocial = txtRazonSocial.Text,
                    NombreContacto = txtNombre.Text,
                    MailContacto = txtCorreo.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    ActividadEmpresa = valor,
                    TipoEmpresa = Convert.ToInt32(cbxTipoEmpresa.SelectedValue)
                };

                Negocio.DatosCliente consulta = new Negocio.DatosCliente();

                if (consulta.validarCliente(txtRut.Text))
                {  

                    if (txtRut.Text.Length>7 && txtRut.Text.Length<11 
                            
                        && txtRazonSocial.Text.Length>3 && txtNombre.Text.Length>2
                        && txtCorreo.Text.Length>4 && txtDireccion.Text.Length>4 
                        && txtTelefono.Text.Length>7 && cbxActividad.SelectedIndex>-1 && cbxTipoEmpresa.SelectedIndex>-1 )
                    {
                        if (consulta.agregarCliente(cliente))
                        {
                            MessageBox.Show("Se ha agregado correctamente");
                            btnContrato.IsEnabled = true;
                            btnModificar.Visibility = Visibility.Visible;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Verifique datos vacios o demasiado cortos ");
                    }
                }
                else
                {
                    MessageBox.Show("El cliente ya esta registrado");
                    txtBusquedaRut.Text = txtRut.Text;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("no se ha registrado" + ex.Message);
            }
        }


        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                if (rut == "")
                {
                    MessageBox.Show("rellene el campo");
                }
                else
                {
                    Negocio.DatosCliente consulta = new Negocio.DatosCliente();
                    consulta.eliminarCliente(rut);

                    MessageBox.Show("se elimino el Cliente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("no se logro eliminar Cliente" + ex);
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                if (rut == "")
                {
                    MessageBox.Show("rellene los campos");
                }
                else
                {
                    Negocio.DatosCliente consulta = new Negocio.DatosCliente();
                    Negocio.Cliente cliente = new Negocio.Cliente()
                    {
                        RutCliente = txtRut.Text,
                        RazonSocial = txtRazonSocial.Text,
                        NombreContacto = txtNombre.Text,
                        MailContacto = txtCorreo.Text,
                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        ActividadEmpresa = Convert.ToInt32(cbxActividad.SelectedValue),
                        TipoEmpresa = Convert.ToInt32(cbxTipoEmpresa.SelectedValue)
                    };
                    MessageBoxResult respuesta = MessageBox.Show("Seguro que desea modificar al cliente?", "Confirmacion",
                        MessageBoxButton.YesNo,MessageBoxImage.Question);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        if (consulta.modificarCliente(cliente))
                        {
                            MessageBox.Show("se logro modificar al clinte");
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("No se logro modificar al cliente" + ex);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                onbreakEntities bbdd = new onbreakEntities();
                Negocio.DatosCliente consulta = new Negocio.DatosCliente();
              
                Negocio.Cliente cliente = consulta.buscarCliente(txtBusquedaRut.Text);
                if (cliente.RutCliente.Length > 0)
                {
                    txtRut.Text = cliente.RutCliente;
                    txtRazonSocial.Text = cliente.RazonSocial;
                    txtNombre.Text = cliente.NombreContacto;
                    txtCorreo.Text = cliente.MailContacto;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono;
                    btnContrato.IsEnabled = true;
                    btnModificar.Visibility = Visibility.Visible;
                    btnEliminarCliente.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("El rut ingresado no corresponde a un cliente");
                }

 
            }
            catch (Exception)
            {

                MessageBox.Show("El rut ingresado no corresponde a un cliente"); 
            }
        }
        private void vaciarCampos()
        {
            txtRut.Clear();
            txtRazonSocial.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            btnContrato.IsEnabled = false;
            btnModificar.Visibility = Visibility.Hidden;
            btnEliminarCliente.Visibility = Visibility.Hidden;

        }


        private void BtnVaciarCampos_Click(object sender, RoutedEventArgs e)
        {
            vaciarCampos();
        }

        private void CbxActividad_Loaded(object sender, RoutedEventArgs e)
        {
            //llenar combo actividad
            onbreakEntities bbdd = new onbreakEntities();

            var llenar = (from a in bbdd.ActividadEmpresa orderby a.IdActividadEmpresa select new { id = a.IdActividadEmpresa, descrip = a.Descripcion }).ToList();
            cbxActividad.ItemsSource = llenar;
            cbxActividad.SelectedValuePath = "id";
            cbxActividad.DisplayMemberPath = "descrip";
        }

        private void CbxTipoEmpresa_Loaded(object sender, RoutedEventArgs e)
        {
            onbreakEntities bbdd = new onbreakEntities();

            var llenar = (from a in bbdd.TipoEmpresa select new { id = a.IdTipoEmpresa, descrip = a.Descripcion }).ToList();
            cbxTipoEmpresa.ItemsSource = llenar;
            cbxTipoEmpresa.SelectedValuePath = "id";
            cbxTipoEmpresa.DisplayMemberPath = "descrip";
        }
        //VALIDAR DATOS DEL CONTRATO 
        private void BtnContrato_Click(object sender, RoutedEventArgs e)
        {

            WPF.Contrato contrato = new WPF.Contrato();
            //llevar datos --RUT
            contrato.txtRut.Text = txtRut.Text;
            contrato.txtValorTotal.Text = "0";
            contrato.lblmsjError.Visibility = Visibility.Hidden;
            onbreakEntities bbdd = new onbreakEntities();
            //onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(cli.RutCliente));
            if (verificarContratoExistente(txtRut.Text) == true)
            {
                //BOTON CONTRATO
                contrato.lblmsjError.Visibility = Visibility.Visible;
                contrato.btnCrearContrato.Visibility = Visibility.Hidden;

                //CAMPOS NO MODIFICABLES
                contrato.dtTermino.IsEnabled = false;
                contrato.dtTermino.Focusable = false;

                contrato.dtFechaTermino.IsEnabled = false;
                contrato.dtFechaTermino.Focusable = false;

                contrato.cbxModalidad.IsEnabled = false;
                contrato.cbxModalidad.Focusable = false;

                contrato.cbxTipoEvento.IsEnabled = false;
                contrato.cbxTipoEvento.Focusable = false;

                contrato.dtFechaInicio.IsEnabled = false;
                contrato.dtFechaInicio.Focusable = false;

                contrato.txtAsistentes.IsEnabled = false;
                contrato.txtAsistentes.Focusable = false;

                contrato.txtPersonal.IsEnabled = false;
                contrato.txtPersonal.Focusable = false;

                contrato.txtObservaciones.IsEnabled = false;
                contrato.txtObservaciones.Focusable = false;



            }

            contrato.ShowDialog();
            
            
            

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

        private bool CamposVacion()
        {
            if (txtCorreo.Text.Length == 0 && txtDireccion.Text.Length == 0 &&
                 txtNombre.Text.Length == 0 && txtRazonSocial.Text.Length == 0 &&
                 txtTelefono.Text.Length == 0)
            {
                return true;
            } else
                return false;
        }

        //validar contrato existente
        private bool verificarContratoExistente(String rut)
        {
            //onBreak.Cliente cliente = bbdd.Cliente.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(cli.RutCliente));
            onbreakEntities bbdd = new onbreakEntities();
            onBreak.Contrato contrato = bbdd.Contrato.FirstOrDefault(ncliente => ncliente.RutCliente.Equals(rut));
            if (contrato != null)
            {
                return true;
            }

            return false;
        }

        private void TxtRut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||
                e.Key == Key.K || e.Key == Key.OemMinus)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtRazonSocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TxtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z || e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtBusquedaRut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
             e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||
             e.Key == Key.K || e.Key == Key.OemMinus)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            String rut = txtRut.Text;

            if (rut.Length>7 && rut.Length<11)
            {
                var verificar = bbdd.Cliente.FirstOrDefault(n => n.RutCliente.Equals(rut));

                if (verificar == null)
                {
                    txtRut.BorderBrush = Brushes.Green;
                    imgError.Visibility = Visibility.Hidden;
                    imgCheck.Visibility = Visibility.Visible;
                    btnAgregar.IsEnabled = true;
                    
                    //txtAsistentes.Text = "existe";
                }
                else
                {
                    txtRut.BorderBrush = Brushes.Red;
                    imgCheck.Visibility = Visibility.Hidden;
                    imgError.Visibility = Visibility.Visible;
                    txtBusquedaRut.Text = rut;
                    btnAgregar.IsEnabled = false;
                    //txtAsistentes.Text = "no existe";
                }
            }else 
            {
                txtRut.BorderBrush = Brushes.Red;
                imgCheck.Visibility = Visibility.Hidden;
                imgError.Visibility = Visibility.Visible;
                txtBusquedaRut.Text = rut;
                btnAgregar.IsEnabled = false;
            }
            
          
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                if (rut == "")
                {
                    MessageBox.Show("rellene el campo");
                }
                else
                {
                    MessageBoxResult respuesta = MessageBox.Show("Seguro que desea modificar al cliente?", "Confirmacion",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        Negocio.DatosCliente consulta = new Negocio.DatosCliente();
                        consulta.eliminarCliente(rut);
                        MessageBox.Show("Cliente eliminado");
                        vaciarCampos();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error: Cliente posee un contrato asociado");
            }
        }
    }
 }

