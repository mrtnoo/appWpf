using onBreak;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
        }

        private void BtnCrearCliente_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodels.ViewModelCliente();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodels.ViewModelListaCliente();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodels.ViewModelListadoContrato();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataContext = new viewmodels.ViewModelContrato();
        }
    }
    


}
