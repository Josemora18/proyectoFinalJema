using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace finalJEMA
{
   public  class Servicio
    {
       [Key] public int IdServicio {get; set;}
        public string nomServicio {get; set;}
        public float precio {get; set;}

       // public virtual int ProveedorIdProveedor { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }

        internal void show()
        {
            throw new NotImplementedException();
        }
    }
}
