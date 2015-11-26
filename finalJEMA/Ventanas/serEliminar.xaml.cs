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
    /// Interaction logic for serEliminar.xaml
    /// </summary>
    public partial class serEliminar : Window
    {
        public serEliminar()
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
                var ser = /*from x in*/ db.Servicios .SingleOrDefault(x => x.IdServicio == id);
                /*  where x.id == id
                  select x;*/
                if (ser  != null)
                {
                    db.Servicios .Remove(ser );
                    db.SaveChanges();
                    MessageBox.Show("Se borraron los datos exitosamente");
                    limpiar();
                    actualizaGrid();
                }

            }
            else { MessageBox.Show("Solo Numeros donde corresponde"); }
        }

        private void limpiar()
        {
            txID.Text = string.Empty;    
        }

        public void actualizaGrid()
        {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            dbgrid.ItemsSource = db.Proveedores.ToList();
            db.SaveChanges();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            JEMA db = new JEMA();
            var registros = from s in db.Servicios 
                            select s;
            dbgrid.ItemsSource = registros.ToList();
            //////consultar por id
            ////if (Regex.IsMatch(txID.Text, @"^\d+$"))
            ////{
            ////    JEMA db = new JEMA();
            ////    int id = int.Parse(txID.Text);
            ////    var registros = from s in db.Servicios 
            ////                    where s.IdServicio == id
            ////                    select new
            ////                    {
            ////                        s.nomServicio,
            ////                        s.precio
                                    
            ////                    };
            ////    dbgrid.ItemsSource = registros.ToList();
            ////}
            ////else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
            limpiar();
        }
    }
}
