using finalJEMA.ClasesBD;
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
using System.Windows.Shapes;

namespace finalJEMA.Ventanas
{
    /// <summary>
    /// Interaction logic for vtaFactura.xaml
    /// </summary>
    public partial class vtaFactura : Window
    {
        private Servicio tempServicio = null;
        private List<Servicio> AgregarAlGrid;
        public vtaFactura()
        {
            InitializeComponent();
            AgregarAlGrid = new List<Servicio>();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            // para que muestre los dptos en el combobox
            JEMA db = new JEMA();
            vd.ItemsSource = db.Proveedores.ToList();
            vd.DisplayMemberPath = "NombreProveedor";
            vd.SelectedValuePath = "IdProveedor";
            
            xv.ItemsSource = db.Servicios.ToList();
            xv.DisplayMemberPath = "IdServicio";
            xv.SelectedValuePath = "IdServicio";
        


        }

        private void LimpiarCbb() 
        {
            vd.Text = string.Empty;
            xv.Text = string.Empty;
        }
        private void actualizaGrid()
        {
            //JEMA db = new JEMA ();
            var registros = from s in AgregarAlGrid 
                            select new
                            {
                                s.IdServicio,
                                s.nomServicio,
                                s.precio,
                                s.ProveedorIdProveedor,
                                
                                //Subtotal = s.precio * s.cantidad
                            };
            ar.ItemsSource = null;
            ar.ItemsSource = registros;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MainWindow vta = new MainWindow();
            //vta.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if (xv.SelectedIndex  > -1)
            //{
            //    MessageBox.Show("No se ha seleccionado servicio", "No hay servicio", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    return;
            //}
            //else
            //{

            JEMA db = new JEMA();
            //int idProv = int.Parse(xv.Text);
            int id = int.Parse(xv.Text);
            Servicio p = db.Servicios.SingleOrDefault  (x => x.IdServicio  == id);
            //db.Proveedor  = db.Proveedores  .SingleOrDefault(x => x.IdProveedor == (int)xv.SelectedValue);
            //db.Servicio  = db.Servicios .SingleOrDefault(s => s.ProveedorIdProveedor  == (int)vd.SelectedValue);
            
            if (p != null )
            {
                tempServicio = p;

            }
        
            AgregarAlGrid.Add (new Servicio()
                {
                    IdServicio = tempServicio.IdServicio,
                    nomServicio = tempServicio.nomServicio,
                    precio = tempServicio.precio,
                    ProveedorIdProveedor = tempServicio.ProveedorIdProveedor,
                });

                actualizaGrid();
                tempServicio = null;
                vd.Text = string.Empty;
                xv.Text = string.Empty;
            }
        }

    }

