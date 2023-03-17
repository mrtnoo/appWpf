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
    /// Lógica de interacción para ContratoWPF.xaml
    /// </summary>
    public partial class ContratoWPF : UserControl
    {
        public ContratoWPF()
        {
            InitializeComponent();
        }

        public onbreakEntities bbdd = new onbreakEntities();

        private void TxtNroContrato_Loaded(object sender, RoutedEventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;


            if (month < 10 && day < 10 && hour < 10 && minute < 10)
            {
                String nroC = Convert.ToString(year + "0" + month + "0" + day + "0" + hour + "0" + minute);
                txtNroContrato.Text = nroC;
            }
            else if (month < 10 && day < 10 && hour < 10)
            {
                String nroC = Convert.ToString(year + "0" + month + "0" + day + "0" + hour + minute);
                txtNroContrato.Text = nroC;
            }
            else if (month < 10 && day < 10)
            {
                String nroC = Convert.ToString(year + "0" + month + "0" + day + hour + minute);
                txtNroContrato.Text = nroC;
            }
            else if (month < 10)
            {
                String nroC = Convert.ToString(year + "0" + month + day + hour + minute);
                txtNroContrato.Text = nroC;
            }
            else if (day < 10)
            {
                String nroC = Convert.ToString(year + month + "0" + day + hour + minute);
                txtNroContrato.Text = nroC;
            }
            else if (hour < 10)
            {
                String nroC = Convert.ToString(year + month + day + "0" + hour + minute);
                txtNroContrato.Text = nroC;
            }
            else
            {
                String nroC = Convert.ToString(year + month + day + hour + "0" + minute);
                txtNroContrato.Text = nroC;
            }
        }


        private void TxtFechaInicio_Loaded(object sender, RoutedEventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            string fecha = day + "-0" + month + "-" + year;

            txtFechaInicio.Text = Convert.ToString(fecha);
        }

        private void CbxModalidad_Loaded(object sender, RoutedEventArgs e)
        {
           

            var llenar = (from m in bbdd.ModalidadServicio orderby m.IdModalidad select new { descrip = m.Nombre.Trim(), id = m.IdModalidad }).ToList();
            cbxModalidad.ItemsSource = llenar;
            cbxModalidad.SelectedValuePath = "id";
            cbxModalidad.DisplayMemberPath = "descrip";
        }

        private void CbxTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CbxModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            String valor = Convert.ToString(cbxModalidad.SelectedValue);
            if (cbxModalidad.SelectedValue.Equals("CB001") || cbxModalidad.SelectedValue.Equals("CB002") || cbxModalidad.SelectedValue.Equals("CB003"))
            {
                
                var llenar = (from m in bbdd.TipoEvento where m.IdTipoEvento == 10 orderby m.IdTipoEvento select new { descrip = m.Descripcion, id = m.IdTipoEvento }).ToList();
                cbxTipoEvento.ItemsSource = llenar;
                cbxTipoEvento.SelectedValuePath = "id";
                cbxTipoEvento.DisplayMemberPath = "descrip";

                //a la mala csm :(
                if (valor.Equals("CB001"))
                {
                    txtValorTotal.Text = "3";
                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);

                }
                else if (valor.Equals("CB002"))
                {

                    txtValorTotal.Text = "8";
                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }
                else
                {
                    txtValorTotal.Text = "12";
                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }

            }
            else if (cbxModalidad.SelectedValue.Equals("CE001") || cbxModalidad.SelectedValue.Equals("CE002"))
            {
                
                var llenar = (from m in bbdd.TipoEvento where m.IdTipoEvento == 30 orderby m.IdTipoEvento select new { descrip = m.Descripcion, id = m.IdTipoEvento }).ToList();
                cbxTipoEvento.ItemsSource = llenar;
                cbxTipoEvento.SelectedValuePath = "id";
                cbxTipoEvento.DisplayMemberPath = "descrip";

                if (valor.Equals("CE001"))
                {
                    txtValorTotal.Text = "25";

                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }
                else
                {
                    txtValorTotal.Text = "35";
                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }

            }
            else if (cbxModalidad.SelectedValue.Equals("CO001") || cbxModalidad.SelectedValue.Equals("CO002"))
            {
                
                var llenar = (from m in bbdd.TipoEvento where m.IdTipoEvento == 20 orderby m.IdTipoEvento select new { descrip = m.Descripcion, id = m.IdTipoEvento }).ToList();
                cbxTipoEvento.ItemsSource = llenar;
                cbxTipoEvento.SelectedValuePath = "id";
                cbxTipoEvento.DisplayMemberPath = "descrip";

                if (valor.Equals("CO001"))
                {
                    txtValorTotal.Text = "6";
                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }
                else
                {
                    txtValorTotal.Text = "10";

                    int conversion = Convert.ToInt32(txtValorTotal.Text) * 27596;
                    txtTotalPeso.Text = Convert.ToString(conversion);
                }
            }
        
        }

        private void TxtAsistentes_TextChanged(object sender, TextChangedEventArgs e)
        {
           //calucar total
           //1 a 20 = 3
           //21 as 50 = 5;
           // +50 = 2 * 20;
        
 
        }

        private void TxtRut_TextChanged(object sender, TextChangedEventArgs e)
        {
            String rut = txtRut.Text;

            if (rut.Length == 10)
            {
                var verificar = bbdd.Contrato.FirstOrDefault(n=> n.RutCliente.Equals(rut));

                if (verificar == null)
                {
                    var cliente = bbdd.Cliente.FirstOrDefault(r => r.RutCliente.Equals(rut));
                    if (cliente != null)
                    {
                        txtRut.BorderBrush = Brushes.Green;
                        imgBien.Visibility = Visibility.Visible;
                        imgMal.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        txtRut.BorderBrush = Brushes.Red;
                        imgBien.Visibility = Visibility.Hidden;
                        imgMal.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    txtRut.BorderBrush = Brushes.Red;
                    imgBien.Visibility = Visibility.Hidden;
                    imgMal.Visibility = Visibility.Visible;
                    txtBusqueda.Text = rut;
                }
            }else if (rut.Length < 10 )
            {
                imgBien.Visibility = Visibility.Hidden;
                imgMal.Visibility = Visibility.Hidden;
                txtBusqueda.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int asistentes = Convert.ToInt32(txtAsistentes.Text);
            int personalAdicional = Convert.ToInt32(txtPersonal.Text);
            //int totalPeso = Convert.ToInt32(txtTotalPeso.Text);
            int totalUF = Convert.ToInt32(txtValorTotal.Text);

            if (txtAsistentes.Text != "" || txtPersonal.Text != "")
            {
                if (asistentes >= 1 && asistentes <= 20)
                {
                    //...
                    if (personalAdicional==2)
                    {
                        int total = totalUF + 2 + 3;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                    else if (personalAdicional==3)
                    {
                        int total = totalUF + 3 + 3;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                    else if (personalAdicional==4)
                    {
                        double total = totalUF + 3.5 + 3;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                }else if(asistentes >=21 && asistentes <=50)
                {
                    if (personalAdicional == 2)
                    {
                        int total = totalUF + 2 + 5;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                    else if (personalAdicional == 3)
                    {
                        int total = totalUF + 3 + 5;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                    else if (personalAdicional == 4)
                    {
                        double total = totalUF + 3.5 + 5;
                        txtValorTotal.Text = total.ToString();
                        txtTotalPeso.Text = (total * 27596).ToString();
                    }
                }
                else if ( asistentes>50)
                {
                    //...
                }
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {


                Negocio.Contrato contrato = new Negocio.Contrato()
                {
                    Numerocontrato = txtNroContrato.Text,
                    Creacion = Convert.ToDateTime(txtFechaInicio.Text),
                    Termino = Convert.ToDateTime(dtTermino.SelectedDate),
                    RutCliente = txtRut.Text,
                    IdModalidad = Convert.ToString(cbxModalidad.SelectedValue),
                    IdTipoEvento = Convert.ToInt32(cbxTipoEvento.SelectedValue),
                    FechaHoraInicio = Convert.ToDateTime(dtFechaInicio.SelectedDate),
                    FechaHoraTermino = Convert.ToDateTime(dtFechaTermino.SelectedDate),
                    Asistentes = Convert.ToInt32(txtAsistentes.Text),
                    PersonalAdicional = Convert.ToInt32(txtPersonal.Text),
                    Realizado = false,
                    ValorTotalContrato = Convert.ToInt32(txtTotalPeso.Text),
                    Observaciones = txtObservaciones.Text

                };
                Negocio.DatosContrato datosContrato = new Negocio.DatosContrato();
                if (datosContrato.agregarContrato(contrato))
                {
                    MessageBox.Show("Se ha registrado el contrato");
                }
                else
                {
                    MessageBox.Show("Algo ocurre");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se ha registrado el contrato" + ex);
            }
        }


        private void btnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                onbreakEntities bbdd = new onbreakEntities();
                Negocio.DatosContrato consuta = new Negocio.DatosContrato();

                Negocio.Contrato contrato = consuta.buscarContrato(txtRut.Text);
                if (txtBusqueda.Text.Length> 8)
                {
                    txtNroContrato.Text = contrato.Numerocontrato;
                    txtRut.Text = contrato.RutCliente;
                    txtObservaciones.Text = contrato.Observaciones;

                }
                else 
                {
                    MessageBox.Show("verifique el rut que busca");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("error en la busqueda");
            }
        }
    }
}
