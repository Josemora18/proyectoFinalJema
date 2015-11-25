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
    /// Interaction logic for eliminarcuenPro.xaml
    /// </summary>
    public partial class eliminarcuenPro : Window
    {
        public eliminarcuenPro()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //borrar
            if (Regex.IsMatch(txID.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(txID.Text);
                var cuenPro= /*from x in*/ db.cuentaProveedores .SingleOrDefault(x => x.IdCuenta  == id);
                /*  where x.id == id
                  select x;*/
                if (cuenPro  != null)
                {
                    db.cuentaProveedores .Remove(cuenPro );
                    db.SaveChanges();
                    MessageBox.Show("Se borraron los datos exitosamente");
                }

            }
            else { MessageBox.Show("Solo Numeros  #id"); }
           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JEMA db = new JEMA();
            var registros = from s in db.cuentaProveedores 
                            select s;
            dbgrid.ItemsSource = registros.ToList();
            ////consultar por id
            //if (Regex.IsMatch(txID.Text, @"^\d+$"))
            //{
            //    JEMA db = new JEMA();
            //    int id = int.Parse(txID.Text);
            //    var registros = from s in db.cuentaProveedores 
            //                    where s.IdCuenta  == id
            //                    select new
            //                    {
            //                        s.usuario ,
            //                        s.contraseña 
                                    
            //                    };
            //    dbgrid.ItemsSource = registros.ToList();
            //}
            //else { MessageBox.Show("Solo Numeros  #id"); }
        }
    }
}
