using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalJEMA.ClasesBD
{
    public class JEMA : DbContext 
    {
        public DbSet<EjemploProyecto> EjemploProyectos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<cuentaProveedor> cuentaProveedores { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        public object ItemsSource { get; set; }
    }
}
