using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  System.ComponentModel.DataAnnotations;
namespace finalJEMA
{
    public class cuentaProveedor
    {
        [Key] public int IdCuenta {get; set;}
        public string usuario {get; set;}
        public string contraseña {get; set; }

        internal void show()
        {
            throw new NotImplementedException();
        }
    }
}
