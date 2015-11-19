using finalJEMA.ClasesBD;
using finalJEMA.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace finalJEMA
{
    /// <summary>
    /// Interaction logic for nuevaVentana.xaml
    /// </summary>
    public partial class nuevaVentana : Window
    {
        public nuevaVentana()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txNombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txDireccion.Text, @"^[a-zA-Z]+$")&& Regex.IsMatch(txDireccion.Text, @"^[a-zA-Z]+$"))
            {
                //instanciar
                JEMA db = new JEMA();
                Proveedor  prov = new Proveedor ();
                prov.NombreProveedor = txNombre.Text;
                prov.Direccion = txDireccion.Text;
                prov.Giro = txGiro.Text;
                //emp.Sueldo = int.Parse(txSueldo.Text);
                //emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;

                db.Proveedores .Add(prov );
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo inserte letras "); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            provEliminar vta = new provEliminar ();
            vta.Show();
        }

        private void txNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
