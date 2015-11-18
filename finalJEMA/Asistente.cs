using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace finalJEMA
{
    public class Asistente
    {
     [Key]   public int IdAsistente { get; set; }
        public string nomAsistente { get; set; }
        public string  apeAsistente { get; set; }
        public string  telAsistente { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
