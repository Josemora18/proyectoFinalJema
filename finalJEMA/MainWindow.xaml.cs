using finalJEMA.ClasesBD;
using finalJEMA.Ventanas;
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

namespace finalJEMA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Proveedor  tempProveedor = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nuevaVentana vta = new nuevaVentana();
            vta.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JEMA db = new JEMA();
            if (db.Proveedores.Count() > 0)
            {
                vtaServicio vta = new vtaServicio();
                vta.Show();
            }
            else
            {
                MessageBox.Show("No puede ingresar porque no hay Proveedores dados de alta en la BD", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vtaFactura vta = new vtaFactura();
            vta.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            vtaAsistente vta = new vtaAsistente();
            vta.Show();
        }
    }
}
