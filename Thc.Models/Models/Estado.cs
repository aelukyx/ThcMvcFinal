using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thc.Models.Models
{
    public class Estado
    {

        public Estado()
        {
            this.Autos = new List<Auto>();
        }

        [Key]
        public int Id { get; set; }
        public String DescripcionEstado { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }

    }
}
