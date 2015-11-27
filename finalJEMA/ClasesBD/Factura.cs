using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace finalJEMA
{
   public  class Factura
    {
       public Factura ()
       {
           //this.Proveedor = new Proveedor ();
           this.ProveedorList = new List<Servicio>();
       }
        [Key] public int idFactura { get; set; }
        public DateTime fecha { get; set; }
        public virtual int AsistenteIdAsistente {get; set;}
        public virtual  int ServicioIdServicio { get; set; }
        //public virtual Proveedor IdPrveedor { get; set; }
        public virtual List<Servicio> ProveedorList { get; set; }


        //public virtual Proveedor Proveedor { get; set; }
    }
}
