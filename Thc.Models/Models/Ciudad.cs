using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Thc.Models.Models
{
    public class Ciudad
    {

        public Ciudad()
        {
            this.Proveedores = new List<Proveedor>();
        }

        [Key]
        public int Id { get; set; }
        public String NameCiudad { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }

    }
}
