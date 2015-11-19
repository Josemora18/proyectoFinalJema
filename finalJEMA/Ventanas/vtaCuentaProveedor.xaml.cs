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
            MainWindow vta = new MainWindow();
            vta.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txUsuario.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txContra.Text, @"^[a-zA-Z]+$"))
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
            }
            else { MessageBox.Show("Solo inserte letras "); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            eliminarcuenPro vta = new eliminarcuenPro();
            vta.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Actualizar
            if (Regex.IsMatch(txUsuario.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txContra.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txID.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(txID.Text);
                var cuePro = /*from x in*/ db.cuentaProveedores .SingleOrDefault(x => x.IdCuenta  == id);
                /*  where x.id == id
                  select x;*/
                if (cuePro != null)
                {
                    cuePro.usuario  = txUsuario.Text;
                    cuePro.contraseña  = txContra.Text;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras y numeros donde corresponde"); }
        }
    }
}
