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
    /// Interaction logic for provEliminar.xaml
    /// </summary>
    public partial class provEliminar : Window
    {
        public provEliminar()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //borrar
            if (Regex.IsMatch(gf.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(gf.Text);
                var prov = /*from x in*/ db.Proveedores .SingleOrDefault(x => x.IdProveedor == id);
                /*  where x.id == id
                  select x;*/
                if (prov  != null)
                {
                    db.Proveedores .Remove(prov );
                    db.SaveChanges();

                }

            }
            else { MessageBox.Show("Solo Numeros  #id"); }
           MessageBox.Show("Se borraron los datos exitosamente");
        }

        private void gf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //consultar Todo
            //if (Regex.IsMatch(gf.Text, @"^\d+$"))
            //{
                JEMA  db = new JEMA ();
                var registros = from s in db.Proveedores 
                                select s;
                d.ItemsSource = registros.ToList();

            //}
            //else { MessageBox.Show("Solo Numeros  #id"); }
        
            //consultar por id
            //if (Regex.IsMatch(gf.Text, @"^\d+$"))
            //{
            //    JEMA db = new JEMA();
            //    int id = int.Parse(gf.Text);
            //    var registros = from s in db.Proveedores 
            //                    where s.IdProveedor == id
            //                    select new
            //                    {
            //                        s.NombreProveedor,
            //                        s.Direccion,
            //                        s.Giro 
            //                    };
            //    d.ItemsSource = registros.ToList();
            //}
            //else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void DbGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        

        

       
    }
}
