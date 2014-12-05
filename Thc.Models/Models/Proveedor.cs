using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Thc.Models.Models
{
    public class Proveedor
    {

        public int Id { get; set; }

        public String NroRUC { get; set; }

        public String RazonSocial { get; set; }

        public String Direccion { get; set; }

        public String Telefono { get; set; }
        
        public String Celular { get; set; }

        public String Email { get; set; }

        public int? CiudadId { get; set; }

        public virtual Ciudad Ciudad { get; set; }

    }
}
