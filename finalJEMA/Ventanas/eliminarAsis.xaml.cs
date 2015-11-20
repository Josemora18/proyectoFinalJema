﻿using finalJEMA.ClasesBD;
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
    /// Interaction logic for eliminarAsis.xaml
    /// </summary>
    public partial class eliminarAsis : Window
    {
        public eliminarAsis()
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
                var asis = /*from x in*/ db.Asistentes .SingleOrDefault(x => x.IdAsistente  == id);
                /*  where x.id == id
                  select x;*/
                if (asis  != null)
                {
                    db.Asistentes .Remove(asis );
                    db.SaveChanges();

                }

            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //consultar por id
            if (Regex.IsMatch(txID.Text, @"^\d+$"))
            {
                JEMA db = new JEMA();
                int id = int.Parse(txID.Text);
                var registros = from s in db.Asistentes 
                                where s.IdAsistente  == id
                                select new
                                {
                                    s.nomAsistente ,
                                    s.apeAsistente ,
                                    s.telAsistente 
                                };
                dbgrid.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Solo Numeros  #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow vta = new MainWindow();
            vta.Show();
        }
    }
}