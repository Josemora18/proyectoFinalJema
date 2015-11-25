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
            if (Regex.IsMatch(txNombre.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(txDireccion.Text, @"^[a-zA-Z\s0-9]+$"))
            {
                //instanciar
                JEMA db = new JEMA();
                Proveedor  prov = new Proveedor ();
                prov.NombreProveedor = txNombre.Text;
                prov.Direccion = txDireccion.Text;
                prov.Giro = cbbGiro.Text;

                //prov .IdProveedor  = (int)cbbID.SelectedValue;
                //emp.Sueldo = int.Parse(txSueldo.Text);
                //emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;

                db.Proveedores .Add(prov );
                db.SaveChanges();
                actualizaCombo();
                MessageBox.Show("Se guardaron los datos exitosamente");
                limpiar();
            }
            else { MessageBox.Show("Solo inserte letras donde corresponde"); }
        }
        private void limpiar()
        {
            txNombre.Text = string.Empty;
            txDireccion.Text = string.Empty;
        }

        public void actualizaCombo() {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            cbbID.ItemsSource = db.Proveedores.ToList();
            cbbID.DisplayMemberPath = "IdProveedor";
            cbbID.SelectedValuePath = "IdProveedor";
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            provEliminar vta = new provEliminar ();
            vta.Show();
            limpiar();
        }

        private void txNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
            limpiar();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Actualizar
            if (Regex.IsMatch(txNombre.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(txDireccion.Text, @"^[a-zA-Z\s0-9]+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(cbbID.Text);
                var prov = /*from x in*/ db.Proveedores .SingleOrDefault(x => x.IdProveedor   == id);
                /*  where x.id == id
                  select x;*/
                if (prov  != null)
                {
                    prov.NombreProveedor  = txNombre.Text;
                    prov.Direccion  = txDireccion.Text;
                    prov.Giro = cbbGiro.Text;
                    db.SaveChanges();
                    MessageBox.Show("Se actualizaron los datos exitosamente");
                    limpiar();
                }
            }
            else { MessageBox.Show("Solo Letras y numeros donde corresponde"); }
           
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
        }

        private void txGiro_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            // para que muestre los dptos en el combobox
            JEMA  db = new JEMA ();
            cbbID.ItemsSource = db.Proveedores .ToList();
            cbbID.DisplayMemberPath = "IdProveedor";
            cbbID.SelectedValuePath = "IdProveedor";
        }
    }
}
