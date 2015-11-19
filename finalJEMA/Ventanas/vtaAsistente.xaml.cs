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
    /// Interaction logic for vtaAsistente.xaml
    /// </summary>
    public partial class vtaAsistente : Window
    {
        public vtaAsistente()
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
            if (Regex.IsMatch(txAsistente.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txapellido.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtel.Text, @"^\d+$"))
            {
                //instanciar
                JEMA db = new JEMA();
                Asistente  asis = new Asistente ();
                asis.nomAsistente  = txAsistente.Text;
                asis.apeAsistente  = txapellido.Text;
                asis.telAsistente = txtel.Text;
                //emp.Sueldo = int.Parse(txSueldo.Text);
                //emp.DepartamentoId = (int)CbDepartamentos.SelectedValue;

                db.Asistentes .Add(asis );
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo inserte letras "); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            eliminarAsis vta = new eliminarAsis();
            vta.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Actualizar
            if (Regex.IsMatch(txAsistente.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txapellido.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(txtel.Text, @"^\d+$") && Regex.IsMatch(txID.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(txID.Text);
                var asis = /*from x in*/ db.Asistentes .SingleOrDefault(x => x.IdAsistente  == id);
                /*  where x.id == id
                  select x;*/
                if (asis != null)
                {
                    asis.nomAsistente   = txAsistente.Text;
                    asis.apeAsistente  = txapellido.Text;
                    asis.telAsistente  = txtel.Text;
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo Letras y numeros donde corresponde"); }
        }
    }
}
