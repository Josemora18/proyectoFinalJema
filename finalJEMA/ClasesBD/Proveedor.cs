using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace finalJEMA
{
    public class Proveedor
    {
       [Key]  public int IdProveedor { get; set; } 
         public string NombreProveedor { get; set; } 
         public string Direccion {get; set; }
         public string Giro {get; set; }

         //public virtual ICollection<Servicio > Servicios { get; set; }
         public virtual ICollection<Factura> Facturas { get; set; }

         internal void Show()
         {
             throw new NotImplementedException();
         }
    }
}
