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
        [Key] public int idFactura { get; set; }
        public DateTime fecha { get; set; }
        public virtual int AsistenteIdAsistente {get; set;}
        public virtual  int ServicioIdServicio { get; set; }
    }
}
