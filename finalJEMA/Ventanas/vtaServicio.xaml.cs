using finalJEMA.ClasesBD;
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

namespace finalJEMA.Ventanas
{
    /// <summary>
    /// Interaction logic for vtaServicio.xaml
    /// </summary>
    public partial class vtaServicio : Window
    {
        public vtaServicio()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
            limpiar();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
              //instanciar
            if (Regex.IsMatch(txServicio.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txPrecio.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                Servicio   ser = new Servicio  ();
                ser.nomServicio = txServicio.Text;
                ser.precio = float.Parse(txPrecio.Text);
               // ser.ProveedorIdProveedor = int.Parse(comboprove.SelectedValue.ToString());
                //emp.Sueldo = int.Parse(txSueldo.Text);
                //emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;

                db.Servicios .Add(ser);
                db.SaveChanges();
                actualizaCombo();
                MessageBox.Show("Se guardaron los datos exitosamente");
                limpiar();
            }
            else { MessageBox.Show("Solo inserte letras donde corresponde"); }
            
        }
        public void actualizaCombo()
        {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            cbbID.ItemsSource = db.Proveedores.ToList();
            cbbID.DisplayMemberPath = "IdServicio";
            cbbID.SelectedValuePath = "IdServicio";
        }
        private void limpiar()
        {
            txServicio.Text = string.Empty;
            txPrecio.Text = string.Empty;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            serEliminar vta = new serEliminar();
            vta.Show();
            limpiar();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Actualizar
            if (Regex.IsMatch(txServicio.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txPrecio.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(cbbID.Text);
                var ser = /*from x in*/ db.Servicios .SingleOrDefault(x => x.IdServicio  == id);
                /*  where x.id == id
                  select x;*/
                if (ser  != null)
                {
                    ser.nomServicio  = txServicio.Text;
                    ser.precio = float.Parse(txPrecio.Text);
                    db.SaveChanges();
                    MessageBox.Show("Se actualizaron los datos exitosamente");
                    limpiar();
                }
            }
            else { MessageBox.Show("Solo Letras y numeros donde corresponde"); }
           
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            cbbID.ItemsSource = db.Servicios .ToList();
            cbbID.DisplayMemberPath = "IdServicio";
            cbbID.SelectedValuePath = "IdServicio";

        }

        private void ComboBox_Loaded_1(object sender, RoutedEventArgs e)
        {
            // para que muestre los proveedores de la bd en el cbb
            JEMA db = new JEMA();
            cbbIDPro.ItemsSource = db.Proveedores.ToList();
            cbbIDPro.DisplayMemberPath = "NombreProveedor";
            cbbIDPro.SelectedValuePath = "IdProveedor";
        }
    }
}
