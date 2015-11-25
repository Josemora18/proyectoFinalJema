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
    /// Interaction logic for vtaCuentaProveedor.xaml
    /// </summary>
    public partial class vtaCuentaProveedor : Window
    {
        public vtaCuentaProveedor()
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
            if (Regex.IsMatch(txUsuario.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txContra.Text, @"^[a-zA-Z0-9]+$"))
            {
                //instanciar
                JEMA db = new JEMA();
                cuentaProveedor  cuePro = new cuentaProveedor ();
                cuePro.usuario = txUsuario.Text;
                cuePro .contraseña  = txContra.Text;
                //emp.Sueldo = int.Parse(txSueldo.Text);
                //emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;

                db.cuentaProveedores .Add(cuePro );
                db.SaveChanges();
                actualizaCombo();
                MessageBox.Show("Se guardaron los datos exitosamente");
                limpiar();
            }
            else { MessageBox.Show("Solo inserte letras donde corresponde y sin espacios"); }
           
        }
        private void limpiar()
        {
            txUsuario.Text = string.Empty;
            txContra.Text = string.Empty;
        }
        public void actualizaCombo()
        {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            cbbID.ItemsSource = db.Proveedores.ToList();
            cbbID.DisplayMemberPath = "IdCuenta";
            cbbID.SelectedValuePath = "IdCuenta";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            eliminarcuenPro vta = new eliminarcuenPro();
            vta.Show();
            limpiar();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Actualizar
            if (Regex.IsMatch(txUsuario.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txContra.Text, @"^[a-zA-Z0-9]+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(cbbID.Text);
                var cuePro = /*from x in*/ db.cuentaProveedores .SingleOrDefault(x => x.IdCuenta  == id);
                /*  where x.id == id
                  select x;*/
                if (cuePro != null)
                {
                    cuePro.usuario  = txUsuario.Text;
                    cuePro.contraseña  = txContra.Text;
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
            cbbID.ItemsSource = db.cuentaProveedores .ToList();
            cbbID.DisplayMemberPath = "IdCuenta";
            cbbID.SelectedValuePath = "IdCuenta";
        }
    }
}
